using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class Venomfish : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Venomous Stonefish");
			// Tooltip.SetDefault("'Watch where you hold it!'");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2290);
			Item.value = 12500;
			Item.rare = 3;
			}

		public override void AddRecipes() {
			Recipe recipe = Recipe.Create(1340);
			recipe.AddTile(243);
			recipe.AddIngredient(126, 1);
			recipe.AddIngredient(this, 1);
			recipe.Register();
			}
		}
	}