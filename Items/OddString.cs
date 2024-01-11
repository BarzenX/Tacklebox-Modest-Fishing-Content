using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class OddString : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Suspicious String");
			}

		public override void SetDefaults() {
			Item.value = 80000;
			Item.rare = 3;
			Item.maxStack = 99;
			}
		}
	}