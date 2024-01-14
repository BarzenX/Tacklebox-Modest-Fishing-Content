using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Potions
{
    public class SuperAnglerPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Super Angler Potion");
            // Tooltip.SetDefault("Significantly improves overall fishing ability");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.FishingPotion);
            Item.value = 10000;
            Item.rare = ItemRarityID.Green;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.buffType = BuffID.Sonar;
            Item.buffTime = 32400;
        }

        public override bool ConsumeItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<Buffs.BigFishing>(), Item.buffTime);
            player.AddBuff(ModContent.BuffType<Buffs.BigCrate>(), Item.buffTime);
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.AlchemyTable);
            recipe.AddIngredient(ModContent.ItemType<Items.Potions.AnglerPotion>(), 1);
            recipe.AddIngredient(ItemID.Moonglow, 2);
            recipe.AddIngredient(ModContent.ItemType<Items.Fish.LavaEel>(), 1);
            recipe.Register();
        }
    }
}