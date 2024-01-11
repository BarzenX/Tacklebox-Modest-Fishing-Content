using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class Boxfish : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Boxfish");
			// Tooltip.SetDefault("'A funny-looking fish'");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2290);
			Item.value = 40000;
			Item.rare = 1;
			}
		}
	}