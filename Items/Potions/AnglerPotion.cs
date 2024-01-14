using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Potions
{
    public class AnglerPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Angler Potion");
            // Tooltip.SetDefault("Improves overall fishing ability");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.FishingPotion);
            Item.value = 10000;
            Item.rare = ItemRarityID.Green;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.buffType = BuffID.Fishing;
            Item.buffTime = 18000;
        }

        public override bool ConsumeItem(Player player)
        {
            player.AddBuff(BuffID.Sonar, Item.buffTime);
            player.AddBuff(BuffID.Crate, Item.buffTime);
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.AlchemyTable);
            recipe.AddIngredient(ItemID.FishingPotion, 1);
            recipe.AddIngredient(ItemID.SonarPotion, 1);
            recipe.AddIngredient(ItemID.CratePotion, 1);
            recipe.Register();
        }
    }
}