using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Buffs {

	public class AncientRay : ModBuff {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Ancient Ray");
			// Description.SetDefault("You've befriended a flying manta ray from outer space");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
			}

		public override void Update(Player player, ref int buffIndex) {
			player.mount.SetMount(Mod.Find<ModMount>("AncientRay").Type, player);
			player.buffTime[buffIndex] = 10;
			}
		}
	}