using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public abstract class ModCrate : ModItem {

		protected int[] biomeLoot = new int[] {};
		protected int[] miscLoot = new int[] {};

		protected override bool CloneNewInstances {
			get {
				return true;
				}
			}

		public override void SetDefaults() {
			Item.value = 50000;
			Item.rare = 2;
			Item.maxStack = 99;
			Item.consumable = true;
			}

		public override bool CanRightClick() {
			return true;
			}

		public override void RightClick(Player player) {
			if(biomeLoot.Length > 0) {
				player.QuickSpawnItem(
					biomeLoot[Main.rand.Next(biomeLoot.Length)]
					);
				}
			for(int i = 0; i < miscLoot.Length; i++) {
				if(Main.rand.Next(1 + miscLoot.Length / 2) == 0) {
					player.QuickSpawnItem(miscLoot[i]);
					}
				}
			int rate = 0;
			int item = 0;
			rate = 4;
			if(Main.hardMode) {
				rate = 18;
				}
			if(Main.rand.Next(rate) == 0) {
				switch(Main.rand.Next(6)) {
					case 0:
						item = 22;
						break;
					case 1:
						item = 704;
						break;
					case 2:
						item = 21;
						break;
					case 3:
						item = 705;
						break;
					case 4:
						item = 19;
						break;
					case 5:
						item = 706;
						break;
					}
				player.QuickSpawnItem(item, Main.rand.Next(10, 20));
				}
			if(Main.hardMode && Main.rand.Next(8) == 0) {
				switch(Main.rand.Next(6)) {
					case 0:
						item = 381;
						break;
					case 1:
						item = 382;
						break;
					case 2:
						item = 391;
						break;
					case 3:
						item = 1184;
						break;
					case 4:
						item = 1191;
						break;
					case 5:
						item = 1198;
						break;
					}
				player.QuickSpawnItem(item, Main.rand.Next(8, 12));
				}
			if(Main.rand.Next(4) == 0) {
				switch(Main.rand.Next(6)) {
					case 0:
						item = 2354;
						break;
					case 1:
						item = 2355;
						break;
					case 2:
						item = 2356;
						break;
					case 3:
						item = 291;
						break;
					case 4:
						item = 302;
						break;
					case 5:
						item = 304;
						break;
					}
				player.QuickSpawnItem(item, Main.rand.Next(2, 6));
				}
			if(Main.rand.Next(2) == 0) {
				switch(Main.rand.Next(2)) {
					case 0:
						item = 188;
						if(Main.hardMode) {
							item = 499;
							}
						break;
					case 1:
						item = 189;
						if(Main.hardMode) {
							item = 500;
							}
						break;
					}
				player.QuickSpawnItem(item, Main.rand.Next(2, 6));
				}
			if(Main.rand.Next(2) == 0) {
				item = 2675;
				if(Main.rand.Next(2) == 0) {
					item = 2676;
					}
				player.QuickSpawnItem(item, Main.rand.Next(2, 6));
				}
			if(Main.rand.Next(4) == 0) {
				player.QuickSpawnItem(73, Main.rand.Next(6, 12));
				}
			}
		}
	}