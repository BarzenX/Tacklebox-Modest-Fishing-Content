using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Hooks
{
    public class CoinHook : RodComponent
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Coin Hook");
            // Tooltip.SetDefault("Catch money and fish!");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = 100000;
            Item.rare = ItemRarityID.Orange;
            hookTier = 2;
            jigType = 16;
        }

        public override void AddRecipes()
        {
            Recipe recipe;
            recipe = CreateRecipe();
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddIngredient(ModContent.ItemType<Items.Hooks.AdamHook>(), 1);
            recipe.AddIngredient(ItemID.LuckyCoin, 1);
            recipe.Register();

            recipe = CreateRecipe();
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddIngredient(ModContent.ItemType<Items.Hooks.TitanHook>(), 1);
            recipe.AddIngredient(ItemID.LuckyCoin, 1);
            recipe.Register();
        }
    }
}