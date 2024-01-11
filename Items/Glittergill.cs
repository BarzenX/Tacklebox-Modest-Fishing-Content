using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class Glittergill : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Glittergill");
			// Tooltip.SetDefault("'All that glitters is gold'");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2290);
			Item.value = 300000;
			Item.rare = 2;
			}
		}
	}