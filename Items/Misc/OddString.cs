using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Misc
{
    public class OddString : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Suspicious String");
        }

        public override void SetDefaults()
        {
            Item.value = 80000;
            Item.rare = ItemRarityID.Orange;
            Item.maxStack = Item.CommonMaxStack;
        }
    }
}