using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Accessories
{
    public class MegaRodKit : _Abstract.RodComponent
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = 160000;
            Item.rare = ItemRarityID.LightRed;
            hookTier = 2;
            reelTier = 2;
            lineCount = 4;
        }

        public override void AddRecipes()
        {
            Recipe recipe;
            recipe = CreateRecipe();
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddIngredient(ModContent.ItemType<Items.Reels.AdamReel>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Hooks.AdamHook>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Spools.KevlonSpool>(), 1);
            recipe.Register();

            recipe = CreateRecipe();
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddIngredient(ModContent.ItemType<Items.Reels.TitanReel>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Hooks.TitanHook>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Spools.KevlonSpool>(), 1);
            recipe.Register();
        }
    }
}