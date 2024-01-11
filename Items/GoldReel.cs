using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class GoldReel : RodComponent {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Gold Reel");
			// Tooltip.SetDefault("Increases chance to fish crates");
			}

		public override void SetDefaults() {
			base.SetDefaults();
			Item.value = 40000;
			Item.rare = 1;
			reelValue = 1;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(16);
			recipe.AddIngredient(19, 4);
			recipe.AddIngredient(3306, 1);
			recipe.Register();
			}
		}
	}