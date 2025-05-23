using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Bait
{
    public class Glowfly : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 10;
        }

        public override void SetDefaults()
        {
            Item.value = 40000;
            Item.rare = ItemRarityID.LightRed;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.bait = 60;
        }

        public override void AddRecipes()
        {
            Recipe recipe;
            recipe = CreateRecipe();
            recipe.AddTile(TileID.Heart);
            recipe.AddIngredient(ItemID.GlowingSnail, 1);
            recipe.AddIngredient(ItemID.LightningBug, 1);
            recipe.Register();

            recipe = CreateRecipe();
            recipe.AddTile(TileID.HangingLanterns);
            recipe.AddIngredient(ItemID.GlowingSnail, 1);
            recipe.AddIngredient(ItemID.LightningBug, 1);
            recipe.Register();
        }
    }
}