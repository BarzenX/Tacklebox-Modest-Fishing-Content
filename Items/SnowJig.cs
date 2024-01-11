using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class SnowJig : RodComponent {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Frozen Jig");
			// Tooltip.SetDefault("Allows catching unique Tundra fish");
			}

		public override void SetDefaults() {
			base.SetDefaults();
			Item.value = 400000;
			Item.rare = 8;
			jigType = 2;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(26);
			recipe.AddIngredient(1537, 1);
			recipe.AddIngredient(2299, 100);
			recipe.AddIngredient(2306, 100);
			recipe.AddIngredient(Mod.Find<ModItem>("Sturgeon").Type, 100);
			recipe.Register();
			}
		}
	}