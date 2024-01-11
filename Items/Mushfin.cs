using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class Mushfin : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Spongy Onuso");
			// Tooltip.SetDefault("'Strangely familiar... Eat it?'");
			}

		public override void SetDefaults() {
			Item.value = 15000;
			Item.rare = 1;
			Item.maxStack = 30;
			Item.healLife = 6;
			Item.consumable = true;
			}

		public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */ {
			player.statLife += Item.healLife;
			if(player.whoAmI == Main.myPlayer) {
				player.HealEffect(Item.healLife, true);
				}
			return true;
			}
		}
	}