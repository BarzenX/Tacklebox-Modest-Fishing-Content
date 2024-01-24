using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Tacklebox.Items._Global;

namespace Tacklebox.Items.Hooks
{
    public class CoinHook : _Abstract.RodComponent
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = 100000;
            Item.rare = ItemRarityID.Orange;
            hookTier = 2;
            jigType = JigID.CoinHook;
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