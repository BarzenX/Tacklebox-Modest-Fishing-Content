using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class MegaRodKit : RodComponent {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Advanced Rod Kit");
			// Tooltip.SetDefault("Increases fishing skill and crate chance by 10%\nCast four lines at once while fishing");
			}

		public override void SetDefaults() {
			base.SetDefaults();
			Item.value = 160000;
			Item.rare = 4;
			hookValue = 2;
			reelValue = 2;
			lineCount = 4;
			}

		public override void AddRecipes() {
			Recipe recipe;
			recipe = CreateRecipe();
			recipe.AddTile(114);
			recipe.AddIngredient(Mod.Find<ModItem>("AdamReel").Type, 1);
			recipe.AddIngredient(Mod.Find<ModItem>("AdamHook").Type, 1);
			recipe.AddIngredient(Mod.Find<ModItem>("KevlonSpool").Type, 1);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddTile(114);
			recipe.AddIngredient(Mod.Find<ModItem>("TitanReel").Type, 1);
			recipe.AddIngredient(Mod.Find<ModItem>("TitanHook").Type, 1);
			recipe.AddIngredient(Mod.Find<ModItem>("KevlonSpool").Type, 1);
			recipe.Register();
			}
		}
	}