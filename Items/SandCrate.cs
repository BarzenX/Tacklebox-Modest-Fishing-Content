using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class SandCrate : ModCrate {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Desert Crate");
			// Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
			}

		public override void SetDefaults() {
			base.SetDefaults();
			biomeLoot = new int[] {
				857, 848, 866, 934, 1319, 1579
				};
			miscLoot = new int[] {
				2663, 1720, 2137, 2151, 2155, 1704, 1705, 3885, 2143, 1710, 2389, 2238, 2133, 2147, 2379, 3904, 2843, 2405, 1716, 3910
				};
			}
		}
	}