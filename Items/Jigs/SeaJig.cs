using Tacklebox.Items._Global;
using Terraria;
using Terraria.ID;

namespace Tacklebox.Items.Jigs
{
    public class SeaJig : _Abstract.RodComponent
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = 400000;
            Item.rare = ItemRarityID.Yellow;
            jigType = JigID.SeaJig; 
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