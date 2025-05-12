using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Fish
{
    public class Coelacanth : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 10;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Bass);
        }
    }
}