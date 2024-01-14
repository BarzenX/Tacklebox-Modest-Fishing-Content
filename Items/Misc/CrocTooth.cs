using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Misc
{

    public class CrocTooth : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Crocodile Tooth");
            // Tooltip.SetDefault("Something is looking for this...");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.AncientHorn);
            Item.value = 125000;
            //TODO: item.mountType = mod.MountType("Crocodile");
        }
    }
}