using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Mounts
{
	public class AncientRay : ModMount
	{
		public override void SetStaticDefaults()
		{
			MountData.buff = ModContent.BuffType<Buffs.AncientRay>();
		}
	}
}