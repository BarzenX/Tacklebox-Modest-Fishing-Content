using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class TitanReel : RodComponent {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Titanium Reel");
			// Tooltip.SetDefault("Increases chance to fish crates");
			}

		public override void SetDefaults() {
			base.SetDefaults();
			Item.value = 80000;
			Item.rare = 3;
			reelValue = 2;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(134);
			recipe.AddIngredient(1198, 4);
			recipe.AddIngredient(3306, 1);
			recipe.Register();
			}
		}
	}