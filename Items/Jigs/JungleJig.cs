using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Tacklebox.Items._Global;

namespace Tacklebox.Items.Jigs
{
    public class JungleJig : _Abstract.RodComponent
    {
        public override void SetStaticDefaults()
        {

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