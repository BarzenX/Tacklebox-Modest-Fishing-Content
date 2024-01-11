using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Tiles {

	public class GlobalGnomon : GlobalTile {

		public override void RightClick(int i, int j, int type) {
			if(type == 356) {
				base.RightClick(i, j, type);
				if(Main.sundialCooldown > 4) {
					if(Main.LocalPlayer.HasItem(Mod.Find<ModItem>("Gnomon").Type)) {
						Main.sundialCooldown = 4;
						}
					}
				}
			}
		}
	}