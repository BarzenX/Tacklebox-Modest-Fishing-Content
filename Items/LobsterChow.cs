using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class LobsterChow : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Lobster Chow");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2425);
			Item.value = 30000;
			Item.rare = 1;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.buffType = Mod.Find<ModBuff>("Seafood").Type;
			Item.buffTime = 28800;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(345);
			recipe.AddIngredient(Mod.Find<ModItem>("Lobster").Type, 1);
			recipe.Register();
			}
		}
	}