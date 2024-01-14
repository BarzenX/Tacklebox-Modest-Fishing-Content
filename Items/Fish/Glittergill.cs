using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Fish
{
    public class Glittergill : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Glittergill");
            // Tooltip.SetDefault("'All that glitters is gold'");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Bass);
            Item.value = 300000;
            Item.rare = ItemRarityID.Green;
        }
    }
}