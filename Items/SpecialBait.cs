using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class SpecialBait : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Special Bait");
			// Tooltip.SetDefault("Attracts quest fish");
			}

		public override void SetDefaults() {
			Item.value = 10000;
			Item.rare = 2;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.bait = 20;
			}
		}
	}