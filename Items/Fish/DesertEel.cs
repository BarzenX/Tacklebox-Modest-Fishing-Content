using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Fish
{
    public class DesertEel : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Oasis Eel");
            // Tooltip.SetDefault("'Doubles like a snake'");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Bass);
            Item.value = 37500;
            Item.rare = ItemRarityID.Green;
        }
    }
}