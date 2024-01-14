using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Buffs
{
	public class Leapfrog : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Leapfrog");
			// Description.SetDefault("Jump like a frog!");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.autoJump = true;
			player.noFallDmg = true;
			player.jumpSpeedBoost += Player.jumpSpeed;
		}
	}
}