using Terraria.ModLoader;

namespace Tacklebox.Projectiles
{
	public class GemBobberP : Bobber
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			disco = true;
			light.X = 0.002f;
			light.Y = 0.002f;
			light.Z = 0.002f;
		}
	}
}