using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Projectiles
{
	public class FlyfishP : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.FrostDaggerfish);
			Projectile.aiStyle = 1;
			Projectile.penetrate = 1;
		}
	}
}