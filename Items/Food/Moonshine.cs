using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Food
{
    public class Moonshine : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Moonshine");
            // Tooltip.SetDefault("Makes you a danger to yourself");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.FishingPotion);
            Item.value = 10000;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.buffType = 0;
            Item.buffTime = 10800;
        }

        public override bool ConsumeItem(Player player)
        {
            if (Chance.OneOut(2))   player.AddBuff(ModContent.BuffType<Buffs.Redonkulous>(), Item.buffTime);
            else   player.AddBuff(ModContent.BuffType<Buffs.DrunkWisdom>(), Item.buffTime);

            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.Bottles);
            recipe.AddIngredient(ItemID.Ale, 1);
            recipe.AddIngredient(ItemID.Moonglow, 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Fish.Whiskeyfish>(), 1);
            recipe.Register();
        }
    }
}