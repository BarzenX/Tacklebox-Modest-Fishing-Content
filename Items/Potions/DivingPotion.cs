using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Potions
{
    public class DivingPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 10;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.FishingPotion);
            Item.value = 10000;
            Item.rare = ItemRarityID.Green;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.buffType = BuffID.Gills;
            Item.buffTime = 18000;
        }

        public override bool ConsumeItem(Player player)
        {
            player.AddBuff(BuffID.Flipper, Item.buffTime);
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.AlchemyTable);
            recipe.AddIngredient(ItemID.GillsPotion, 1);
            recipe.AddIngredient(ItemID.FlipperPotion, 1);
            recipe.Register();
        }
    }
}