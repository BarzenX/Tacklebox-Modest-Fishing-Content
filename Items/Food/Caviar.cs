using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Food
{
    public class Caviar : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.CookedFish);
            Item.value = 40000;
            Item.rare = ItemRarityID.Blue;
            Item.healLife = 20;
            Item.buffType = BuffID.Frozen;
            Item.buffTime = 1800;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.IceMachine);
            recipe.AddIngredient(ModContent.ItemType<Items.Fish.Sturgeon>(), 1); 
            recipe.Register();
        }
    }
}