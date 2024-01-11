using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class Dragnet : RodComponent {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Dragnet");
			// Tooltip.SetDefault("Fishing line never breaks\nCast eight lines at once while fishing\n'Those poor fish...'");
			}

		public override void SetDefaults() {
			base.SetDefaults();
			Item.value = 400000;
			Item.rare = 9;
			lineCount = 8;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(134);
			recipe.AddIngredient(Mod.Find<ModItem>("BilineSpool").Type, 1);
			recipe.AddIngredient(Mod.Find<ModItem>("OddString").Type, 4);
			recipe.Register();
			}
		}
	}