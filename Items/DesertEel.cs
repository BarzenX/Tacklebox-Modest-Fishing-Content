using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class DesertEel : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Oasis Eel");
			// Tooltip.SetDefault("'Doubles as a snake'");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2290);
			Item.value = 37500;
			Item.rare = 2;
			}
		}
	}