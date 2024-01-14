using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Reels
{
    public class PlatinumReel : RodComponent
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Platinum Reel");
            // Tooltip.SetDefault("Increases chance to fish crates");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = 40000;
            Item.rare = ItemRarityID.Blue;
            reelTier = 1;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.Anvils);
            recipe.AddIngredient(ItemID.PlatinumBar, 4);
            recipe.AddIngredient(ItemID.WhiteString, 1);
            recipe.Register();
        }
    }
}