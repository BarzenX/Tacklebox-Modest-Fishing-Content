using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class SandShark : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Sand Shark");
			// Tooltip.SetDefault("'Quite a catch!'");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2290);
			Item.value = 37500;
			Item.rare = 2;
			}
		}
	}