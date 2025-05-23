﻿using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items._Global
{
    public class GlobalItemLootChanges : GlobalItem
	{
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            if ((item.type == ItemID.IronCrate) || (item.type == ItemID.IronCrateHard))
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Junk.BrokenSonar>(), 40)); // broken sonar 1/40 drop chance (2.5%)
            }

            if ((item.type == ItemID.JungleFishingCrate) || (item.type == ItemID.JungleFishingCrateHard))
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Junk.Cattail>(), 4)); // Cattail 1/4 drop chance (25%)
            }  
        }
	}
}
