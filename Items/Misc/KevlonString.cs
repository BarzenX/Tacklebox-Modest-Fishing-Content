using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Misc
{
    public class KevlonString : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 2;
        }

        public override void SetDefaults()
        {
            Item.value = 20000;
            Item.rare = ItemRarityID.Green;
            Item.maxStack = Item.CommonMaxStack;
        }
    }
}