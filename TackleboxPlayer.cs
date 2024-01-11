using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox {

	public class TackleboxPlayer : ModPlayer {

		public int bait = 0;
		public int jigSet = 0;
		public int lineCount = 1;
		public int reelValue = 0;
		public int hookValue = 0;
		public bool sonar = false;
		public bool sizzLine = false;

		public override void ResetEffects() {
			jigSet = 0;
			lineCount = 1;
			reelValue = 0;
			hookValue = 0;
			sonar = Player.HasItem(Mod.Find<ModItem>("SonarStick").Type);
			if(sizzLine) {
				sizzLine = false;
				foreach(int pole in Tacklebox.noLava) {
					ItemID.Sets.CanFishInLava[pole] = false;
					}
				}
			}

		public override void PostUpdateBuffs() {
			if(!Player.sonarPotion) {
				Player.sonarPotion = sonar;
				}
			}

		public override void GetFishingLevel(Item fishingRod, Item bait, ref int fishingLevel) {
			if(Player.FindBuffIndex(Mod.Find<ModBuff>("BigFishing").Type) != -1) {
				fishingLevel += 22;
				if(Player.FindBuffIndex(121) != -1) {
					fishingLevel -= 15;
					}
				}
			if(hookValue > 0) {
				fishingLevel += 5;
				if(hookValue > 1) {
					fishingLevel += 5;
					}
				}
			if(fishingRod.type == Mod.Find<ModItem>("XolaRod").Type) {
				fishingLevel += bait.bait;
				}
			else if(fishingRod.type == Mod.Find<ModItem>("GemRod").Type) {
				fishingLevel /= 2;
				if(bait.type == Mod.Find<ModItem>("CrabClaw").Type) {
					fishingLevel += 20;
					}
				}
			else if(fishingRod.type == Mod.Find<ModItem>("TheZodiac").Type) {
				if(Main.moonPhase == 0) {
					fishingLevel = (int)(fishingLevel * 1.20f);
					}
				if(Main.moonPhase == 1 || Main.moonPhase == 7) {
					fishingLevel = (int)(fishingLevel * 1.10f);
					}
				if(Main.moonPhase == 3 || Main.moonPhase == 5) {
					fishingLevel = (int)(fishingLevel * 0.90f);
					}
				if(Main.moonPhase == 4) {
					fishingLevel = (int)(fishingLevel * 0.80f);
					}
				}
			}

		public bool RarityCheck(int power, int i) {
			return Main.rand.Next(Math.Max(i + 1, 150 * ((1 << i) - 1) / power)) == 0;
			}

		public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition) {
			this.bait = bait.type;
			if(junk) {
				int newJunk = Main.rand.Next(6);
				if(newJunk == 0) {
					caughtType = Mod.Find<ModItem>("Cassette").Type;
					}
				else if(newJunk == 1) {
					caughtType = Mod.Find<ModItem>("Driftwood").Type;
					}
				else if(newJunk == 2) {
					caughtType = Mod.Find<ModItem>("BrokenPDA").Type;
					}
				return;
				}
			if(fishingRod.type == Mod.Find<ModItem>("GemRod").Type) {
				caughtType = 3;
				if(Player.ZoneDesert) {
					caughtType = 169;
					if(RarityCheck(power, 1)) {
						caughtType = 3347;
						}
					if(RarityCheck(power, 2)) {
						caughtType = 999;
						}
					}
				if(RarityCheck(power, 2)) {
					caughtType = 181;
					}
				if(RarityCheck(power, 3)) {
					caughtType = 180;
					}
				if(RarityCheck(power, 4)) {
					caughtType = 177;
					}
				if(RarityCheck(power, 5)) {
					caughtType = 179;
					}
				if(RarityCheck(power, 6)) {
					caughtType = 178;
					}
				if(RarityCheck(power, 7)) {
					caughtType = 182;
					}
				return;
				}
			int quest = Main.anglerQuest;
			bool jigOcean = (jigSet & 1) == 1;
			bool jigSnow = (jigSet & 2) == 2;
			bool jigJungle = (jigSet & 4) == 4;
			bool jigHell = (jigSet & 8) == 8;
			bool specialty = bait.type == Mod.Find<ModItem>("SpecialBait").Type;
			if(System.Array.IndexOf(Tacklebox.allCrates) == -1) {
				int bonusCrate = reelValue * 5;
				if(Player.FindBuffIndex(Mod.Find<ModBuff>("BigCrate").Type) != -1) {
					bonusCrate += 17;
					if(Player.FindBuffIndex(123) != -1) {
						bonusCrate -= 10;
						}
					}
				if(bonusCrate > Main.rand.Next(100)) {
					caughtType = 2334;
					if(RarityCheck(power, 3)) {
						caughtType = 2335;
						}
					if(RarityCheck(power, 4)) {
						caughtType = 2336;
						}
					}
				}
			if(System.Array.IndexOf(Tacklebox.allCrates) != -1) {
				int type = System.Array.IndexOf(Tacklebox.basicCrates);
				if(type != -1) {
					if(RarityCheck(power, type + 1)) {
						if(worldLayer == 3) {
							caughtType = Mod.Find<ModItem>("GemCrate").Type;
							}
						}
					if(RarityCheck(power, type + 2)) {
						if(Player.ZoneSnow && liquidType == 0) {
							caughtType = Mod.Find<ModItem>("SnowCrate").Type;
							}
						else if(Player.ZoneBeach && liquidType == 0) {
							caughtType = Mod.Find<ModItem>("SeaCrate").Type;
							}
						else if(Player.ZoneDesert && liquidType == 0) {
							caughtType = Mod.Find<ModItem>("SandCrate").Type;
							}
						else if(Player.ZoneUnderworldHeight && liquidType == 1) {
							caughtType = Mod.Find<ModItem>("HellCrate").Type;
							}
						}
					}
				return;
				}
			if(liquidType == 0) {
				if(worldLayer < 2) {
					if(power < Main.rand.Next(-80, 420)) {
						caughtType = Mod.Find<ModItem>("Guppy").Type;
						}
					if(Player.ZoneRain) {
						if(Main.rand.Next(8) == 0) {
							caughtType = Mod.Find<ModItem>("Flyfish").Type;
							}
						}
					}
				if(Player.ZoneSnow) {
					if(Main.hardMode && RarityCheck(power, 4)) {
						caughtType = Mod.Find<ModItem>("Sturgeon").Type;
						}
					if(jigSnow && worldLayer > 1 && RarityCheck(power, 5)) {
						caughtType = 669;
						}
					if(jigSnow && power > 100 && RarityCheck(power, 7)) {
						caughtType = Mod.Find<ModItem>("OldScale").Type;
						}
					if(Main.hardMode && RarityCheck(power, 12)) {
						caughtType = 1537;
						}
					}
				if(Player.ZoneJungle) {
					if(caughtType == 2290) {
						caughtType = Mod.Find<ModItem>("Sardine").Type;
						}
					if(worldLayer == 1) {
						if(!Main.dayTime && RarityCheck(power, 3)) {
							caughtType = Mod.Find<ModItem>("Whiskeyfish").Type;
							}
						if(jigJungle && RarityCheck(power, 4)) {
							caughtType = Mod.Find<ModItem>("Whiskeyfish").Type;
							}
						}
					if(jigJungle && RarityCheck(power, 5)) {
						caughtType = Mod.Find<ModItem>("CrocTooth").Type;
						if(worldLayer > 1 && Main.rand.Next(2) == 0) {
							caughtType = 753;
							}
						}
					if(jigJungle && power > 300 && RarityCheck(power, 7)) {
						caughtType = Mod.Find<ModItem>("OldEye").Type;
						}
					if(Main.hardMode && RarityCheck(power, 12)) {
						caughtType = 1533;
						}
					}
				if(Player.ZoneBeach) {
					if(Main.hardMode && RarityCheck(power, 4)) {
						caughtType = Mod.Find<ModItem>("Lobster").Type;
						}
					if(jigOcean && RarityCheck(power, 5)) {
						caughtType = Mod.Find<ModItem>("Boxfish").Type;
						}
					if(RarityCheck(power, 7)) {
						caughtType = Mod.Find<ModItem>("MessageBottle").Type;
						}
					if(jigOcean && power > 200 && RarityCheck(power, 7)) {
						caughtType = Mod.Find<ModItem>("OldFin").Type;
						}
					}
				else if(Player.ZoneDesert) {
					if(caughtType == 2290) {
						caughtType = Mod.Find<ModItem>("Flounder").Type;
						}
					if(RarityCheck(power, 3)) {
						caughtType = Mod.Find<ModItem>("DesertEel").Type;
						}
					if(Main.hardMode && RarityCheck(power, 5)) {
						caughtType = Mod.Find<ModItem>("SandShark").Type;
						}
					}
				if(Player.ZoneCorrupt) {
					if(Main.hardMode && RarityCheck(power, 12)) {
						caughtType = 1534;
						}
					}
				if(Player.ZoneCrimson) {
					if(Main.hardMode && RarityCheck(power, 12)) {
						caughtType = 1535;
						}
					}
				if(Player.ZoneHallow) {
					if(RarityCheck(power, 5)) {
						caughtType = Mod.Find<ModItem>("Glittergill").Type;
						}
					if(Main.hardMode && RarityCheck(power, 12)) {
						caughtType = 1536;
						}
					}
				if(Player.ZoneMeteor) {
					if(RarityCheck(power, 5)) {
						caughtType = Mod.Find<ModItem>("Spacefish").Type;
						}
					}
				if(Player.ZoneGlowshroom) {
					if(caughtType == 2290) {
						caughtType = Mod.Find<ModItem>("Clusterfish").Type;
						}
					if(Main.hardMode && RarityCheck(power, 4)) {
						caughtType = Mod.Find<ModItem>("Venomfish").Type;
						}
					if(RarityCheck(power, 5)) {
						caughtType = Mod.Find<ModItem>("Mushfin").Type;
						}
					if(RarityCheck(power, 6)) {
						caughtType = Mod.Find<ModItem>("Sporetooth").Type;
						}
					}
				if(Player.ZoneDungeon) {
					if(caughtType == 2290) {
						caughtType = Mod.Find<ModItem>("Coelacanth").Type;
						}
					if(Main.rand.Next(4) == 0) {
						caughtType = Mod.Find<ModItem>("Gamifish").Type;
						}
					if(RarityCheck(power, 4)) {
						caughtType = Mod.Find<ModItem>("Angling").Type;
						}
					if(RarityCheck(power, 5)) {
						caughtType = Mod.Find<ModItem>("Anglerfish").Type;
						}
					}
				if(Player.ZoneSkyHeight) {
					if(Main.hardMode && RarityCheck(power, 5)) {
						caughtType = Mod.Find<ModItem>("PrettyGuppy").Type;
						}
					}
				if(Player.ZoneTowerSolar || Player.ZoneTowerVortex || Player.ZoneTowerNebula || Player.ZoneTowerStardust) {
					if(RarityCheck(power, 5)) {
						caughtType = Mod.Find<ModItem>("Plankton").Type;
						}
					}
				if(specialty && Main.rand.Next(4) == 0) {
					if(Player.ZoneSnow) {
						if(worldLayer == 1) {
							if(quest == 2467 || quest == 2470) {
								caughtType = quest;
								}
							}
						if(worldLayer > 1) {
							if(quest == 2466 || quest == 2484) {
								caughtType = quest;
								}
							}
						}
					else if(Player.ZoneJungle) {
						if(quest == 2486) {
							caughtType = quest;
							}
						if(worldLayer == 1) {
							if(quest == 2452 || quest == 2483 || quest == 2488) {
								caughtType = quest;
								}
							}
						}
					else if(Player.ZoneBeach) {
						if(quest == 2480 || quest == 2481) {
							caughtType = quest;
							}
						}
					else if(Player.ZoneGlowshroom) {
						if(quest == 2475) {
							caughtType = quest;
							}
						}
					else if(Player.ZoneCorrupt) {
						if(quest == 2454 || quest == 2457 || quest == 2485) {
							caughtType = quest;
							}
						}
					else if(Player.ZoneCrimson) {
						if(quest == 2463 || quest == 2477) {
							caughtType = quest;
							}
						}
					else if(Player.ZoneHallow) {
						if(quest == 2465 || quest == 2468 || quest == 2471) {
							caughtType = quest;
							}
						}
					else if(worldLayer < 2) {
						if(quest == 2458 || quest == 2459 || quest == 2461 || quest == 2473 || quest == 2487) {
							caughtType = quest;
							}
						if(worldLayer == 0) {
							if(quest == 2453 || quest == 2476) {
								caughtType = quest;
								}
							}
						if(worldLayer == 1) {
							if(quest == 2455 || quest == 2456 || quest == 2474 || quest == 2479) {
								caughtType = quest;
								}
							}
						}
					else {
						if(quest == 2450 || quest == 2462 || quest == 2464 || quest == 2469 || quest == 2478) {
							caughtType = quest;
							}
						if(worldLayer == 2) {
							if(quest == 2455) {
								caughtType = quest;
								}
							}
						}
					}
				}
			if(liquidType == 1) {
				if(Main.rand.Next(4) == 0) {
					caughtType = Mod.Find<ModItem>("RedHerring").Type;
					}
				if(jigHell && RarityCheck(power, 4)) {
					caughtType = Mod.Find<ModItem>("LavaEel").Type;
					}
				if(power > 100 && RarityCheck(power, 8)) {
					caughtType = Mod.Find<ModItem>("Pupfish").Type;
					}
				}
			if(liquidType == 2) {
				if(Main.rand.Next(3) == 0) {
					caughtType = Mod.Find<ModItem>("Sweetglub").Type;
					}
				if(RarityCheck(power, 5)) {
					caughtType = Mod.Find<ModItem>("HivePuffer").Type;
					}
				if(RarityCheck(power, 6)) {
					caughtType = Mod.Find<ModItem>("GoldJelly").Type;
					}
				if(specialty && Main.rand.Next(4) == 0) {
					if(quest == 2451) {
						caughtType = quest;
						}
					}
				}
			}

		public override void AnglerQuestReward(float rareMultiplier, List<Item> rewardItems) {
			int complete = Player.anglerQuestsFinished;
			if(complete == 1 || Main.rand.Next(40) == 0) {
				Item pole = new Item();
				pole.SetDefaults(Mod.Find<ModItem>("JuniorPole").Type);
				rewardItems.Add(pole);
				}
			if(complete >= 10) {
				if(Main.rand.Next(8) == 0) {
					Item bait = new Item();
					bait.SetDefaults(Mod.Find<ModItem>("SpecialBait").Type);
					bait.stack = (int)(1.0f / rareMultiplier) + Main.rand.Next(5);
					rewardItems.Add(bait);
					}
				if(Main.rand.Next(16) == 0) {
					Item ticket = new Item();
					ticket.SetDefaults(Mod.Find<ModItem>("QuestTicket").Type);
					rewardItems.Add(ticket);
					}
				}
			if(complete >= 100) {
				if(complete == 100 || Main.rand.Next(100) == 0) {
					Item pole = new Item();
					pole.SetDefaults(Mod.Find<ModItem>("XolaRod").Type);
					rewardItems.Add(pole);
					}
				}
			}
		}
	}