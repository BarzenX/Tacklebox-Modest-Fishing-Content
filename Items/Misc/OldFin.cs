using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Misc
{
    public class OldFin : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Primordial Nageoires");
        }

        public override void SetDefaults()
        {
            Item.value = 15000;
            Item.rare = ItemRarityID.White;
            Item.maxStack = Item.CommonMaxStack;
        }
    }
}