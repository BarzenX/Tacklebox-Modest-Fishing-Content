using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Fish
{
    public class Mushfin : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 10;
        }

        public override void SetDefaults()
        {
            Item.value = 15000;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = Item.CommonMaxStack;
            Item.healLife = 6;
            Item.consumable = true;
            Item.useTime = 30;
            Item.useTurn = true;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.useAnimation = 15;
            Item.UseSound = SoundID.Item2;
        }
    }
}