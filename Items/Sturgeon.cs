using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class Sturgeon : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Snow Sturgeon");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2290);
			Item.value = 10000;
			}
		}
	}