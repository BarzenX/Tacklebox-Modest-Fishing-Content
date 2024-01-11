using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class Whiskeyfish : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Whiskeyfish");
			// Tooltip.SetDefault("'This fish looks... inebriated'");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2290);
			Item.value = 25000;
			Item.rare = 1;
			}
		}
	}