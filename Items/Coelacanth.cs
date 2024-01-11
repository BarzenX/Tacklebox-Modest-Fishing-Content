using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class Coelacanth : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Coelacanth");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2290);
			}
		}
	}