using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Buffs {

	public class Redonkulous : ModBuff {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Redonkulous");
			// Description.SetDefault("Significantly reduced health\nMelee damage increased by health");
			Main.debuff[Type] = true;
			}

		public override void Update(Player player, ref int buffIndex) {
			player.statLifeMax2 /= 5;
			player.GetDamage(DamageClass.Melee) += player.statLifeMax2;
			}
		}
	}