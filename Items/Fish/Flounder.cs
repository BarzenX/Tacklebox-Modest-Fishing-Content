using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Fish
{
    public class Flounder : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Flounder");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Bass);
        }
    }
}