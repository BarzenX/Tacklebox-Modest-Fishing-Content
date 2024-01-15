using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Accessories
{
    public class SizzLine : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.value = 60000;
            Item.rare = ItemRarityID.Orange;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<TackleboxPlayer>().sizzLine = true;
            foreach (int pole in Tacklebox.noLava)
            {
                ItemID.Sets.CanFishInLava[pole] = true;
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.CharredLine>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Fish.LavaEel>(), 1);
            recipe.Register();
        }
    }
}