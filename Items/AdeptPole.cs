using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class AdeptPole : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Adept's Pole");
			// Tooltip.SetDefault("'Very makeshift'");
			Tacklebox.modRod.Add(Item.type);
			Tacklebox.noLava.Add(Item.type);
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2289);
			Item.value = 20000;
			Item.rare = 1;
			Item.fishingPole = 18;
			Item.shoot = Mod.Find<ModProjectile>("AdeptBobber").Type;
			Item.shootSpeed = 12.0f;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(16);
			recipe.AddIngredient(Mod.Find<ModItem>("JuniorPole").Type, 1);
			recipe.AddRecipeGroup("IronBar", 8);
			recipe.Register();
			}
		}
	}