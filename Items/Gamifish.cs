using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class Gamifish : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Origami Fish");
			// Tooltip.SetDefault("'Is it a fish or paper?'");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2290);
			Item.value = 25000;
			}
		}
	}