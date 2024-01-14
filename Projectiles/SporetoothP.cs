using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Projectiles
{
	public class SporetoothP : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.SawtoothShark);
		}
	}
}