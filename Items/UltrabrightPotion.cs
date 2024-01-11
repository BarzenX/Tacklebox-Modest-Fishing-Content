using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class UltrabrightPotion : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Ultrabright Potion");
			// Tooltip.SetDefault("Makes you ultrabright");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2354);
			Item.value = 10000;
			Item.rare = 1;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.buffType = Mod.Find<ModBuff>("Ultrabright").Type;
			Item.buffTime = 36000;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(13);
			recipe.AddIngredient(126, 1);
			recipe.AddIngredient(318, 1);
			recipe.AddIngredient(Mod.Find<ModItem>("Angling").Type, 1);
			recipe.Register();
			}
		}
	}