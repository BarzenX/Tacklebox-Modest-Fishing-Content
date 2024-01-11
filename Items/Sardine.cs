using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class Sardine : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Sardine");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2290);
			}
		}
	}