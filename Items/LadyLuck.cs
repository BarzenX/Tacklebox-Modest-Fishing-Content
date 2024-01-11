using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class LadyLuck : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Lady Luck");
			// Tooltip.SetDefault("Fishing power based on highest Critical Chance");
			Tacklebox.modRod.Add(Item.type);
			Tacklebox.noLava.Add(Item.type);
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2289);
			Item.value = 400000;
			Item.rare = 10;
			Item.fishingPole = 1;
			Item.shoot = Mod.Find<ModProjectile>("LuckyBobber").Type;
			Item.shootSpeed = 16.0f;
			}

		public override void HoldItem(Player player) {
			int bestCrit = 10;
			if(bestCrit < player.GetCritChance(DamageClass.Melee)) {
				bestCrit = player.GetCritChance(DamageClass.Melee);
				}
			if(bestCrit < player.GetCritChance(DamageClass.Ranged)) {
				bestCrit = player.GetCritChance(DamageClass.Ranged);
				}
			if(bestCrit < player.GetCritChance(DamageClass.Magic)) {
				bestCrit = player.GetCritChance(DamageClass.Magic);
				}
			if(bestCrit < player.GetCritChance(DamageClass.Throwing)) {
				bestCrit = player.GetCritChance(DamageClass.Throwing);
				}
			Item.fishingPole = (int)(bestCrit * 0.75f);
			}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddTile(114);
			recipe.AddIngredient(Mod.Find<ModItem>("TheVoyager").Type, 1);
			recipe.AddIngredient(855, 1);
			recipe.AddIngredient(3467, 8);
			recipe.Register();
			}
		}
	}