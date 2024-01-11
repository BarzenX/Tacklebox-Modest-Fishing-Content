using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class CrabClaw : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Crab Claw");
			// Tooltip.SetDefault("Bonus power with Jewel Fishing Rod");
			}

		public override void SetDefaults() {
			Item.value = 10000;
			Item.rare = 0;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.bait = 20;
			}
		}
	}