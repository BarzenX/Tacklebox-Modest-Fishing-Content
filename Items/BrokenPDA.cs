using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class BrokenPDA : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Broken PDA");
			// Tooltip.SetDefault("'Almost got your hopes up...'");
			}

		public override void SetDefaults() {
			Item.value = 0;
			Item.rare = -1;
			Item.maxStack = 99;
			}
		}
	}