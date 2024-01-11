using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class TheVoyager : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("The Voyager");
			// Tooltip.SetDefault("'From across the seven depths'");
			Tacklebox.modRod.Add(Item.type);
			Tacklebox.noLava.Add(Item.type);
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2289);
			Item.value = 80000;
			Item.rare = 2;
			Item.fishingPole = 32;
			Item.shoot = Mod.Find<ModProjectile>("VoyageBobber").Type;
			Item.shootSpeed = 16.0f;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(16);
			recipe.AddIngredient(Mod.Find<ModItem>("AdeptPole").Type, 1);
			recipe.AddIngredient(178, 8);
			recipe.Register();
			}
		}
	}