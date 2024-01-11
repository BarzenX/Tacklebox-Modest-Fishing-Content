using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class HellCrate : ModCrate {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Underworld Crate");
			// Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
			}

		public override void RightClick(Player player) {
			if(Main.rand.Next(40) == 0) {
				player.QuickSpawnItem(Mod.Find<ModItem>("CharredLine").Type);
				}
			player.QuickSpawnItem(265, 6 + Main.rand.Next(15));
			player.QuickSpawnItem(Mod.Find<ModItem>("ShadowLockbox").Type);
			base.RightClick(player);
			}
		}
	}