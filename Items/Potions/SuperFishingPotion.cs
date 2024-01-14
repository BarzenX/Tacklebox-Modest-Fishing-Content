using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Potions
{
    public class SuperFishingPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Super Fishing Potion");
            // Tooltip.SetDefault("Increases fishing power a lot");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.FishingPotion);
            Item.value = 10000;
            Item.rare = ItemRarityID.Green;
            Item.maxStack = 30;
            Item.consumable = true;
            Item.buffType = ModContent.BuffType<Buffs.BigFishing>();
            Item.buffTime = 43200;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.AlchemyTable);
            recipe.AddIngredient(ItemID.FishingPotion, 1);
            recipe.AddIngredient(ItemID.Waterleaf, 2);
            recipe.AddIngredient(ItemID.Starfish, 1);
            recipe.Register();
        }
    }
}