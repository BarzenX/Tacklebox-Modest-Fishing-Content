using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Misc
{

    public class WaywardBottle : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Wayward Bottle");
            // Tooltip.SetDefault("'What's that inside?'");
        }

        public override void SetDefaults()
        {
            Item.value = 10000;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = Item.CommonMaxStack;
        }
    }
}