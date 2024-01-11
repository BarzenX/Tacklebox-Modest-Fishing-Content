using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class Wiggler : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Lovely Wiggler");
			// Tooltip.SetDefault("'Worth it'");
			}

		public override void SetDefaults() {
			Item.value = 40000;
			Item.rare = 2;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.bait = 45;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(2002, 1);
			recipe.AddIngredient(29, 1);
			recipe.Register();
			}
		}
	}