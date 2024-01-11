using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class Superglub : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Sweet Sweetglub");
			// Tooltip.SetDefault("'Something with you and honey, huh?'");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2425);
			Item.value = 40000;
			Item.rare = 2;
			Item.buffType = Mod.Find<ModBuff>("Seafood").Type;
			Item.buffTime = 32400;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe(5);
			recipe.AddTile(96);
			recipe.AddIngredient(Mod.Find<ModItem>("Sweetglub").Type, 5);
			recipe.AddIngredient(1134, 1);
			recipe.Register();
			}
		}
	}