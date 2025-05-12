using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Misc
{

    public class CrocTooth : ModItem
    {

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.AncientHorn);
            Item.value = 125000;
            //TODO: item.mountType = mod.MountType("Crocodile");
        }
    }
}