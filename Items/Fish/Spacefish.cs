using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Fish
{
    public class Spacefish : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 2;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.LesserManaPotion);
            Item.value = 62500;
            Item.rare = ItemRarityID.Orange;
            Item.maxStack = 1;
            Item.healMana = 60;
            Item.useStyle = ItemUseStyleID.RaiseLamp;
        }

        public override bool ConsumeItem(Player player)
        {
            return false;
        }

        public override bool CanUseItem(Player player)
        {
            return player.FindBuffIndex(BuffID.ManaSickness) == -1;
            
        }
    }
}