using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Misc
{

    public class OldScale : ModItem
    {

        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.value = 15000;
            Item.rare = ItemRarityID.White;
            Item.maxStack = Item.CommonMaxStack;
        }
    }
}