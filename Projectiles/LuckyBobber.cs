using Terraria.ModLoader;

namespace Tacklebox.Projectiles {

	public class LuckyBobber : Bobber {

		public override void SetDefaults() {
			base.SetDefaults();
			light.X = 0.24f;
			light.Y = 0.16f;
			light.Z = 0.32f;
			}
		}
	}