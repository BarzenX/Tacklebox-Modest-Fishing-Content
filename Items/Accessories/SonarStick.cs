using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Accessories
{
    public class SonarStick : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.value = 50000;
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
            Item.maxStack = 1;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(BuffID.Sonar, 30); //2 ticks will hide the remaining buff time, so it appears as "never depleating"
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddTile(TileID.WorkBenches);
            recipe.AddIngredient(ModContent.ItemType<Items.Junk.BrokenSonar>(), 1);
            recipe.AddIngredient(ItemID.Radar, 1);
            recipe.AddIngredient(ItemID.SonarPotion, 4);
            recipe.Register();
        }
    }
}