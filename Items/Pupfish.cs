using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class Pupfish : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Legendary Pupfish");
			// Tooltip.SetDefault("'Sometimes the small ones are the most valuable!'");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2290);
			Item.value = 3000000;
			Item.rare = 4;
			}
		}
	}