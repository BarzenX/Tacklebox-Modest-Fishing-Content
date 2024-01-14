using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Bait
{

    public class GoldJelly : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Gold Jellyfish");
        }

        public override void SetDefaults()
        {
            Item.value = 200000;
            Item.rare = ItemRarityID.Orange;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.bait = 50;
        }
    }
}