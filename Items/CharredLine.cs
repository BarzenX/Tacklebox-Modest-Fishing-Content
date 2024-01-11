using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class CharredLine : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Charred Line");
			// Tooltip.SetDefault("'This could probably survive lava...'");
			}

		public override void SetDefaults() {
			Item.value = 10000;
			Item.rare = 0;
			Item.maxStack = 99;
			}
		}
	}