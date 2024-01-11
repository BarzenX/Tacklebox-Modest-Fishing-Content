using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Buffs {

	public class WaterBoost : ModBuff {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Water Boost");
			// Description.SetDefault("Seafood Effect\nMove freely and faster in water!");
			Main.buffNoTimeDisplay[Type] = true;
			}

		public override void Update(Player player, ref int buffIndex) {
			player.ignoreWater = true;
			player.moveSpeed += 0.12f;
			}
		}
	}