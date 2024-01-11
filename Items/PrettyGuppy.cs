using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class PrettyGuppy : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Pristine Guppy");
			// Tooltip.SetDefault("'Worth a pretty penny!'");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2290);
			Item.value = 100000;
			Item.rare = 2;
			}
		}
	}