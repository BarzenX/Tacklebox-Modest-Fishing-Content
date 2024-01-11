using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class Caviar : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Caviar");
			// Tooltip.SetDefault("'Quite.'");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2425);
			Item.value = 40000;
			Item.rare = 1;
			Item.healLife = 20;
			Item.buffType = 47;
			Item.buffTime = 1800;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(306);
			recipe.AddIngredient(Mod.Find<ModItem>("Sturgeon").Type, 1);
			recipe.Register();
			}
		}
	}