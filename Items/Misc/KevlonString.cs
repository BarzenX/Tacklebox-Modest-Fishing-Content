using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Misc
{
    public class KevlonString : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Kevlon String");
        }

        public override void SetDefaults()
        {
            Item.value = 20000;
            Item.rare = ItemRarityID.Green;
            Item.maxStack = Item.CommonMaxStack;
        }
    }
}