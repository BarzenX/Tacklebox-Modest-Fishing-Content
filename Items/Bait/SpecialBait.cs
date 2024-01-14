using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Bait
{

    public class SpecialBait : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Special Bait");
            // Tooltip.SetDefault("Attracts quest fish");
        }

        public override void SetDefaults()
        {
            Item.value = 10000;
            Item.rare = ItemRarityID.Green;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.bait = 20;
        }
    }
}