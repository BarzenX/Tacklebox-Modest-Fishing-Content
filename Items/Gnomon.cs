using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class Gnomon : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Enchanted Gnomon");
			// Tooltip.SetDefault("Reduces cooldown of Enchanted Sundial");
			}

		public override void SetDefaults() {
			Item.value = 40000;
			Item.rare = 2;
			Item.maxStack = 1;
			}
		}
	}