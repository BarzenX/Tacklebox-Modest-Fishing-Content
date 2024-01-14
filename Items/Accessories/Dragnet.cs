using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Accessories
{
    public class Dragnet : RodComponent
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Dragnet");
            // Tooltip.SetDefault("Fishing line never breaks\nCast eight lines at once while fishing\n'Those poor fish...'");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = 400000;
            Item.rare = ItemRarityID.Cyan;
            lineCount = 8;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddIngredient(ModContent.ItemType<Items.Spools.BilineSpool>(), 1); 
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.OddString>(), 4); 
            recipe.Register();
        }
    }
}