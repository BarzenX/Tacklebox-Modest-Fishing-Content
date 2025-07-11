using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Buffs
{
	public class Leapfrog : ModBuff
	{
		public override void Update(Player player, ref int buffIndex)
		{
			player.autoJump = true;
			player.noFallDmg = true;
			player.jumpSpeedBoost += 1.6f;
		}
	}
}