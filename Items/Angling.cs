using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class Angling : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Angling");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2290);
			}
		}
	}