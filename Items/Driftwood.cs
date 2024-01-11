using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class Driftwood : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Driftwood");
			}

		public override void SetDefaults() {
			Item.value = 0;
			Item.rare = -1;
			Item.maxStack = 99;
			}
		}
	}