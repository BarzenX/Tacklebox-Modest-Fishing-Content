using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class GemRod : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Jewel Fishing Rod");
			// Tooltip.SetDefault("Catch gems instead of fish\nFishing power is halved\n'Likely to get a lot of junk...'");
			Tacklebox.modRod.Add(Item.type);
			Tacklebox.noLava.Add(Item.type);
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2289);
			Item.value = 400000;
			Item.rare = 3;
			Item.fishingPole = 1;
			Item.shoot = Mod.Find<ModProjectile>("GemBobber").Type;
			Item.shootSpeed = 8.0f;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(16);
			recipe.AddIngredient(Mod.Find<ModItem>("TheVoyager").Type, 1);
			recipe.AddIngredient(181, 16);
			recipe.AddIngredient(180, 16);
			recipe.AddIngredient(177, 16);
			recipe.AddIngredient(179, 16);
			recipe.AddIngredient(178, 16);
			recipe.AddIngredient(182, 16);
			recipe.Register();
			}
		}
	}