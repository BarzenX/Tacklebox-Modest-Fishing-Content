using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Fish
{
    public class Sardine : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sardine");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Bass);
        }
    }
}