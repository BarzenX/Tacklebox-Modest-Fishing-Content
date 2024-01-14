using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Fish
{
    public class Pupfish : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Legendary Pupfish");
            // Tooltip.SetDefault("'Sometimes the small ones are the most valuable!'");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Bass);
            Item.value = 3000000;
            Item.rare = ItemRarityID.LightRed;
        }
    }
}