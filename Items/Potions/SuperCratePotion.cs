using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Potions
{
    public class SuperCratePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Super Crate Potion");
            // Tooltip.SetDefault("Increases chance to get a crate a lot");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.FishingPotion);
            Item.value = 10000;
            Item.rare = ItemRarityID.Green;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.buffType = ModContent.BuffType<Buffs.BigCrate>();
            Item.buffTime = 21600;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.AlchemyTable);
            recipe.AddIngredient(ItemID.CratePotion, 1);
            recipe.AddIngredient(ItemID.Blinkroot, 2);
            recipe.AddIngredient(ModContent.ItemType<Fish.Boxfish>(), 1);
            recipe.Register();
        }
    }
}