using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Drawing;
using Terraria.ModLoader.IO;

namespace Tacklebox {

	public class TackleboxPlayer : ModPlayer {

		public int bait = 0;
		public int jigSet = 0;

		/// <summary>
		/// The number of lines being cast when using a fishing pole
		/// </summary>
		public int lineCount = 1;

        /// <summary>
        /// The tier level of the equipped reel. The higher the tier, the bigger the chance of getting more than 1 crate when fishing
        /// </summary>
        public int reelTier = 0;

		/// <summary>
		/// The tier level of the equipped hook
		/// </summary>
		public int hookTier = 0;

        /// <summary>
        /// Player has the Sonar Stick equipped. Apply the buff
        /// </summary>
        public bool sonarActive = false;

		public bool sizzLine = false;

		public override void ResetEffects() {
			jigSet = 0;
			lineCount = 1;
			reelTier = 0;
			hookTier = 0;
			sonarActive = Player.HasItem(ModContent.ItemType<Items.Accessories.SonarStick>());
			if(sizzLine)
			{
				sizzLine = false;
				foreach(int pole in Tacklebox.noLava) //TODO: why is this inside of sizzline?
				{
					ItemID.Sets.CanFishInLava[pole] = false;
				}
			}
		}

		public override void PostUpdateBuffs()
		{
			if(!Player.sonarPotion && sonarActive)   Player.sonarPotion = sonarActive;
		}

        public override void GetFishingLevel(Item fishingRod, Item bait, ref float fishingLevel)
		{
			if(Player.FindBuffIndex(ModContent.BuffType<Buffs.BigFishing>()) != -1)
			{
				fishingLevel += 22f; //TODO: test it
				if(Player.FindBuffIndex(BuffID.Fishing) != -1)   fishingLevel -= 15f;
			}

			if(hookTier > 0)
			{
				fishingLevel += 5f;
				if(hookTier > 1)   fishingLevel += 5f;
			}

			if(fishingRod.type == ModContent.ItemType<Items.Poles.XolaRod>())   fishingLevel += (float)bait.bait;

			else if(fishingRod.type == ModContent.ItemType<Items.Poles.GemRod>())
			{
				fishingLevel /= 2f;
				if(bait.type == ModContent.ItemType<Items.Bait.CrabClaw>())   fishingLevel += 20f; //TODO: test it
			}
			else if(fishingRod.type == ModContent.ItemType<Items.Poles.TheZodiac>()) {
				if(Main.moonPhase == 0)   fishingLevel *= 1.20f;
				if(Main.moonPhase == 1 || Main.moonPhase == 7)   fishingLevel *= 1.10f;
                // moonPhase 2 || 6 --> 100%
                if (Main.moonPhase == 3 || Main.moonPhase == 5)   fishingLevel *= 0.90f;
				if(Main.moonPhase == 4)   fishingLevel *= 0.80f;
			}
		}

        /// <summary>
        /// Calculates a "one out of x-times" chance with the players total fishing power and the quality category of the to-be-catched item.
		/// <br/>Functionality exactly like vanilla Terraria
		/// <br/>Source: https://terraria.fandom.com/wiki/Fishing  --> "catch quality"
		/// <br/>
        /// <br/><param name="fPow">Fishing power: the higher the value, the higher the resulting chance to get a successful check</param>
        /// <br/><param name="cQual">Catch quality: 0=Plentiful, 1=Common, 2=Uncommon, 3=Rare, 4=Very Rare, 5=Extremely Rare</param>
        /// <br/><returns></returns></summary>
        public bool RarityCheck(int fPow, int cQual)
		{
			if (cQual > 6)    RarityCheck(fPow, (float)cQual); //to prevent user errors

            float baseVal;
			switch (cQual)
			{
				case 0:
					return true;
				case 1:
					baseVal = 150f;
					break;
				case 2:
					baseVal = 300f;
					break;
				case 3:
					baseVal = 1050f;
					break;
				case 4:
					baseVal = 2250f;
					break;
				case 5:
					baseVal = 4500f;
					break;
				case 6:
					baseVal = 4500f;
					break;
				default: return false;
			}

            return Chance.Perc2( 1 / Math.Max( ((float)cQual + 1f), (baseVal / (float)fPow) )); // Max( capped chance, fishpower chance)
            //return Chance.OneOut( (int)Math.Max( (cQual + 1), (150 * ((1 << cQual) - 1) / fPow) )); // MAX( (diff + 1) , 150 * ((2^diff)-1) / fishingPower) )
        }

        /// <summary>
        /// Calculates a "one out of x-times" chance with the players total fishing power and the quality category of the to-be-catched item.
		/// <br/>Transforms the original "catch quality" to a continous function, making in-between values possible (f.ex.: 0.8 or 4.65 or 8).
		/// <br/>Source: https://terraria.fandom.com/wiki/Fishing  --> "catch quality"
        /// <br/>
        /// <br/><param name="fPow">Fishing power: the higher the value, the higher the resulting chance to get a successful check</param>
        /// <br/><param name="cQual">Catch quality: 0 .. cQual .. maxFloat  (values which match vanilla base values: 0=Plentiful, 1=Common, 1.585=Uncommon, 3=Rare, 4=Very Rare, 4.954=Extremely Rare)</param>
        /// <returns></returns></summary>
        public bool RarityCheck(int fPow, float cQual)
        {
			float baseVal = 150f * ((float)Math.Pow(2f, cQual) - 1f);

            return Chance.Perc2( 1 / Math.Max(((float)cQual + 1f), (baseVal / (float)fPow))); // Max( capped chance, fishpower chance)
            //return Chance.OneOut( (int)Math.Max( (cQual + 1), (150 * ((1 << cQual) - 1) / fPow) )); // MAX( (diff + 1) , 150 * ((2^diff)-1) / fishingPower) )
        }




        public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition)
		{
			int baitType = attempt.playerFishingConditions.Bait.type;
            int fRodType = attempt.playerFishingConditions.PoleItemType;
			int fPower = attempt.playerFishingConditions.FinalFishingLevel; //TODO: check if this is really (pole power + bait power)
            var source = Main.LocalPlayer.GetSource_FromThis();

            #region Junk
            int[] junk = new int[]
			{
				ItemID.OldShoe,
				ItemID.FishingSeaweed,
				ItemID.TinCan,
				ModContent.ItemType<Items.Junk.Cassette>(),
				ModContent.ItemType<Items.Junk.Driftwood>(),
				ModContent.ItemType<Items.Junk.BrokenPDA>()
				//ModContent.ItemType<Items.Junk.BrokenSonar>() --> Broken sonar isn't in this list because it's only dropped by crates
			};
			if (junk.Contains(itemDrop)) //the to-be-fished itemDrop would be one of the original 3 junks
			{
				itemDrop = junk[Main.rand.Next(junk.Length)]; //make it one random piece of the whole junk palette (which includes the new junks)
				return;
			}
            #endregion

            #region Gem Rod
            // GemRod let's you fish gems -> changing fish drops to gem drops
            if (fRodType == ModContent.ItemType<Items.Poles.GemRod>()) {

                if      (RarityCheck(fPower, 5f))   itemDrop = ItemID.Diamond;
                else if (RarityCheck(fPower, 4.5f))   itemDrop = ItemID.Ruby;
                else if (RarityCheck(fPower, 4f))   itemDrop = ItemID.Emerald;
                else if (RarityCheck(fPower, 3.5f))   itemDrop = ItemID.Sapphire;
                else if (RarityCheck(fPower, 3f))   itemDrop = ItemID.Topaz;
                else if (RarityCheck(fPower, 2f))
				{
                    if (Player.ZoneDesert)   itemDrop = ItemID.Amber;
                    else                     itemDrop = ItemID.Amethyst;
                }
                else if (RarityCheck(fPower, 1f))
                {
                    if (Player.ZoneDesert)   itemDrop = ItemID.DesertFossil;
                    else                     itemDrop = ItemID.SiltBlock;
                }
				else
				{
                    if (Player.ZoneDesert)   itemDrop = ItemID.SandBlock;
                    else                     itemDrop = ItemID.StoneBlock;
                }

                //TODO: add something to the other zones?
                return;
			}
			#endregion

            #region Bonus crates
            if ( (Tacklebox.allCrates).Contains(itemDrop) ) //the to-be-fished itemDrop would be a crate
            {
				int bonusCrateChance = reelTier * 5;
				if(Player.FindBuffIndex(ModContent.BuffType<Buffs.BigCrate>()) != -1)
				{
					bonusCrateChance += 17;
					if(Player.FindBuffIndex(BuffID.Crate) != -1)   bonusCrateChance -= 10; // the two buffs shall not stack
				}
				if(bonusCrateChance > Main.rand.Next(100))
				{
                    int bonusCrate = 0;
                    if (RarityCheck(fPower, 2))
					{
						bonusCrate = ItemID.WoodenCrate; //TODO: don't change itemDrop, do QuickSpawnItem
						if (Main.hardMode) bonusCrate = ItemID.WoodenCrateHard;
					}

                    if (RarityCheck(fPower, 3))
					{
                        bonusCrate = ItemID.IronCrate;
                        if (Main.hardMode) bonusCrate = ItemID.IronCrateHard;
                    }
					if(RarityCheck(fPower, 4))
					{
                        bonusCrate = ItemID.GoldenCrate;
						if (Main.hardMode) bonusCrate = ItemID.GoldenCrateHard;
                    }
                    //TODO: what about the other crates? ...Ocean, Desert n stuff...here is some idea code:
                    //if (System.Array.IndexOf(Tacklebox.allCrates) != -1)
                    //{
                    //    int type = System.Array.IndexOf(Tacklebox.basicCrates);
                    //    if (type != -1)
                    //    {
                    //        if (RarityCheck(power, type + 1))
                    //        {
                    //            if (worldLayer == 3) itemDrop = Mod.Find<ModItem>("GemCrate").Type;
                    //        }
                    //        if (RarityCheck(power, type + 2))
                    //        {
                    //            if (Player.ZoneSnow && liquidType == 0) itemDrop = Mod.Find<ModItem>("SnowCrate").Type;
                    //            else if (Player.ZoneBeach && liquidType == 0) itemDrop = Mod.Find<ModItem>("SeaCrate").Type;
                    //            else if (Player.ZoneDesert && liquidType == 0) itemDrop = Mod.Find<ModItem>("SandCrate").Type;
                    //            else if (Player.ZoneUnderworldHeight && liquidType == 1) itemDrop = Mod.Find<ModItem>("HellCrate").Type;
                    //        }
                    //    }
                    //    return;
                    //}

                    //TODO: try out the fancy "drop crate on bopper" code

                    if (bonusCrate > 0) Main.LocalPlayer.QuickSpawnItem(source, bonusCrate);
                }
			}
            #endregion


            bool jigOcean = (jigSet & 1) == 1;
            bool jigSnow = (jigSet & 2) == 2;
            bool jigJungle = (jigSet & 4) == 4;
            bool jigHell = (jigSet & 8) == 8;

            int quest = Main.anglerQuest;
            bool specialty = (baitType == ModContent.ItemType<Items.Bait.SpecialBait>());
            bool questFishInInventory = false;
            if (specialty)
			{
                for (int i = 0; i <= 49; i++) //main player inventory
                {
					if ((Main.LocalPlayer.inventory[i]).type == quest)   questFishInInventory = true; //TODO: test it!
                }
            }


            if (!attempt.inLava && !attempt.inHoney) // attempt takes place in water
			{
				if(attempt.heightLevel < 2)
				{

					if(fPower < Main.rand.Next(-80, 420))   itemDrop = ModContent.ItemType<Items.Bait.Guppy>();

					if(Player.ZoneRain)
					{
						if(Chance.OneOut(8))   itemDrop = ModContent.ItemType<Items.Fish.Flyfish>();
					}
				}

				if(Player.ZoneSnow)
				{
					if(Main.hardMode && RarityCheck(fPower, 4))   itemDrop = ModContent.ItemType<Items.Fish.Sturgeon>();

					if(jigSnow && attempt.heightLevel > 1 && RarityCheck(fPower, 5))   itemDrop = ItemID.Fish;
					if(jigSnow && fPower > 100 && RarityCheck(fPower, 7f))   itemDrop = ModContent.ItemType<Items.Misc.OldScale>();
					if(Main.hardMode && RarityCheck(fPower, 10f))   itemDrop = ItemID.FrozenKey;
				}

                if (Player.ZoneJungle) {

					if(itemDrop == ItemID.Bass)   itemDrop = ModContent.ItemType<Items.Fish.Sardine>();

					if(attempt.heightLevel == 1)
					{
						if(!Main.dayTime && RarityCheck(fPower, 3))   itemDrop = ModContent.ItemType<Items.Fish.Whiskeyfish>();
						if(jigJungle && RarityCheck(fPower, 4))   itemDrop = ModContent.ItemType<Items.Fish.Whiskeyfish>();
					}

					if(jigJungle && RarityCheck(fPower, 5))
					{
						itemDrop = ModContent.ItemType<Items.Misc.CrocTooth>();
						if(attempt.heightLevel > 1 && Chance.OneOut(2))   itemDrop = ItemID.Seaweed;
					}
					if(jigJungle && fPower > 300 && RarityCheck(fPower, 7))   itemDrop = ModContent.ItemType<Items.Misc.OldEye>();
					if(Main.hardMode && RarityCheck(fPower, 10))   itemDrop = ItemID.JungleKey;
				}

				if(Player.ZoneBeach)
				{
					if(Main.hardMode && RarityCheck(fPower, 4))   itemDrop = ModContent.ItemType<Items.Fish.Lobster>();
					if(jigOcean && RarityCheck(fPower, 5))   itemDrop = ModContent.ItemType<Items.Fish.Boxfish>();
					if(RarityCheck(fPower, 7))   itemDrop = ModContent.ItemType<Items.Misc.WaywardBottle>();
					if(jigOcean && fPower > 200 && RarityCheck(fPower, 7))   itemDrop = ModContent.ItemType<Items.Misc.OldFin>();
				}
				else if(Player.ZoneDesert)
				{
					if(itemDrop == ItemID.Bass)   itemDrop = ModContent.ItemType<Items.Fish.Flounder>();
					if(RarityCheck(fPower, 3))   itemDrop = ModContent.ItemType<Items.Fish.DesertEel>();
					if(Main.hardMode && RarityCheck(fPower, 5))   itemDrop = ModContent.ItemType<Items.Fish.SandShark>();
				}

                if (Player.ZoneCorrupt)
				{
					if(Main.hardMode && RarityCheck(fPower, 10))   itemDrop = ItemID.CorruptionKey;
				}

				if(Player.ZoneCrimson)
				{
					if(Main.hardMode && RarityCheck(fPower, 10))   itemDrop = ItemID.CrimsonKey;
					}

				if(Player.ZoneHallow)
				{
					if(RarityCheck(fPower, 5))   itemDrop = ModContent.ItemType<Items.Fish.Glittergill>();
					if(Main.hardMode && RarityCheck(fPower, 10))   itemDrop = ItemID.HallowedKey;
				}

				if(Player.ZoneMeteor)
				{
					if(RarityCheck(fPower, 5))   itemDrop = ModContent.ItemType<Items.Fish.Spacefish>();
				}

				if(Player.ZoneGlowshroom)
				{
					if(itemDrop == ItemID.Bass)   itemDrop = ModContent.ItemType<Items.Fish.Clusterfish>();
					if(Main.hardMode && RarityCheck(fPower, 4))   itemDrop = ModContent.ItemType<Items.Fish.Venomfish>();
					if(RarityCheck(fPower, 5))   itemDrop = ModContent.ItemType<Items.Fish.Mushfin>();
					if(RarityCheck(fPower, 6))   itemDrop = ModContent.ItemType<Items.Tools.Sporetooth>();
				}

				if(Player.ZoneDungeon)
				{
					if(itemDrop == ItemID.Bass)   itemDrop = ModContent.ItemType<Items.Fish.Coelacanth>();
					if(Chance.OneOut(4))   itemDrop = ModContent.ItemType<Items.Fish.Gamifish>();
					if(RarityCheck(fPower, 4))   itemDrop = ModContent.ItemType<Items.Fish.Angling>();
					if(RarityCheck(fPower, 5))   itemDrop = ModContent.ItemType<Items.Fish.Anglerfish>();
				}

				if(Player.ZoneSkyHeight)
				{
					if(Main.hardMode && RarityCheck(fPower, 5))   itemDrop = ModContent.ItemType<Items.Misc.PrettyGuppy>();
				}

				if(Player.ZoneTowerSolar || Player.ZoneTowerVortex || Player.ZoneTowerNebula || Player.ZoneTowerStardust)
				{
					if(RarityCheck(fPower, 5))   itemDrop = ModContent.ItemType<Items.Plankton>();
				}

                if (specialty && !questFishInInventory && Chance.OneOut(4))
				{
                    if (Player.ZoneSnow)
					{
						if (attempt.heightLevel == 1)
						{
							if (quest == ItemID.Pengfish || quest == ItemID.TundraTrout)   itemDrop = quest;
						}
						if (attempt.heightLevel > 1)
						{
							if (quest == ItemID.MutantFlinxfin || quest == ItemID.Fishron)   itemDrop = quest;
						}
					}
					else if (Player.ZoneJungle)
					{
						if (quest == ItemID.Mudfish) itemDrop = quest;
						if (attempt.heightLevel == 1)
						{
							if (quest == ItemID.Catfish || quest == ItemID.Derpfish || quest == ItemID.TropicalBarracuda) itemDrop = quest;
						}
					}
					else if (Player.ZoneBeach)
					{
						if (quest == ItemID.CapnTunabeard || quest == ItemID.Clownfish) itemDrop = quest;
					}
					else if (Player.ZoneGlowshroom)
					{
						if (quest == ItemID.AmanitaFungifin) itemDrop = quest;
					}
					else if (Player.ZoneCorrupt)
					{
						if (quest == ItemID.Cursedfish || quest == ItemID.EaterofPlankton || quest == ItemID.InfectedScabbardfish) itemDrop = quest;
					}
					else if (Player.ZoneCrimson)
					{
						if (quest == ItemID.Ichorfish || quest == ItemID.BloodyManowar) itemDrop = quest;
					}
					else if (Player.ZoneHallow)
					{
						if (quest == ItemID.MirageFish || quest == ItemID.Pixiefish || quest == ItemID.UnicornFish) itemDrop = quest;
					}
					else if (attempt.heightLevel < 2)
					{
						if (quest == ItemID.FallenStarfish || quest == ItemID.TheFishofCthulu || quest == ItemID.Harpyfish || quest == ItemID.Wyverntail || quest == ItemID.Slimefish) itemDrop = quest;
						if (attempt.heightLevel == 0)
						{
							if (quest == ItemID.Cloudfish || quest == ItemID.Angelfish) itemDrop = quest;
						}
						if (attempt.heightLevel == 1)
						{
							if (quest == ItemID.Dirtfish || quest == ItemID.DynamiteFish || quest == ItemID.ZombieFish || quest == ItemID.Bunnyfish) itemDrop = quest;
						}
					}
					else
					{
						if (quest == ItemID.Batfish || quest == ItemID.Hungerfish || quest == ItemID.Jewelfish || quest == ItemID.Spiderfish || quest == ItemID.Bonefish) itemDrop = quest;
						if (attempt.heightLevel == 2)
						{
							if (quest == ItemID.Dirtfish) itemDrop = quest;
						}
					}
				}
			}

            if (attempt.inLava)
			{
                if (Chance.OneOut(4))   itemDrop = ModContent.ItemType<Items.Fish.RedHerring>();
                if (jigHell && RarityCheck(fPower, 4)) itemDrop = ModContent.ItemType<Items.Fish.LavaEel>();
                if (fPower > 100 && RarityCheck(fPower, 8)) itemDrop = ModContent.ItemType<Items.Fish.Pupfish>();
            }

			if(attempt.inHoney)
			{
                if (Chance.OneOut(4))   itemDrop = ModContent.ItemType<Items.Food.Sweetglub>();
                if (RarityCheck(fPower, 5)) itemDrop = ModContent.ItemType<Items.Weapons.HivePuffer>();
                if (RarityCheck(fPower, 6)) itemDrop = ModContent.ItemType<Items.Bait.GoldJelly>();

                if (specialty && !questFishInInventory && Chance.OneOut(4))
				{
					if(quest == ItemID.BumblebeeTuna)   itemDrop = quest;
				}
			}
		}

		public override void AnglerQuestReward(float rareMultiplier, List<Item> rewardItems)
		{
			int complete = Player.anglerQuestsFinished;
			if(complete == 1 || Chance.OneOut(40))
			{
				Item pole = new Item();
				pole.SetDefaults(ModContent.ItemType<Items.Poles.JuniorPole>());
				rewardItems.Add(pole);
			}
			if(complete >= 10)
			{
				if(Chance.OneOut(8))
				{
					Item bait = new Item();
					bait.SetDefaults(ModContent.ItemType<Items.Bait.SpecialBait>());
					bait.stack = (int)(1.0f / rareMultiplier) + Main.rand.Next(5);
					rewardItems.Add(bait);
				}
				if(Chance.OneOut(16))
				{
					Item ticket = new Item();
					ticket.SetDefaults(ModContent.ItemType<Items.QuestTicket>());
					rewardItems.Add(ticket);
				}
			}
			if(complete >= 100)
			{
				if(complete == 100 || Chance.OneOut(100))
				{
					Item pole = new Item();
					pole.SetDefaults(ModContent.ItemType<Items.Poles.XolaRod>());
					rewardItems.Add(pole);
				}
			}
		}
	}
}