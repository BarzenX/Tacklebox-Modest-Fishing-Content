using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Tacklebox.Items._Global;

namespace Tacklebox.Items.Jigs
{
    public class JigCollection : _Abstract.RodComponent
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = 800000;
            Item.rare = ItemRarityID.Cyan;
            jigType = JigID.SeaJig + JigID.SnowJig + JigID.JungleJig + JigID.HellJig;
        }

        public override void AddRecipes()
        {
            Recipe recipe;
            recipe = CreateRecipe();
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddIngredient(ModContent.ItemType<Items.Jigs.SeaJig>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Jigs.SnowJig>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Jigs.JungleJig>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Jigs.HellJig>(), 1);
            recipe.Register();
        }
    }
}