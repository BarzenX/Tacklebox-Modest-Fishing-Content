using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Junk
{
    public class BrokenSonar : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Broken Sonar");
            // Tooltip.SetDefault("'It's missing some parts...'");
        }

        public override void SetDefaults()
        {
            Item.value = 7500;
            Item.rare = ItemRarityID.White;
            Item.maxStack = Item.CommonMaxStack;
        }
    }
}