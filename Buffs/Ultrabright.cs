using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Buffs {

	public class Ultrabright : ModBuff {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Ultrabright");
			// Description.SetDefault("Whoa, that's bright!");
			}

		public override void Update(Player player, ref int buffIndex) {
			Lighting.AddLight(
				(int)(player.position.X + player.width / 2) / 16,
				(int)(player.position.Y + player.height / 2) / 16,
				1.6f, 2.4f, 3.2f
				);
			}
		}
	}