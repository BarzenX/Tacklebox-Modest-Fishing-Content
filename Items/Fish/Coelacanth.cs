using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Fish
{
    public class Coelacanth : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Coelacanth");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Bass);
        }
    }
}