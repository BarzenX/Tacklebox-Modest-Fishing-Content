using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Tacklebox.Items._Global;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox
{

    public class TackleboxPlayer : ModPlayer
    {
        public int GlobalBait;

        /// <summary>
        /// Status of the used jigs. Each bit marks an equipped jig --> int values   1=SeaJig, 2=SnowJigh, 4=JungleJig, 8=HellJig, 16=CoinHook
        /// </summary>
        public int JigSet;

        /// <summary>
        /// The number of lines being cast when using a fishing pole
        /// </summary>
        public int LineCount;

        /// <summary>
        /// The tier level of the equipped reel. The higher the tier, the bigger the chance of getting more than 1 crate when fishing
        /// </summary>
        public int ReelTier;

        /// <summary>
        /// The tier level of the equipped hook. Each level increases fishing power by 5
        /// </summary>
        public int HookTier;

        public override void ResetEffects()
        {
            JigSet = 0;
            LineCount = 1;
            ReelTier = 0;
            HookTier = 0;
        }

        public override void GetFishingLevel(Item fishingRod, Item bait, ref float fishingLevel)  // fishingLevel is in %! --> "+5 fishing power" = 0.05f
        {
            if (Player.FindBuffIndex(ModContent.BuffType<Buffs.BigFishing>()) != -1)
            {
                fishingLevel += 0.23f;
                if (Player.FindBuffIndex(BuffID.Fishing) != -1) fishingLevel -= 0.15f; //TODO: in theory it's 0.15 but fishingLevel seems to be already affected by daytime...so in this compensation value would need to differ as well!
            }

            if (HookTier > 0)
            {
                fishingLevel += 0.05f;
                if (HookTier > 1) fishingLevel += 0.05f;
            }

            if (fishingRod.type == ModContent.ItemType<Items.Poles.XolaRod>()) fishingLevel += bait.bait;

            else if (fishingRod.type == ModContent.ItemType<Items.Poles.GemRod>())
            {
                fishingLevel /= 2f;
                if (bait.type == ModContent.ItemType<Items.Bait.CrabClaw>())   fishingLevel += 0.40f;
            }

            else if (fishingRod.type == ModContent.ItemType<Items.Poles.TheZodiac>())
            {
                if (Main.moonPhase == 0) fishingLevel *= 1.20f;
                if (Main.moonPhase == 1 || Main.moonPhase == 7) fishingLevel *= 1.10f;
                // moonPhase 2 || 6 --> 100%
                if (Main.moonPhase == 3 || Main.moonPhase == 5) fishingLevel *= 0.90f;
                if (Main.moonPhase == 4) fishingLevel *= 0.80f;
            }
        }

        #region Rarity Checks
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
            if (cQual > 5) RarityCheck(fPow, (float)cQual); //to prevent user errors

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
                default: return false;
            }

            return Chance.Perc2(1 / Math.Max(cQual + 1f, baseVal / fPow)); // Max( capped chance, fishpower chance)
            //Old math: return Chance.OneOut( (int)Math.Max( (cQual + 1), (150 * ((1 << cQual) - 1) / fPow) )); // MAX( (diff + 1) , 150 * ((2^diff)-1) / fishingPower) )
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

            return Chance.Perc2(1 / Math.Max((float)cQual + 1f, baseVal / fPow)); // Max( capped chance, fishpower chance)
        }

        #endregion


        public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition)
        {
            int baitType = attempt.playerFishingConditions.Bait.type;
            GlobalBait = baitType;
            int fRodType = attempt.playerFishingConditions.PoleItemType;
            int fPower = attempt.playerFishingConditions.FinalFishingLevel;

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
            if (fRodType == ModContent.ItemType<Items.Poles.GemRod>())
            {

                if (RarityCheck(fPower, 5f)) itemDrop = ItemID.Diamond;
                else if (RarityCheck(fPower, 4.5f)) itemDrop = ItemID.Ruby;
                else if (RarityCheck(fPower, 4f)) itemDrop = ItemID.Emerald;
                else if (RarityCheck(fPower, 3.5f)) itemDrop = ItemID.Sapphire;
                else if (RarityCheck(fPower, 3f)) itemDrop = ItemID.Topaz;
                else if (RarityCheck(fPower, 2f))
                {
                    if (Player.ZoneDesert) itemDrop = ItemID.Amber;
                    else itemDrop = ItemID.Amethyst;
                }
                else if (RarityCheck(fPower, 1f))
                {
                    if (Player.ZoneDesert) itemDrop = ItemID.DesertFossil;
                    else if (Player.ZoneSnow) itemDrop = ItemID.SlushBlock;
                    else itemDrop = ItemID.SiltBlock;
                }
                else
                {
                    itemDrop = junk[Main.rand.Next(junk.Length)];
                }

                //TODO: add something to the other zones? No real idea what...
                return;
            }
            #endregion

            #region Bonus crates
            if (Tacklebox.allCrates.Contains(itemDrop)) //the to-be-fished itemDrop would be a crate
            {
                int upgradeCrateChance = ReelTier * 10;
                if (Player.FindBuffIndex(ModContent.BuffType<Buffs.BigCrate>()) != -1)
                {
                    if (Player.FindBuffIndex(BuffID.Crate) != -1) upgradeCrateChance += 10; // the two buffs shall not stack
                    else                                          upgradeCrateChance += 18;
                }

                if (Chance.Perc((float)upgradeCrateChance +5f))
                {
                    if ((itemDrop == ItemID.WoodenCrate || itemDrop == ItemID.WoodenCrateHard) && // only wooden crates get upgraded into iron ones (or else it could be a downgrade)
                        (RarityCheck(fPower, 1)) )
                    {
                        itemDrop = ItemID.IronCrate;
                        if (Main.hardMode) itemDrop = ItemID.IronCrateHard;
                    }

                    if ((itemDrop == ItemID.IronCrate || itemDrop == ItemID.IronCrateHard) && // only iron crates can get upgraded into golden ones (or else it could be a downgrade)
                        (RarityCheck(fPower, 1.5f)) )
                    {
                        itemDrop = ItemID.GoldenCrate;
                        if (Main.hardMode) itemDrop = ItemID.GoldenCrateHard;
                    }

                    if ((itemDrop == ItemID.GoldenCrate || itemDrop == ItemID.GoldenCrateHard) && // only golden chests can get upgraded into biome crates (or else it could be a downgrade)
                        (RarityCheck(fPower, 2f)))
                    {
                        if (Player.ZoneJungle)
                        {
                            itemDrop = ItemID.JungleFishingCrate;
                            if (Main.hardMode) itemDrop = ItemID.JungleFishingCrateHard;
                        }

                        else if (attempt.heightLevel == 0)
                        {
                            itemDrop = ItemID.FloatingIslandFishingCrate;
                            if (Main.hardMode) itemDrop = ItemID.FloatingIslandFishingCrateHard;
                        }

                        else if (Player.ZoneCorrupt)
                        {
                            itemDrop = ItemID.CorruptFishingCrate;
                            if (Main.hardMode) itemDrop = ItemID.CorruptFishingCrateHard;
                        }

                        else if (Player.ZoneCrimson)
                        {
                            itemDrop = ItemID.CrimsonFishingCrate;
                            if (Main.hardMode) itemDrop = ItemID.CrimsonFishingCrateHard;
                        }

                        else if (Player.ZoneHallow)
                        {
                            itemDrop = ItemID.HallowedFishingCrate;
                            if (Main.hardMode) itemDrop = ItemID.HallowedFishingCrateHard;
                        }

                        else if (Player.ZoneDungeon)
                        {
                            itemDrop = ItemID.DungeonFishingCrate;
                            if (Main.hardMode) itemDrop = ItemID.DungeonFishingCrateHard;
                        }

                        else if (Player.ZoneSnow)
                        {
                            itemDrop = ItemID.FrozenCrate;
                            if (Main.hardMode) itemDrop = ItemID.FrozenCrateHard;
                        }

                        else if (Player.ZoneDesert)
                        {
                            itemDrop = ItemID.OasisCrate;
                            if (Main.hardMode) itemDrop = ItemID.OasisCrateHard;
                        }

                        else if (Player.ZoneUnderworldHeight)
                        {
                            itemDrop = ItemID.LavaCrate;
                            if (Main.hardMode) itemDrop = ItemID.LavaCrateHard;
                        }

                        else if (Player.ZoneBeach)
                        {
                            itemDrop = ItemID.OceanCrate;
                            if (Main.hardMode) itemDrop = ItemID.OceanCrateHard;
                        }

                        else if (Player.ZoneForest)
                        {
                            itemDrop = ModContent.ItemType<Items.Crates.GemCrate>();
                        }
                    }
                }
                return;
            }
            #endregion






            bool jigSea = JigID.CheckJig(JigSet, JigID.SeaJig);
            bool jigSnow = JigID.CheckJig(JigSet, JigID.SnowJig);
            bool jigJungle = JigID.CheckJig(JigSet, JigID.JungleJig);
            bool jigHell = JigID.CheckJig(JigSet, JigID.HellJig);

            int questFishID = Main.anglerQuestItemNetIDs[Main.anglerQuest];
            bool specialty = baitType == ModContent.ItemType<Items.Bait.SpecialBait>();
            bool questFishInInventory = false;
            if (specialty)
            {
                for (int i = 0; i <= 49; i++) //main player inventory
                {
                    if (Main.LocalPlayer.inventory[i].type == questFishID) questFishInInventory = true;
                }
            }


            if (!attempt.inLava && !attempt.inHoney) // attempt takes place in water
            {
                if (attempt.heightLevel < 2)
                {
                    if (RarityCheck(fPower, 2f)) itemDrop = ModContent.ItemType<Items.Bait.Guppy>();

                    if (Player.ZoneRain)
                    {
                        if (RarityCheck(fPower, 2f)) itemDrop = ModContent.ItemType<Items.Fish.Flyfish>();
                    }
                }

                if (Player.ZoneSnow)
                {
                    if (Main.hardMode && RarityCheck(fPower, 4)) itemDrop = ModContent.ItemType<Items.Fish.Sturgeon>();

                    if (jigSnow && attempt.heightLevel > 1 && RarityCheck(fPower, 5)) itemDrop = ItemID.Fish;
                    if (jigSnow && fPower > 100 && RarityCheck(fPower, 7f)) itemDrop = ModContent.ItemType<Items.Misc.OldScale>();
                    if (Main.hardMode && RarityCheck(fPower, 8f)) itemDrop = ItemID.FrozenKey;
                }

                if (Player.ZoneJungle)
                {

                    if (itemDrop == ItemID.Bass) itemDrop = ModContent.ItemType<Items.Fish.Sardine>();

                    if (attempt.heightLevel == 1)
                    {
                        if (!Main.dayTime && RarityCheck(fPower, 3)) itemDrop = ModContent.ItemType<Items.Fish.Whiskeyfish>();
                        if (jigJungle && RarityCheck(fPower, 4)) itemDrop = ModContent.ItemType<Items.Fish.Whiskeyfish>();
                    }

                    if (jigJungle && RarityCheck(fPower, 5))
                    {
                        itemDrop = ModContent.ItemType<Items.Misc.CrocTooth>();
                        if (attempt.heightLevel > 1 && Chance.OneOut(2)) itemDrop = ItemID.Seaweed;
                    }
                    if (jigJungle && fPower > 300 && RarityCheck(fPower, 7)) itemDrop = ModContent.ItemType<Items.Misc.OldEye>();
                    if (Main.hardMode && RarityCheck(fPower, 8f)) itemDrop = ItemID.JungleKey;
                }

                if (Player.ZoneBeach)
                {
                    if (Main.hardMode && RarityCheck(fPower, 4)) itemDrop = ModContent.ItemType<Items.Fish.Lobster>();
                    if (jigSea && RarityCheck(fPower, 5)) itemDrop = ModContent.ItemType<Items.Fish.Boxfish>();
                    if (RarityCheck(fPower, 7)) itemDrop = ModContent.ItemType<Items.Misc.WaywardBottle>();
                    if (jigSea && fPower > 200 && RarityCheck(fPower, 7)) itemDrop = ModContent.ItemType<Items.Misc.OldFin>();
                }
                else if (Player.ZoneDesert)
                {
                    if (itemDrop == ItemID.Bass) itemDrop = ModContent.ItemType<Items.Fish.Flounder>();
                    if (RarityCheck(fPower, 3)) itemDrop = ModContent.ItemType<Items.Fish.DesertEel>();
                    if (Main.hardMode && RarityCheck(fPower, 5)) itemDrop = ModContent.ItemType<Items.Fish.SandShark>();
                }

                if (Player.ZoneCorrupt)
                {
                    if (Main.hardMode && RarityCheck(fPower, 8f)) itemDrop = ItemID.CorruptionKey;
                }

                if (Player.ZoneCrimson)
                {
                    if (Main.hardMode && RarityCheck(fPower, 8f)) itemDrop = ItemID.CrimsonKey;
                }

                if (Player.ZoneHallow)
                {
                    if (RarityCheck(fPower, 5)) itemDrop = ModContent.ItemType<Items.Fish.Glittergill>();
                    if (Main.hardMode && RarityCheck(fPower, 8f)) itemDrop = ItemID.HallowedKey;
                }

                if (Player.ZoneMeteor)
                {
                    if (RarityCheck(fPower, 5)) itemDrop = ModContent.ItemType<Items.Fish.Spacefish>();
                }

                if (Player.ZoneGlowshroom)
                {
                    if (itemDrop == ItemID.Bass) itemDrop = ModContent.ItemType<Items.Fish.Clusterfish>();
                    if (Main.hardMode && RarityCheck(fPower, 4)) itemDrop = ModContent.ItemType<Items.Fish.Venomfish>();
                    if (RarityCheck(fPower, 5)) itemDrop = ModContent.ItemType<Items.Fish.Mushfin>();
                    if (RarityCheck(fPower, 6)) itemDrop = ModContent.ItemType<Items.Tools.Sporetooth>();
                }

                if (Player.ZoneDungeon)
                {
                    if (itemDrop == ItemID.Bass) itemDrop = ModContent.ItemType<Items.Fish.Coelacanth>();
                    if (Chance.OneOut(4)) itemDrop = ModContent.ItemType<Items.Fish.Gamifish>();
                    if (RarityCheck(fPower, 4)) itemDrop = ModContent.ItemType<Items.Fish.Angling>();
                    if (RarityCheck(fPower, 5)) itemDrop = ModContent.ItemType<Items.Fish.Anglerfish>();
                }

                if (Player.ZoneSkyHeight)
                {
                    if (Main.hardMode && RarityCheck(fPower, 5)) itemDrop = ModContent.ItemType<Items.Misc.PrettyGuppy>();
                }

                if (Player.ZoneTowerSolar || Player.ZoneTowerVortex || Player.ZoneTowerNebula || Player.ZoneTowerStardust)
                {
                    if (RarityCheck(fPower, 5)) itemDrop = ModContent.ItemType<Items.Plankton>();
                }

                //Questfish
                if (specialty && Chance.OneOut(4)) //TODO: maybe add "&& !questFishInInventory" ?
                {
                    if (Player.ZoneSnow)
                    {
                        if (attempt.heightLevel == 1)
                        {
                            if (questFishID == ItemID.Pengfish || questFishID == ItemID.TundraTrout) itemDrop = questFishID;
                        }
                        if (attempt.heightLevel > 1)
                        {
                            if (questFishID == ItemID.MutantFlinxfin || questFishID == ItemID.Fishron) itemDrop = questFishID;
                        }
                    }
                    else if (Player.ZoneJungle)
                    {
                        if (questFishID == ItemID.Mudfish) itemDrop = questFishID;
                        if (attempt.heightLevel == 1)
                        {
                            if (questFishID == ItemID.Catfish || questFishID == ItemID.Derpfish || questFishID == ItemID.TropicalBarracuda) itemDrop = questFishID;
                        }
                    }
                    else if (Player.ZoneBeach)
                    {
                        if (questFishID == ItemID.CapnTunabeard || questFishID == ItemID.Clownfish) itemDrop = questFishID;
                    }
                    else if (Player.ZoneGlowshroom)
                    {
                        if (questFishID == ItemID.AmanitaFungifin) itemDrop = questFishID;
                    }
                    else if (Player.ZoneCorrupt)
                    {
                        if (questFishID == ItemID.Cursedfish || questFishID == ItemID.EaterofPlankton || questFishID == ItemID.InfectedScabbardfish) itemDrop = questFishID;
                    }
                    else if (Player.ZoneCrimson)
                    {
                        if (questFishID == ItemID.Ichorfish || questFishID == ItemID.BloodyManowar) itemDrop = questFishID;
                    }
                    else if (Player.ZoneHallow)
                    {
                        if (questFishID == ItemID.MirageFish || questFishID == ItemID.Pixiefish || questFishID == ItemID.UnicornFish) itemDrop = questFishID;
                    }
                    else if (attempt.heightLevel < 2)
                    {
                        if (questFishID == ItemID.FallenStarfish || questFishID == ItemID.TheFishofCthulu || questFishID == ItemID.Harpyfish || questFishID == ItemID.Wyverntail || questFishID == ItemID.Slimefish) itemDrop = questFishID;
                        if (attempt.heightLevel == 0)
                        {
                            if (questFishID == ItemID.Cloudfish || questFishID == ItemID.Angelfish) itemDrop = questFishID;
                        }
                        if (attempt.heightLevel == 1)
                        {
                            if (questFishID == ItemID.Dirtfish || questFishID == ItemID.DynamiteFish || questFishID == ItemID.ZombieFish || questFishID == ItemID.Bunnyfish) itemDrop = questFishID;
                        }
                    }
                    else
                    {
                        if (questFishID == ItemID.Batfish || questFishID == ItemID.Hungerfish || questFishID == ItemID.Jewelfish || questFishID == ItemID.Spiderfish || questFishID == ItemID.Bonefish) itemDrop = questFishID;
                        if (attempt.heightLevel == 2)
                        {
                            if (questFishID == ItemID.Dirtfish) itemDrop = questFishID;
                        }
                    }
                }
            }

            if (attempt.inLava)
            {
                if (Chance.OneOut(4)) itemDrop = ModContent.ItemType<Items.Fish.RedHerring>();
                if (jigHell && RarityCheck(fPower, 4)) itemDrop = ModContent.ItemType<Items.Fish.LavaEel>();
                if (fPower > 100 && RarityCheck(fPower, 8)) itemDrop = ModContent.ItemType<Items.Fish.Pupfish>();
            }

            if (attempt.inHoney)
            {
                if (Chance.OneOut(4)) itemDrop = ModContent.ItemType<Items.Food.Sweetglub>();
                if (RarityCheck(fPower, 5)) itemDrop = ModContent.ItemType<Items.Weapons.HivePuffer>();
                if (RarityCheck(fPower, 6)) itemDrop = ModContent.ItemType<Items.Bait.GoldJelly>();

                if (specialty && Chance.OneOut(4))  //TODO: maybe add "&& !questFishInInventory" ?
                {
                    if (questFishID == ItemID.BumblebeeTuna) itemDrop = questFishID;
                }
            }
        }

        public override void AnglerQuestReward(float rareMultiplier, List<Item> rewardItems)
        {
            int complete = Player.anglerQuestsFinished;
            if (complete == 1 || Chance.OneOut(40))
            {
                Item pole = new();
                pole.SetDefaults(ModContent.ItemType<Items.Poles.JuniorPole>());
                rewardItems.Add(pole);
            }
            if (complete >= 10)
            {
                if (Chance.OneOut(8))
                {
                    Item bait = new();
                    bait.SetDefaults(ModContent.ItemType<Items.Bait.SpecialBait>());
                    bait.stack = (int)(1.0f / rareMultiplier) + Main.rand.Next(5);
                    rewardItems.Add(bait);
                }
                if (Chance.OneOut(16))
                {
                    Item ticket = new();
                    ticket.SetDefaults(ModContent.ItemType<Items.QuestTicket>());
                    rewardItems.Add(ticket);
                }
            }
            if (complete >= 100)
            {
                if (complete == 100 || Chance.OneOut(100))
                {
                    Item pole = new();
                    pole.SetDefaults(ModContent.ItemType<Items.Poles.XolaRod>());
                    rewardItems.Add(pole);
                }
            }
        }

        
        //credit to "direwolf420" a.k.a "Putan#1022" from tModLoader discord channel
        public override void Load()
        {
            On_Projectile.AI_061_FishingBobber_GiveItemToPlayer += On_Projectile_AI_061_FishingBobber_GiveItemToPlayer;
        }

        private bool recursive = false;

        private void On_Projectile_AI_061_FishingBobber_GiveItemToPlayer(On_Projectile.orig_AI_061_FishingBobber_GiveItemToPlayer orig, Projectile self, Player thePlayer, int itemType)
        {
            orig(self, thePlayer, itemType);

            if (!recursive && ItemID.Sets.IsFishingCrate[itemType])
            {
                try
                {
                    if (Chance.Perc(ReelTier*2 + 1)) // put any type of condition here like "the Player has some accessory equipped that enables this" or whatever
                    {
                        //Main.NewText($"dropped another item");
                        //Drop another item (change itemType to something else if you don't want the same item twice)
                        recursive = true;
                        orig(self, thePlayer, itemType);
                    }
                }
                finally
                {
                    recursive = false;
                }
            }
        }
    }
}