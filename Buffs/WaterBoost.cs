using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Buffs
{
	public class WaterBoost : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.ignoreWater = true;
			player.moveSpeed += 0.12f;
		}
	}
}