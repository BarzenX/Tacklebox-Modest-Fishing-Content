using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class SuperFishing : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Super Fishing Potion");
			// Tooltip.SetDefault("Increases fishing power a lot");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2354);
			Item.value = 10000;
			Item.rare = 2;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.buffType = Mod.Find<ModBuff>("BigFishing").Type;
			Item.buffTime = 43200;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(355);
			recipe.AddIngredient(2354, 1);
			recipe.AddIngredient(317, 2);
			recipe.AddIngredient(2626, 1);
			recipe.Register();
			}
		}
	}