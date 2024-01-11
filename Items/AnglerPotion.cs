using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class AnglerPotion : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Angler Potion");
			// Tooltip.SetDefault("Improves overall fishing ability");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2354);
			Item.value = 10000;
			Item.rare = 2;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.buffType = 121;
			Item.buffTime = 18000;
			}

		public override bool ConsumeItem(Player player) {
			player.AddBuff(122, Item.buffTime);
			player.AddBuff(123, Item.buffTime);
			return true;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(355);
			recipe.AddIngredient(2354, 1);
			recipe.AddIngredient(2355, 1);
			recipe.AddIngredient(2356, 1);
			recipe.Register();
			}
		}
	}