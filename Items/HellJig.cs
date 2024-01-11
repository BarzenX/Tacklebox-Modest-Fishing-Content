using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class HellJig : RodComponent {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Infernal Jig");
			// Tooltip.SetDefault("Allows catching unique Underworld fish");
			}

		public override void SetDefaults() {
			base.SetDefaults();
			Item.value = 400000;
			Item.rare = 8;
			jigType = 8;
			}

		public override void AddRecipes() {
			Recipe recipe;
			recipe = CreateRecipe();
			recipe.AddTile(26);
			recipe.AddIngredient(1534, 1);
			recipe.AddIngredient(2312, 100);
			recipe.AddIngredient(2315, 100);
			recipe.AddIngredient(2318, 100);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddTile(26);
			recipe.AddIngredient(1535, 1);
			recipe.AddIngredient(2312, 100);
			recipe.AddIngredient(2315, 100);
			recipe.AddIngredient(2305, 100);
			recipe.Register();
			}
		}
	}