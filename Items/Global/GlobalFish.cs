using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class GlobalFish : GlobalItem {

		private static int[] bigFish = new int[] {
			2290, 2298, 2299, 2300, 2301, 2302, 2303, 2305, 2311, 2313, 2317, 2318, 2319, 2321
			};

		public override bool IsLoadingEnabled(Mod mod)/* tModPorter Suggestion: If you return false for the purposes of manual loading, use the [Autoload(false)] attribute on your class instead */ {
			return true;
			}

		public override void CaughtFishStack(int type, ref int stack) {
			TackleboxPlayer player = Main.LocalPlayer.GetModPlayer<TackleboxPlayer>(Mod);
			if((player.jigSet & 16) == 16) {
				Main.LocalPlayer.QuickSpawnItem(71, Main.rand.Next(8, 16000));
				}
			if(player.bait == Mod.Find<ModItem>("Guppy").Type) {
				if(System.Array.IndexOf(bigFish, type) != -1) {
					stack = Main.rand.Next(1, 4);
					}
				}
			}

		public override bool ConsumeItem(Item item, Player player) {
			if(base.ConsumeItem(item, player)) {
				if(item.type == 2426 || item.type == 2427) {
					player.AddBuff(Mod.Find<ModBuff>("Seafood").Type, 7200);
					}
				return true;
				}
			return false;
			}
		}
	}