using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Bait
{
    public class Guppy : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Guppy");
            // Tooltip: "Some big fish are crazy for these little tidbits"
        }

        public override void SetDefaults()
        {
            Item.value = 5000;
            Item.rare = ItemRarityID.White;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.bait = 10;
        }

        public override void CaughtFishStack(ref int stack)
        {
            stack = Main.rand.Next(1, 6);
        }
    }
}