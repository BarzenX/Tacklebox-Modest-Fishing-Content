using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items.Junk
{
    public class Driftwood : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Driftwood");
            // Tooltip: At least it gave you a workout, while dragging it out
        }

        public override void SetDefaults()
        {
            Item.value = 0;
            Item.rare = -1;
            Item.maxStack = Item.CommonMaxStack;
        }
    }
}