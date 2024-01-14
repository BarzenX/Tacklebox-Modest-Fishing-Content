using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Misc
{
    public class CharredLine : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Charred Line");
            // Tooltip.SetDefault("'This could probably survive lava...'");
        }

        public override void SetDefaults()
        {
            Item.value = 10000;
            Item.rare = ItemRarityID.White;
            Item.maxStack = Item.CommonMaxStack;
        }
    }
}