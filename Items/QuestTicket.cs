using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class QuestTicket : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Quest Ticket");
			// Tooltip.SetDefault("Swap this for a different fishing quest!");
			}

		public override void SetDefaults() {
			Item.value = 7500;
			Item.rare = 0;
			Item.maxStack = 99;
			Item.consumable = true;
			}

		public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */ {
			Main.AnglerQuestSwap();
			return true;
			}
		}
	}