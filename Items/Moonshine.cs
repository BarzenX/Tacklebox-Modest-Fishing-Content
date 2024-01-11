using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class Moonshine : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Moonshine");
			// Tooltip.SetDefault("Makes you a danger to yourself");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2354);
			Item.value = 10000;
			Item.rare = 1;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.buffType = 0;
			Item.buffTime = 10800;
			}

		public override bool ConsumeItem(Player player) {
			if(Main.rand.Next(2) == 0) {
				player.AddBuff(Mod.Find<ModBuff>("Redonkulous").Type, Item.buffTime);
				}
			else {
				player.AddBuff(Mod.Find<ModBuff>("DrunkWisdom").Type, Item.buffTime);
				}
			return true;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(13);
			recipe.AddIngredient(353, 1);
			recipe.AddIngredient(314, 1);
			recipe.AddIngredient(Mod.Find<ModItem>("Whiskeyfish").Type, 1);
			recipe.Register();
			}
		}
	}