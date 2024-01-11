using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class Frostedfin : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Frosted Flarefin");
			// Tooltip.SetDefault("'Chill out!'");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2425);
			Item.value = 30000;
			Item.rare = 1;
			Item.potion = true;
			Item.healLife = 80;
			Item.buffType = 58;
			Item.buffTime = 7200;
			}

		public override bool ConsumeItem(Player player) {
			player.AddBuff(46, Item.buffTime / 2);
			return true;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(306);
			recipe.AddIngredient(2312, 1);
			recipe.Register();
			}
		}
	}