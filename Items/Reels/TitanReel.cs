using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Reels
{
    public class TitanReel : RodComponent
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Titanium Reel");
            // Tooltip.SetDefault("Increases chance to fish crates");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = 80000;
            Item.rare = ItemRarityID.Orange;
            reelTier = 2;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddIngredient(ItemID.TitaniumBar, 4);
            recipe.AddIngredient(ItemID.WhiteString, 1);
            recipe.Register();
        }
    }
}