using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Buffs
{
	public class Oasis : ModBuff
	{
		public override void SetStaticDefaults()
		{

		}

		public override void Update(Player player, ref int buffIndex)
		{
			if(player.ZoneDesert)
			{
				player.lifeRegen += 4;
				player.statDefense += 8;
			}
		}
	}
}