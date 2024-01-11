using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class Glowfly : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Glowfly");
			// Tooltip.SetDefault("'Tempting...'");
			}

		public override void SetDefaults() {
			Item.value = 40000;
			Item.rare = 4;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.bait = 60;
			}

		public override void AddRecipes() {
			Recipe recipe;
			recipe = CreateRecipe();
			recipe.AddTile(12);
			recipe.AddIngredient(2007, 1);
			recipe.AddIngredient(2004, 1);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddTile(42);
			recipe.AddIngredient(2007, 1);
			recipe.AddIngredient(2004, 1);
			recipe.Register();
			}
		}
	}