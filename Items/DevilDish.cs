using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class DevilDish : ModItem {

		private static int[] buffList;

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Devil's Dish");
			// Tooltip.SetDefault("'An underworld delicacy'");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2425);
			Item.value = 40000;
			Item.rare = 3;
			Item.scale = 0.8f;
			Item.buffType = 26;
			Item.buffTime = 216000;
			buffList = new int[] {
				2, 13, 14, 17, 105, 115, 116, 117, 124, Mod.Find<ModBuff>("LavaBoost").Type
				};
			}

		public override bool ConsumeItem(Player player) {
			player.AddBuff(24, 1200);
			for(int i = 0; i < buffList.Length; i++) {
				if(Main.rand.Next(buffList.Length / 3) == 0) {
					player.AddBuff(
						buffList[i],
						Main.rand.Next(2, 8) * 3600
						);
					}
				}
			return true;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(96);
			recipe.AddIngredient(Mod.Find<ModItem>("Pupfish").Type, 1);
			recipe.AddIngredient(Mod.Find<ModItem>("CrabClaw").Type, 1);
			recipe.AddIngredient(Mod.Find<ModItem>("Lobster").Type, 1);
			recipe.Register();
			}
		}
	}