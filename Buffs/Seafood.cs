using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Buffs {

	public class Seafood : ModBuff {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Seafood");
			// Description.SetDefault("Grants buffs while submerged in liquid");
			}

		public override void Update(Player player, ref int buffIndex) {
			if(player.wet) {
				player.AddBuff(Mod.Find<ModBuff>("WaterBoost").Type, 5);
				}
			if(player.honeyWet) {
				player.AddBuff(Mod.Find<ModBuff>("HoneyBoost").Type, 5);
				}
			if(player.lavaWet) {
				player.AddBuff(Mod.Find<ModBuff>("LavaBoost").Type, 5);
				}
			}
		}
	}