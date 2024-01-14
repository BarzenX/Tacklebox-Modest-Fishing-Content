using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items.Junk
{
    public class Cassette : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Cassette");
            // Tooltip Take your music anywhere, it never skips or scratches, just rips, tears or melts!
        }

        public override void SetDefaults()
        {
            Item.value = 0;
            Item.rare = -1;
            Item.maxStack = Item.CommonMaxStack;
        }
    }
}