using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class RodKit : RodComponent {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Fishing Rod Kit");
			// Tooltip.SetDefault("Increases fishing skill and crate chance by 5%\nCast two lines at once while fishing");
			}

		public override void SetDefaults() {
			base.SetDefaults();
			Item.value = 120000;
			Item.rare = 3;
			hookValue = 1;
			reelValue = 1;
			lineCount = 2;
			}

		public override void AddRecipes() {
			Recipe recipe;
			recipe = CreateRecipe();
			recipe.AddTile(114);
			recipe.AddIngredient(Mod.Find<ModItem>("GoldReel").Type, 1);
			recipe.AddIngredient(Mod.Find<ModItem>("GoldHook").Type, 1);
			recipe.AddIngredient(Mod.Find<ModItem>("BilineSpool").Type, 1);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddTile(114);
			recipe.AddIngredient(Mod.Find<ModItem>("PlatinumReel").Type, 1);
			recipe.AddIngredient(Mod.Find<ModItem>("PlatinumHook").Type, 1);
			recipe.AddIngredient(Mod.Find<ModItem>("BilineSpool").Type, 1);
			recipe.Register();
			}
		}
	}