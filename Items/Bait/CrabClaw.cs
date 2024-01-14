using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Bait
{
    public class CrabClaw : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Crab Claw");
            // Tooltip.SetDefault("Bonus power with Jewel Fishing Rod");
        }

        public override void SetDefaults()
        {
            Item.value = 10000;
            Item.rare = ItemRarityID.White;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.bait = 20;
        }
    }
}