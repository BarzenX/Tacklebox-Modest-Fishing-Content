using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Buffs
{
	public class HoneyBoost : ModBuff
	{

		public override void SetStaticDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.lifeRegenCount += 2;
		}
	}
}