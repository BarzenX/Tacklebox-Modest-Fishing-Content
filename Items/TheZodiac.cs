using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class TheZodiac : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("The Zodiac");
			// Tooltip.SetDefault("Influenced by moon phase");
			Tacklebox.modRod.Add(Item.type);
			Tacklebox.noLava.Add(Item.type);
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2289);
			Item.value = 80000;
			Item.rare = 4;
			Item.fishingPole = 48;
			Item.shoot = Mod.Find<ModProjectile>("ZodiacBobber").Type;
			Item.shootSpeed = 16.0f;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(114);
			recipe.AddIngredient(Mod.Find<ModItem>("TheVoyager").Type, 1);
			recipe.AddIngredient(3064, 1);
			recipe.Register();
			}
		}
	}