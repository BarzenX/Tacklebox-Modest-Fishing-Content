using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Accessories
{
    public class SonarStick : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sonar Stick");
            // Tooltip.SetDefault("Shows what's on your hook");
        }

        public override void SetDefaults()
        {
            Item.value = 50000;
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
            Item.buffType = 122;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<TackleboxPlayer>().sonarActive = true;
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