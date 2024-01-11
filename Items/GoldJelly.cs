using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class GoldJelly : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Gold Jellyfish");
			}

		public override void SetDefaults() {
			Item.value = 200000;
			Item.rare = 3;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.bait = 50;
			}
		}
	}