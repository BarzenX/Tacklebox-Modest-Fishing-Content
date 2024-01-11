using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class CookedCluster : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Cooked Colony");
			// Tooltip.SetDefault("'An exotic food with exotic properties'");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2425);
			Item.value = 20000;
			Item.rare = 1;
			Item.buffType = Mod.Find<ModBuff>("BaitBuddies").Type;
			Item.buffTime = 10800;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(96);
			recipe.AddIngredient(Mod.Find<ModItem>("Clusterfish").Type, 1);
			recipe.Register();
			}
		}
	}