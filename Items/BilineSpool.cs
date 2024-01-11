using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class BilineSpool : RodComponent {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Biline Spool");
			// Tooltip.SetDefault("Fishing line never breaks\nCast two lines at once while fishing");
			}

		public override void SetDefaults() {
			base.SetDefaults();
			Item.value = 100000;
			Item.rare = 2;
			lineCount = 2;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(114);
			recipe.AddIngredient(2373, 2);
			recipe.Register();
			}
		}
	}