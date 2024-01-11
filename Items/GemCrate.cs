using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class GemCrate : ModCrate {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Jeweled Crate");
			// Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
			}

		public override void SetDefaults() {
			base.SetDefaults();
			Item.value = 100000;
			Item.rare = 3;
			}

		public override void RightClick(Player player) {
			if(Main.hardMode) {
				if(Main.rand.Next(2) == 0) {
					player.QuickSpawnItem(502, 2 + Main.rand.Next(6));
					}
				if(Main.rand.Next(24) == 0) {
					player.QuickSpawnItem(Mod.Find<ModItem>("Gnomon").Type);
					}
				}
			if(Main.rand.Next(2) == 0) {
				player.QuickSpawnItem(181, 1 + Main.rand.Next(6));
				}
			if(Main.rand.Next(2) == 0) {
				player.QuickSpawnItem(180, 1 + Main.rand.Next(6));
				}
			if(Main.rand.Next(3) == 0) {
				player.QuickSpawnItem(177, 1 + Main.rand.Next(5));
				}
			if(Main.rand.Next(3) == 0) {
				player.QuickSpawnItem(179, 1 + Main.rand.Next(5));
				}
			if(Main.rand.Next(4) == 0) {
				player.QuickSpawnItem(178, 1 + Main.rand.Next(4));
				}
			if(Main.rand.Next(4) == 0) {
				player.QuickSpawnItem(182, 1 + Main.rand.Next(3));
				}
			if(Main.rand.Next(48) == 0) {
				player.QuickSpawnItem(Mod.Find<ModItem>("CaveRod").Type);
				}
			player.QuickSpawnItem(73, 1 + Main.rand.Next(10));
			}
		}
	}