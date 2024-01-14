using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Junk
{
    public class BrokenPDA : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Broken PDA");
            // Tooltip.SetDefault("'Almost got your hopes up...'");
        }

        public override void SetDefaults()
        {
            Item.value = 0;
            Item.rare = -1;
            Item.maxStack = Item.CommonMaxStack;
            ItemID.Sets.ExtractinatorMode[this.Type] = ItemID.OldShoe; //When using with the Extractinator this item shall behave exactly like the old shoe
            // Extractinator test it!
        }
    }
}