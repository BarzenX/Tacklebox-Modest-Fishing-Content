using Tacklebox.Items._Global;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Jigs
{
    public class SnowJig : _Abstract.RodComponent
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
            jigType = JigID.SnowJig;
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