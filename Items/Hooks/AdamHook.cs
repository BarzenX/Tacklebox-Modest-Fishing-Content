using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Hooks
{
    public class AdamHook : RodComponent
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Adamantite Hook");
            // Tooltip.SetDefault("Increases fishing skill");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = 80000;
            Item.rare = ItemRarityID.Orange;
            hookTier = 2;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddIngredient(ItemID.AdamantiteBar, 4);
            recipe.Register();
        }
    }
}