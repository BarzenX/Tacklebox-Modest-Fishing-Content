using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Food
{
    public class CookedEel : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Cooked Eel");
            // Tooltip.SetDefault("Imbues you with sandy strength");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.CookedFish);
            Item.value = 40000;
            Item.rare = ItemRarityID.Blue;
            Item.buffType = ModContent.BuffType<Buffs.Oasis>();
            Item.buffTime = 14400;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.CookingPots);
            recipe.AddIngredient(ModContent.ItemType<Items.Fish.DesertEel>(), 1);
            recipe.Register();
        }
    }
}