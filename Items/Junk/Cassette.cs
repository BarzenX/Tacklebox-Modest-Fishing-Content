using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items.Junk
{
    public class Cassette : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.value = 0;
            Item.rare = -1;
            Item.maxStack = Item.CommonMaxStack;
        }
    }
}