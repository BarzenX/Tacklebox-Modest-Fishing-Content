using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Food
{
    public class CookedShark : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.CookedFish);
            Item.value = 40000;
            Item.rare = ItemRarityID.Green;
            Item.buffType = BuffID.WellFed;
            Item.buffTime = 216000;
        }

        public override bool ConsumeItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<Buffs.Seafood>(), 72000);
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.CookingPots);
            recipe.AddIngredient(ModContent.ItemType<Items.Fish.SandShark>(), 1);
            recipe.Register();
        }
    }
}