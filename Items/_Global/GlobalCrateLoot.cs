using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items._Global
{
	public class GlobalCrateLoot : GlobalItem
	{
		public override bool IsLoadingEnabled(Mod mod) //TODO: tModPorter Suggestion: If you return false for the purposes of manual loading, use the [Autoload(false)] attribute on your class instead
		{
			return true;
		}

        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            if (item.type == ItemID.IronCrate || item.type == ItemID.IronCrateHard)
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Junk.BrokenSonar>(), 40)); // broken sonar 1/40 drop chance (2.5%)

            if (item.type == ItemID.JungleFishingCrate || item.type == ItemID.JungleFishingCrateHard)
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Junk.Cattail>(), 4)); // broken sonar 1/4 drop chance (25%)
        }
	}
}