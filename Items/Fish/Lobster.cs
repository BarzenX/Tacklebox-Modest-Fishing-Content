using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Fish
{
    public class Lobster : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Lobster");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Bass);
            Item.value = 40000;
            Item.rare = ItemRarityID.Green;
        }
    }
}