using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Food
{
    public class LobsterChow : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.CookedFish);
            Item.value = 30000;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.buffType = ModContent.BuffType<Buffs.Seafood>();
            Item.buffTime = 28800;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.CookingPots); ;
            recipe.AddIngredient(ModContent.ItemType<Items.Fish.Lobster>(), 1);
            recipe.Register();
        }
    }
}