using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class SeaCrate : ModCrate {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Ocean Crate");
			// Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
			}

		public override void SetDefaults() {
			base.SetDefaults();
			biomeLoot = new int[] {
				186, 187, 268, 277, 863, 1303
				};
			miscLoot = new int[] {
				275, 282, 319, 1118, 1119, 2625, 2626
				};
			}

		public override void RightClick(Player player) {
			if(Main.rand.Next(24) == 0) {
				player.QuickSpawnItem(1315, 1);
				}
			if(Main.rand.Next(32) == 0) {
				player.QuickSpawnItem(Mod.Find<ModItem>("Ocarina").Type, 1);
				}
			base.RightClick(player);
			}
		}
	}