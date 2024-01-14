using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Buffs
{
	public class DrunkWisdom : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Drunken Wisdom");
			// Description.SetDefault("Significantly reduced max life \nMagic damage increased by max life");
			Main.debuff[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.statLifeMax2 /= 5;
			player.GetDamage(DamageClass.Magic) += player.statLifeMax2;
		}
	}
}