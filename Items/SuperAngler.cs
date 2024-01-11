using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class SuperAngler : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Super Angler Potion");
			// Tooltip.SetDefault("Significantly improves overall fishing ability");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2354);
			Item.value = 10000;
			Item.rare = 2;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.buffType = 122;
			Item.buffTime = 32400;
			}

		public override bool ConsumeItem(Player player) {
			player.AddBuff(Mod.Find<ModBuff>("BigFishing").Type, Item.buffTime);
			player.AddBuff(Mod.Find<ModBuff>("BigCrate").Type, Item.buffTime);
			return true;
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(355);
			recipe.AddIngredient(Mod.Find<ModItem>("AnglerPotion").Type, 1);
			recipe.AddIngredient(314, 2);
			recipe.AddIngredient(Mod.Find<ModItem>("LavaEel").Type, 1);
			recipe.Register();
			}
		}
	}