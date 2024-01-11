using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class GlobalCrateLoot : GlobalItem {

		public override bool IsLoadingEnabled(Mod mod)/* tModPorter Suggestion: If you return false for the purposes of manual loading, use the [Autoload(false)] attribute on your class instead */ {
			return true;
			}

		public override void OpenVanillaBag(string context, Player player, int arg) {
			if(context == "crate") {
				if(arg == 2335) {
					if(Main.rand.Next(40) == 0) {
						player.QuickSpawnItem(Mod.Find<ModItem>("BrokenSonar").Type);
						}
					}
				if(arg == 3208) {
					if(Main.rand.Next(4) == 0) {
						player.QuickSpawnItem(Mod.Find<ModItem>("Cattail").Type);
						}
					}
				}
			}
		}
	}