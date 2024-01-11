using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class JungleJig : RodComponent {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Jungle Jig");
			// Tooltip.SetDefault("Allows catching unique Jungle fish");
			}

		public override void SetDefaults() {
			base.SetDefaults();
			Item.value = 400000;
			Item.rare = 8;
			jigType = 4;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(26);
			recipe.AddIngredient(1533, 1);
			recipe.AddIngredient(2302, 100);
			recipe.AddIngredient(2313, 100);
			recipe.AddIngredient(2311, 100);
			recipe.Register();
			}
		}
	}