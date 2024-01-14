using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Misc
{
    public class PrettyGuppy : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Pristine Guppy");
            // Tooltip.SetDefault("'Worth a pretty penny!'");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Bass);
            Item.value = 100000;
            Item.rare = ItemRarityID.Green;
        }
    }
}