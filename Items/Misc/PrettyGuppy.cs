using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Misc
{
    public class PrettyGuppy : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Bass);
            Item.value = 100000;
            Item.rare = ItemRarityID.Green;
        }
    }
}