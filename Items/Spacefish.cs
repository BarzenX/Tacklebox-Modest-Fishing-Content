using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class Spacefish : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Bollywog");
			// Tooltip.SetDefault("'What happens if you squeeze it?'");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(110);
			Item.value = 62500;
			Item.rare = 3;
			Item.maxStack = 1;
			Item.healMana = 60;
			}

		public override bool ConsumeItem(Player player) {
			return false;
			}

		public override bool CanUseItem(Player player) {
			return player.FindBuffIndex(94) == -1;
			}
		}
	}