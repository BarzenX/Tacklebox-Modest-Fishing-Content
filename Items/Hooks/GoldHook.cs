using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Hooks
{
    public class GoldHook : _Abstract.RodComponent
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = 40000;
            Item.rare = ItemRarityID.Blue;
            hookTier = 1;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.Anvils);
            recipe.AddIngredient(ItemID.GoldBar, 4);
            recipe.Register();
        }
    }
}