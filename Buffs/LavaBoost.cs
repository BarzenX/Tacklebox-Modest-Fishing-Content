using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Buffs {

	public class LavaBoost : ModBuff {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Lava Boost");
			// Description.SetDefault("Seafood Effect\nYou deal 24% more damage while melting!");
			Main.buffNoTimeDisplay[Type] = true;
			}

		public override void Update(Player player, ref int buffIndex) {
			player.GetDamage(DamageClass.Melee) += 0.24f;
			player.GetDamage(DamageClass.Ranged) += 0.24f;
			player.GetDamage(DamageClass.Magic) += 0.24f;
			player.GetDamage(DamageClass.Throwing) += 0.24f;
			player.GetDamage(DamageClass.Summon) += 0.24f;
			}
		}
	}