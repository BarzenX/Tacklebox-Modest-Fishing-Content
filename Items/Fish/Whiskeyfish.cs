using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Fish
{
    public class Whiskeyfish : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Whiskeyfish");
            // Tooltip.SetDefault("'This fish looks... inebriated'");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Bass);
            Item.value = 25000;
            Item.rare = ItemRarityID.Blue;
        }
    }
}