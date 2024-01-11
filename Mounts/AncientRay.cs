using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Mounts {

	public class AncientRay : ModMount {

		public override void SetStaticDefaults() {
			//mountData.buff = mod.BuffType("AncientRay");
			MountData.buff = 168;
			}
		}
	}