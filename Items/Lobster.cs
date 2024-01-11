using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class Lobster : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Lobster");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2290);
			Item.value = 40000;
			Item.rare = 2;
			}
		}
	}