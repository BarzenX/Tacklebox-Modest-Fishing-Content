using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Fish
{
    public class Angling : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Angling");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Bass);
        }
    }
}