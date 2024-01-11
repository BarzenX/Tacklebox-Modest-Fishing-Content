using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class CookedShark : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Cooked Shark");
			// Tooltip.SetDefault("'A delicacy in distant lands'");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2425);
			Item.value = 40000;
			Item.rare = 2;
			Item.buffType = 26;
			Item.buffTime = 216000;
			}

		public override bool ConsumeItem(Player player) {
			player.AddBuff(Mod.Find<ModBuff>("Seafood").Type, 72000);
			return true;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(96);
			recipe.AddIngredient(Mod.Find<ModItem>("SandShark").Type, 1);
			recipe.Register();
			}
		}
	}