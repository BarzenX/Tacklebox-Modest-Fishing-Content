using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class PlatinumHook : RodComponent {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Platinum Hook");
			// Tooltip.SetDefault("Increases fishing skill");
			}

		public override void SetDefaults() {
			base.SetDefaults();
			Item.value = 40000;
			Item.rare = 1;
			hookValue = 1;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(16);
			recipe.AddIngredient(706, 4);
			recipe.Register();
			}
		}
	}