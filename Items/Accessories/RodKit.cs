using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Accessories
{
    public class RodKit : RodComponent
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Fishing Rod Kit");
            // Tooltip.SetDefault("Increases fishing skill and crate chance by 5%\nCast two lines at once while fishing");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = 120000;
            Item.rare = ItemRarityID.Orange;
            hookTier = 1;
            reelTier = 1;
            lineCount = 2;
        }

        public override void AddRecipes()
        {
            Recipe recipe;
            recipe = CreateRecipe();
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddIngredient(ModContent.ItemType<Items.Reels.GoldReel>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Hooks.GoldHook>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Spools.BilineSpool>(), 1);
            recipe.Register();
            recipe = CreateRecipe();
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddIngredient(ModContent.ItemType<Items.Reels.PlatinumReel>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Hooks.PlatinumHook>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Spools.BilineSpool>(), 1);
            recipe.Register();
        }
    }
}