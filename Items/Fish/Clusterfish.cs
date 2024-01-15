using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Fish
{
    public class Clusterfish : ModItem
    {
        public override void SetStaticDefaults()
        {

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