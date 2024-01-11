using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class TitanHook : RodComponent {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Titanium Hook");
			// Tooltip.SetDefault("Increases fishing skill");
			}

		public override void SetDefaults() {
			base.SetDefaults();
			Item.rare = 3;
			hookValue = 2;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(134);
			recipe.AddIngredient(1198, 4);
			recipe.Register();
			}
		}
	}