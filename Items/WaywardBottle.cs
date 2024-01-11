using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class WaywardBottle : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Wayward Bottle");
			// Tooltip.SetDefault("'What's that inside?'");
			}

		public override void SetDefaults() {
			Item.value = 10000;
			Item.rare = 1;
			Item.maxStack = 99;
			}
		}
	}