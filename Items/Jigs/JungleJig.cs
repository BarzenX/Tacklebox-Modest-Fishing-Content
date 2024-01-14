using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Jigs
{
    public class JungleJig : RodComponent
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Jungle Jig");
            // Tooltip.SetDefault("Allows catching unique Jungle fish");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = 400000;
            Item.rare = ItemRarityID.Yellow;
            jigType = 4;
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