using Terraria.ModLoader;

namespace Tacklebox.Projectiles {

	public class Flyfish : ModProjectile {

		public override void SetDefaults() {
			Projectile.CloneDefaults(520);
			Projectile.aiStyle = 1;
			Projectile.penetrate = 1;
			}
		}
	}