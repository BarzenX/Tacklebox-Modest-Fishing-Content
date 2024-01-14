using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Fish
{
    public class LavaEel : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Infernal Eel");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Bass);
            Item.value = 40000;
            Item.rare = ItemRarityID.Orange;
        }
    }
}