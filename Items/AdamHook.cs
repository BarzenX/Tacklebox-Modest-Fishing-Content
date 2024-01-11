using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class AdamHook : RodComponent {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Adamantite Hook");
			// Tooltip.SetDefault("Increases fishing skill");
			}

		public override void SetDefaults() {
			base.SetDefaults();
			Item.value = 80000;
			Item.rare = 3;
			hookValue = 2;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(134);
			recipe.AddIngredient(391, 4);
			recipe.Register();
			}
		}
	}