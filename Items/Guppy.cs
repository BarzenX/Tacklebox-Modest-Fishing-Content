using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class Guppy : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Guppy");
			}

		public override void SetDefaults() {
			Item.value = 5000;
			Item.rare = 0;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.bait = 10;
			}

		public override void CaughtFishStack(ref int stack) {
			stack = 1 + Main.rand.Next(5);
			}
		}
	}