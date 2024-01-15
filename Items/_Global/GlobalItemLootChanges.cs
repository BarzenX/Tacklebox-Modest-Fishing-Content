using System;
using System.Linq;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items._Global
{
	public class GlobalItemLootChanges : GlobalItem
	{
		public override void ModifyItemLoot(Item item, ItemLoot itemLoot) {
			if ((item.type == ItemID.LavaCrate) ) { //|| (item.type == ItemID.LavaCrateHard)
                itemLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(20, ModContent.ItemType<Items.Misc.CharredLine>()));
				//foreach (var rule in itemLoot.Get())
				//{
				//	if (rule is OneFromOptionsNotScaledWithLuckDropRule oneFromOptionsDrop && oneFromOptionsDrop.dropIds.Contains(ItemID.FlameWakerBoots))
				//	{
				//		var original = oneFromOptionsDrop.dropIds.ToList();
				//		original.Add(ModContent.ItemType<Items.Misc.CharredLine>());
				//		oneFromOptionsDrop.dropIds = original.ToArray();

				//		//itemLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(ModContent.ItemType<Items.Misc.CharredLine>(), 4, 1, 4));

				//	}
				//}
			}
		}
	}
}
