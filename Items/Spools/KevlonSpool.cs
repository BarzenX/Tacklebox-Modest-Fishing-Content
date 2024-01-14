using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Spools
{
    public class KevlonSpool : RodComponent
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Kevlon Spool");
            // Tooltip.SetDefault("Fishing line never breaks\nCast four lines at once while fishing\n'The power of kevlon!'");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = 200000;
            Item.rare = ItemRarityID.Lime;
            lineCount = 4;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddIngredient(ModContent.ItemType<Items.Spools.BilineSpool>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.KevlonString>(), 2);
            recipe.Register();
        }
    }
}