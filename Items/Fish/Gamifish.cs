using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Fish
{
    public class Gamifish : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Origami Fish");
            // Tooltip.SetDefault("'Is it a fish or paper?'");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Bass);
            Item.value = 25000;
        }
    }
}