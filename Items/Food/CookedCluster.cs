using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Food
{
    public class CookedCluster : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Cooked Colony");
            // Tooltip.SetDefault("'An exotic food with exotic properties'");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.CookedFish);
            Item.value = 20000;
            Item.rare = ItemRarityID.Blue;
            Item.buffType = ModContent.BuffType<Buffs.BaitBuddies>();
            Item.buffTime = 10800;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.CookingPots);
            recipe.AddIngredient(ModContent.ItemType<Items.Fish.Clusterfish>(), 1);
            recipe.Register();
        }
    }
}