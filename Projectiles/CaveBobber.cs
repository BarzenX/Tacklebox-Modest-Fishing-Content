using Terraria.ModLoader;

namespace Tacklebox.Projectiles {

	public class CaveBobber : Bobber {

		public override void SetDefaults() {
			base.SetDefaults();
			light.X = 0.20f;
			light.Y = 0.04f;
			light.Z = 0.12f;
			}
		}
	}