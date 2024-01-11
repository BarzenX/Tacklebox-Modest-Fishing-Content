using Terraria.ModLoader;

namespace Tacklebox.Projectiles {

	public class ZodiacBobber : Bobber {

		public override void SetDefaults() {
			base.SetDefaults();
			light.X = 0.04f;
			light.Y = 0.12f;
			light.Z = 0.20f;
			}
		}
	}