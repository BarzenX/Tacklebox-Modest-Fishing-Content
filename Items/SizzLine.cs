using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class SizzLine : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Sizzling Line");
			// Tooltip.SetDefault("Allows fishing in lava");
			}

		public override void SetDefaults() {
			Item.value = 60000;
			Item.rare = 3;
			Item.accessory = true;
			}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<TackleboxPlayer>(Mod).sizzLine = true;
			foreach(int pole in Tacklebox.noLava) {
				ItemID.Sets.CanFishInLava[pole] = true;
				}
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(134);
			recipe.AddIngredient(Mod.Find<ModItem>("CharredLine").Type, 1);
			recipe.AddIngredient(Mod.Find<ModItem>("LavaEel").Type, 1);
			recipe.Register();
			}
		}
	}