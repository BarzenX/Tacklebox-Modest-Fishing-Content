using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class SonarStick : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Sonar Stick");
			// Tooltip.SetDefault("Shows what's on your hook");
			}

		public override void SetDefaults() {
			Item.value = 50000;
			Item.rare = 1;
			Item.accessory = true;
			Item.buffType = 122;
			}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<TackleboxPlayer>(Mod).sonar = true;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(18);
			recipe.AddIngredient(Mod.Find<ModItem>("BrokenSonar").Type);
			recipe.AddIngredient(3084, 1);
			recipe.AddIngredient(2355, 4);
			recipe.Register();
			}
		}
	}