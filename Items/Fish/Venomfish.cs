using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Fish
{
    public class Venomfish : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 10;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Bass);
            Item.value = 12500;
            Item.rare = ItemRarityID.Orange;
        }

        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.FlaskofVenom);
            recipe.AddTile(TileID.ImbuingStation);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddIngredient(this, 1);
            recipe.Register();
        }
    }
}