using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Fish
{
    public class Boxfish : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Boxfish");
            // Tooltip.SetDefault("'A funny-looking fish'");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Bass);
            Item.value = 40000;
            Item.rare = ItemRarityID.Blue;
        }
    }
}