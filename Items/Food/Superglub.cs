using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Food
{
    public class Superglub : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sweet Sweetglub");
            // Tooltip.SetDefault("'Something with you and honey, huh?'");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.CookedFish);
            Item.value = 40000;
            Item.rare = ItemRarityID.Green;
            Item.buffType = ModContent.BuffType<Buffs.Seafood>();
            Item.buffTime = 32400;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.CookingPots);
            recipe.AddIngredient(ModContent.ItemType<Items.Food.Sweetglub>(), 5);
            recipe.AddIngredient(ItemID.BottledHoney, 1);
            recipe.Register();
        }
    }
}