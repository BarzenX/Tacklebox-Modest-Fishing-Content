using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class Flyfish : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Flyfish");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(3197);
			Item.shoot = Mod.Find<ModProjectile>("Flyfish").Type;
			Item.damage = 6;
			Item.knockBack = 12.0f;
			}

		public override void CaughtFishStack(ref int stack) {
			stack = 4 + Main.rand.Next(20);
			}
		}
	}