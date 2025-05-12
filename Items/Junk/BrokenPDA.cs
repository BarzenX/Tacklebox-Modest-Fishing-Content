using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Junk
{
    public class BrokenPDA : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ExtractinatorMode[this.Type] = ItemID.OldShoe; //When using with the Extractinator this item shall behave exactly like the old shoe
            Item.ResearchUnlockCount = 10;
        }

        public override void SetDefaults()
        {
            Item.value = 0;
            Item.rare = -1;
            Item.maxStack = Item.CommonMaxStack;

            //for extractinator use
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.consumable = true;
            Item.useTurn = true;
            Item.autoReuse = true;
        }
    }
}