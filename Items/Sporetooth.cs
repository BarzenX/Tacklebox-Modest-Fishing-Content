using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class Sporetooth : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Sporetooth Mushark");
			// Tooltip.SetDefault("'Oh, I get it!'");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2342);
			Item.shoot = Mod.Find<ModProjectile>("Sporetooth").Type;
			}
		}
	}