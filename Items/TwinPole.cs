using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class TwinPole : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Twin Cattail Pole");
			// Tooltip.SetDefault("Cast twice as many lines at once");
			Tacklebox.modRod.Add(Item.type);
			Tacklebox.noLava.Add(Item.type);
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2289);
			Item.value = 100000;
			Item.rare = 2;
			Item.fishingPole = 32;
			Item.shoot = Mod.Find<ModProjectile>("TwinBobber").Type;
			Item.shootSpeed = 14.0f;
			}

		public override void AddRecipes() {
			Recipe recipe;
			recipe = CreateRecipe();
			recipe.AddTile(16);
			recipe.AddIngredient(2292, 1);
			recipe.AddIngredient(Mod.Find<ModItem>("GoldHook").Type, 2);
			recipe.AddIngredient(Mod.Find<ModItem>("Cattail").Type, 2);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddTile(16);
			recipe.AddIngredient(2292, 1);
			recipe.AddIngredient(Mod.Find<ModItem>("PlatinumHook").Type, 2);
			recipe.AddIngredient(Mod.Find<ModItem>("Cattail").Type, 2);
			recipe.Register();
			}
		}
	}