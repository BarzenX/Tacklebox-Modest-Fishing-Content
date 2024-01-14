using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Fish
{
    public class SandShark : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sand Shark");
            // Tooltip.SetDefault("'Quite a catch!'");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Bass);
            Item.value = 37500;
            Item.rare = ItemRarityID.Green;
        }
    }
}