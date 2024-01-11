using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class SuperCrate : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Super Crate Potion");
			// Tooltip.SetDefault("Increases chance to get a crate a lot");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2354);
			Item.value = 10000;
			Item.rare = 2;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.buffType = Mod.Find<ModBuff>("BigCrate").Type;
			Item.buffTime = 21600;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(355);
			recipe.AddIngredient(2356, 1);
			recipe.AddIngredient(315, 2);
			recipe.AddIngredient(Mod.Find<ModItem>("Boxfish").Type, 1);
			recipe.Register();
			}
		}
	}