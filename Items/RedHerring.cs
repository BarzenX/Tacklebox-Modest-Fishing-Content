using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class RedHerring : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Red Herring");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2290);
			}
		}
	}