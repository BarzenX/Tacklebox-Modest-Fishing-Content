using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class Clusterfish : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Clusterfish");
			// Tooltip.SetDefault("'A small colony of fish'");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2290);
			Item.value = 37500;
			Item.rare = 2;
			}

		public override void CaughtFishStack(ref int stack) {
			stack = 1 + Main.rand.Next(3);
			}
		}
	}