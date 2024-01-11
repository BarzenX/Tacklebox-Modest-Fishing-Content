using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class Flounder : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Flounder");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2290);
			}
		}
	}