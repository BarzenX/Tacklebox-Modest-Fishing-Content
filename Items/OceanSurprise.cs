using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class OceanSurprise : ModItem {

		private static int[] buffList;

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Ocean Surprise");
			// Tooltip.SetDefault("'A menagerie of sea things'");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2425);
			Item.value = 40000;
			Item.rare = 2;
			Item.scale = 0.8f;
			Item.buffType = 26;
			Item.buffTime = 108000;
			buffList = new int[] {
				4, 6, 7, 106, 109,
				Mod.Find<ModBuff>("Leapfrog").Type,
				Mod.Find<ModBuff>("Seafood").Type,
				Mod.Find<ModBuff>("WaterBoost").Type
				};
			}

		public override bool ConsumeItem(Player player) {
			player.AddBuff(103, 28800);
			for(int i = 0; i < buffList.Length; i++) {
				if(Main.rand.Next(buffList.Length / 2) == 0) {
					player.AddBuff(buffList[i], 21600);
					}
				}
			return true;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(96);
			recipe.AddRecipeGroup("RawFish", 3);
			recipe.AddRecipeGroup("AnyJelly", 3);
			recipe.Register();
			}
		}
	}