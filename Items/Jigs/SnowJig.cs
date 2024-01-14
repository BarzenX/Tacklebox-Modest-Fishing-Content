using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Jigs
{
    public class SnowJig : RodComponent
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Frozen Jig");
            // Tooltip.SetDefault("Allows catching unique Tundra fish");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = 400000;
            Item.rare = ItemRarityID.Yellow;
            jigType = 2;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.DemonAltar);
            recipe.AddIngredient(ItemID.FrozenKey, 1);
            recipe.AddIngredient(ItemID.AtlanticCod, 100);
            recipe.AddIngredient(ItemID.FrostMinnow, 100);
            recipe.AddIngredient(ModContent.ItemType<Items.Fish.Sturgeon>(), 100);
            recipe.Register();
        }
    }
}