using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.NPCs {

	public class GlobalLoot : GlobalNPC {

		private static int[] anglerShop = new int[] {
			2355, 2354, 2356, 2674, 2675, 2676, 3032, 3031, 2494
			};
		private static int[] anglerShopQuests = new int[] {
			10, 20, 40, 10, 20, 40, 80, 80, 60
			};
		private static int[] anglerShopFlags = new int[] {
			0, 0, 0, 0, 0, 0, 1, 1, 3
			};

		public override void ModifyActiveShop(NPC npc, string shopName, Item[] items) {
			if(type == 369) {
				int quests = Main.player[Main.myPlayer].anglerQuestsFinished;
				for(int i = 0; i < anglerShop.Length; i++) {
					if(quests >= anglerShopQuests[i]) {
						if((anglerShopFlags[i] & 1) == 1 && !Main.hardMode) {
							continue;
							}
						if((anglerShopFlags[i] & 2) == 2 && !Main.raining) {
							continue;
							}
						shop.item[++nextSlot].SetDefaults(anglerShop[i]);
						}
					}
				}
			}

		public override void OnKill(NPC npc) {
			List<int> loot = new List<int>();
			if(npc.type == 67) {
				bool drop = true;
				if(npc.SpawnedFromStatue) {
					drop = Main.rand.Next(4) == 0;
					}
				if(drop) {
					loot.Add(Mod.Find<ModItem>("CrabClaw").Type);
					}
				}
			else if(npc.type == 224) {
				if(Main.rand.Next(2) == 0) {
					loot.Add(Mod.Find<ModItem>("Guppy").Type);
					}
				}
			else if(npc.type == 369) {
				if(Main.rand.Next(4) == 0) {
					loot.Add(2289);
					}
				else if(Main.rand.Next(4) == 0) {
					loot.Add(Mod.Find<ModItem>("JuniorPole").Type);
					}
				}
			else if(npc.type == 370) {
				loot.Add(Mod.Find<ModItem>("KevlonString").Type);
				}
			else if(npc.type == 398) {
				loot.Add(Mod.Find<ModItem>("OddString").Type);
				}
			foreach(int item in loot) {
				Item.NewItem(
					(int)npc.position.X,
					(int)npc.position.Y,
					npc.width,
					npc.height,
					item,
					1
					);
				}
			}
		}
	}