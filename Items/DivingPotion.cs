using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class DivingPotion : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Diving Potion");
			// Tooltip.SetDefault("Grants underwater breathing and mobility");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2354);
			Item.value = 10000;
			Item.rare = 2;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.buffType = 4;
			Item.buffTime = 18000;
			}

		public override bool ConsumeItem(Player player) {
			player.AddBuff(109, Item.buffTime);
			return true;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(355);
			recipe.AddIngredient(291, 1);
			recipe.AddIngredient(2327, 1);
			recipe.Register();
			}
		}
	}