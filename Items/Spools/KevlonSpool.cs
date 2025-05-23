using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Spools
{
    public class KevlonSpool : _Abstract.RodComponent
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
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