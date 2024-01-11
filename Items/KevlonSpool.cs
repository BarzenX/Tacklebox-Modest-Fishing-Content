using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class KevlonSpool : RodComponent {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Kevlon Spool");
			// Tooltip.SetDefault("Fishing line never breaks\nCast four lines at once while fishing\n'The power of kevlon!'");
			}

		public override void SetDefaults() {
			base.SetDefaults();
			Item.value = 200000;
			Item.rare = 7;
			lineCount = 4;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(134);
			recipe.AddIngredient(Mod.Find<ModItem>("BilineSpool").Type, 1);
			recipe.AddIngredient(Mod.Find<ModItem>("KevlonString").Type, 2);
			recipe.Register();
			}
		}
	}