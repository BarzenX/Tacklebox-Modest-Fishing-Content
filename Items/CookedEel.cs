using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class CookedEel : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Cooked Eel");
			// Tooltip.SetDefault("Imbues you with sandy strength");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2425);
			Item.value = 40000;
			Item.rare = 1;
			Item.buffType = Mod.Find<ModBuff>("Oasis").Type;
			Item.buffTime = 14400;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(96);
			recipe.AddIngredient(Mod.Find<ModItem>("DesertEel").Type, 1);
			recipe.Register();
			}
		}
	}