using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class CrocTooth : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Crocodile Tooth");
			// Tooltip.SetDefault("Something is looking for this...");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(3771);
			Item.value = 125000;
			// item.mountType = mod.MountType("Crocodile");
			}
		}
	}