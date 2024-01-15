using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Food
{
    public class Frostedfin : ModItem
    {

        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.CookedFish);
            Item.value = 30000;
            Item.rare = ItemRarityID.Blue;
            Item.potion = true;
            Item.healLife = 80;
            Item.buffType = BuffID.RapidHealing;
            Item.buffTime = 7200;
        }

        public override bool ConsumeItem(Player player)
        {
            player.AddBuff(BuffID.Chilled, Item.buffTime / 2);
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.IceMachine);
            recipe.AddIngredient(ItemID.FlarefinKoi);
            recipe.Register();
        }
    }
}