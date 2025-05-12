using Tacklebox.Items._Global;
using Terraria;
using Terraria.ID;

namespace Tacklebox.Items.Jigs
{
    public class JungleJig : _Abstract.RodComponent
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
            jigType = JigID.JungleJig; 
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.DemonAltar);
            recipe.AddIngredient(ItemID.JungleKey, 1);
            recipe.AddIngredient(ItemID.NeonTetra, 100);
            recipe.AddIngredient(ItemID.DoubleCod, 100);
            recipe.AddIngredient(ItemID.VariegatedLardfish, 100);
            recipe.Register();
        }
    }
}