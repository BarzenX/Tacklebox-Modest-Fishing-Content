using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Fish
{
    public class Clusterfish : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 10;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Bass);
            Item.value = 37500;
            Item.rare = ItemRarityID.Green;
        }

        public override void CaughtFishStack(ref int stack)
        {
            stack = Main.rand.Next(1,4);
        }
    }
}