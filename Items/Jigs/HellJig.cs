using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Jigs
{
    public class HellJig : RodComponent
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Infernal Jig");
            // Tooltip.SetDefault("Allows catching unique Underworld fish");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = 400000;
            Item.rare = ItemRarityID.Yellow;
            jigType = 8;
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