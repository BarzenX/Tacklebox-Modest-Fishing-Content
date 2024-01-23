using Steamworks;
using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Buffs
{
	public class AncientRay : ModBuff
	{

		public override void SetStaticDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) 
		{
			player.mount.SetMount(ModContent.MountType<Mounts.AncientRay>(), player);

            player.buffTime[buffIndex] = 10;
		}
	}
}