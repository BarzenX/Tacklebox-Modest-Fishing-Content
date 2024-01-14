using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Junk
{
    public class Cattail : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Cattail");
            // Tooltip: Nice looking...except when at you fishing hook
        }

        public override void SetDefaults()
        {
            Item.value = 0;
            Item.rare = ItemRarityID.White;
            Item.maxStack = Item.CommonMaxStack;
        }
    }
}