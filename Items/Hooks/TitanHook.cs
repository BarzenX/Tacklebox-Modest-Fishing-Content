using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Hooks
{
    public class TitanHook : RodComponent
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Titanium Hook");
            // Tooltip.SetDefault("Increases fishing skill");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = ItemRarityID.Orange;
            hookTier = 2;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddIngredient(ItemID.TitaniumBar, 4);
            recipe.Register();
        }
    }
}