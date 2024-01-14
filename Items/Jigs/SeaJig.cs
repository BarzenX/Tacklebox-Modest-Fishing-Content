using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Jigs
{
    public class SeaJig : RodComponent
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ocean Jig");
            // Tooltip.SetDefault("Allows catching unique Ocean fish");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = 400000;
            Item.rare = ItemRarityID.Yellow;
            jigType = 1;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.DemonAltar);
            recipe.AddIngredient(ItemID.HallowedKey, 1);
            recipe.AddIngredient(ItemID.Tuna, 100);
            recipe.AddIngredient(ItemID.RedSnapper, 100);
            recipe.AddIngredient(ItemID.Shrimp, 100);
            recipe.Register();
        }
    }
}