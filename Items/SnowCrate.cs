using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class SnowCrate : ModCrate {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Frozen Crate");
			// Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
			}

		public override void SetDefaults() {
			base.SetDefaults();
			biomeLoot = new int[] {
				670, 724, 950, 987, 1319, 1579
				};
			miscLoot = new int[] {
				2198, 3199, 997, 669
				};
			}
		}
	}