using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Placeables
{
    public class Gnomon : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Enchanted Gnomon");
            // Tooltip.SetDefault("Reduces cooldown of Enchanted Sundial");
        }

        public override void SetDefaults()
        {
            Item.value = 40000;
            Item.rare = ItemRarityID.Green;
            Item.maxStack = Item.CommonMaxStack;
        }
    }
}