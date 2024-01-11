using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class FrogPotion : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Frog Potion");
			// Tooltip.SetDefault("Increases jump height");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2354);
			Item.value = 10000;
			Item.rare = 1;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.buffType = Mod.Find<ModBuff>("Leapfrog").Type;
			Item.buffTime = 21600;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(13);
			recipe.AddIngredient(126, 1);
			recipe.AddIngredient(2121, 1);
			recipe.AddRecipeGroup("Butterflies", 1);
			recipe.Register();
			}
		}
	}