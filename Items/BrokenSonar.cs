using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class BrokenSonar : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Broken Sonar");
			// Tooltip.SetDefault("'It's missing some parts...'");
			}

		public override void SetDefaults() {
			Item.value = 7500;
			Item.rare = 0;
			Item.maxStack = 1;
			}
		}
	}