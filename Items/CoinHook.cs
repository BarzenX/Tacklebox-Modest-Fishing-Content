using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class CoinHook : RodComponent {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Coin Hook");
			// Tooltip.SetDefault("Catch money with fish");
			}

		public override void SetDefaults() {
			base.SetDefaults();
			Item.value = 100000;
			Item.rare = 3;
			hookValue = 2;
			jigType = 16;
			}

		public override void AddRecipes() {
			Recipe recipe;
			recipe = CreateRecipe();
			recipe.AddTile(114);
			recipe.AddIngredient(Mod.Find<ModItem>("AdamHook").Type, 1);
			recipe.AddIngredient(855, 1);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddTile(114);
			recipe.AddIngredient(Mod.Find<ModItem>("TitanHook").Type, 1);
			recipe.AddIngredient(855, 1);
			recipe.Register();
			}
		}
	}