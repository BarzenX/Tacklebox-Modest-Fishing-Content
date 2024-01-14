using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Spools
{
    public class BilineSpool : RodComponent
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Biline Spool");
            // Tooltip.SetDefault("Fishing line never breaks\nCast two lines at once while fishing");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = 100000;
            Item.rare = ItemRarityID.Green;
            lineCount = 2;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddIngredient(ItemID.HighTestFishingLine, 2);
            recipe.Register();
        }
    }
}