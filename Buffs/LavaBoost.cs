using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Buffs
{
	public class LavaBoost : ModBuff
	{

		public override void SetStaticDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.GetDamage(DamageClass.Melee) += 0.24f; //TODO: wouldn't be *= 0.24f be more logical?
			player.GetDamage(DamageClass.Ranged) += 0.24f;
			player.GetDamage(DamageClass.Magic) += 0.24f;
			player.GetDamage(DamageClass.Throwing) += 0.24f;
			player.GetDamage(DamageClass.Summon) += 0.24f;
		}
	}
}