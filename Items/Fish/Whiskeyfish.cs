using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Fish
{
    public class Whiskeyfish : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 10;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Bass);
            Item.value = 25000;
            Item.rare = ItemRarityID.Blue;
        }
    }
}