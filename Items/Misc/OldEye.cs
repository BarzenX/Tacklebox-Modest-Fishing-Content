using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Misc
{
    public class OldEye : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Primordial Yeux");
        }

        public override void SetDefaults()
        {
            Item.value = 15000;
            Item.rare = ItemRarityID.White;
            Item.maxStack = Item.CommonMaxStack;
        }
    }
}