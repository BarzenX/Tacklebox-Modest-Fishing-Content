using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Tools
{
    public class FulgurShark : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Fulgur Shark");
            // Tooltip.SetDefault("'When the depths aren't deep enough'");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ReaverShark);
            Item.value = 400000;
            Item.rare = ItemRarityID.Yellow;
            Item.scale = 1.0f;
            Item.useTime = 8;
            Item.pick = 200;
            Item.damage = 80;
            Item.knockBack = 8.0f;
            Item.tileBoost = 1;
        }
    }
}