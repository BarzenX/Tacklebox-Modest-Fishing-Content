using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class Plankton : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Alien Plankton");
			// Tooltip.SetDefault("You feel an ancient presence seeking this item...");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(3367);
			Item.expert = false;
			Item.value = 375000;
			// item.mountType = mod.MountType("AncientRay");
			}
		}
	}