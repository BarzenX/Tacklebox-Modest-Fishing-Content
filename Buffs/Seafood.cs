using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Buffs
{
	public class Seafood : ModBuff
	{
		public override void SetStaticDefaults()
		{

		}

		public override void Update(Player player, ref int buffIndex)
		{
			if(player.wet && !player.honeyWet && !player.lavaWet)   player.AddBuff(ModContent.BuffType<Buffs.WaterBoost>(), 5);
			if(player.honeyWet)   player.AddBuff(ModContent.BuffType<Buffs.HoneyBoost>(), 180);
			if(player.lavaWet)   player.AddBuff(ModContent.BuffType<Buffs.LavaBoost>(), 180);
		}
	}
}