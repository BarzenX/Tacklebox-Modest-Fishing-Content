using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class SeaJig : RodComponent {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Ocean Jig");
			// Tooltip.SetDefault("Allows catching unique Ocean fish");
			}

		public override void SetDefaults() {
			base.SetDefaults();
			Item.value = 400000;
			Item.rare = 8;
			jigType = 1;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(26);
			recipe.AddIngredient(1536, 1);
			recipe.AddIngredient(2300, 100);
			recipe.AddIngredient(2301, 100);
			recipe.AddIngredient(2316, 100);
			recipe.Register();
			}
		}
	}