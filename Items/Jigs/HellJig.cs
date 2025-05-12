using Tacklebox.Items._Global;
using Terraria;
using Terraria.ID;

namespace Tacklebox.Items.Jigs
{
    public class HellJig : _Abstract.RodComponent
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
            jigType = JigID.HellJig;
        }

        public override void AddRecipes()
        {
            Recipe recipe;
            recipe = CreateRecipe();
            recipe.AddTile(TileID.DemonAltar);
            recipe.AddIngredient(ItemID.CorruptionKey, 1);
            recipe.AddIngredient(ItemID.FlarefinKoi, 100);
            recipe.AddIngredient(ItemID.Obsidifish, 100);
            recipe.AddIngredient(ItemID.Ebonkoi, 100);
            recipe.Register();

            recipe = CreateRecipe();
            recipe.AddTile(TileID.DemonAltar);
            recipe.AddIngredient(ItemID.CrimsonKey, 1);
            recipe.AddIngredient(ItemID.FlarefinKoi, 100);
            recipe.AddIngredient(ItemID.Obsidifish, 100);
            recipe.AddIngredient(ItemID.CrimsonTigerfish, 100);
            recipe.Register();
        }
    }
}