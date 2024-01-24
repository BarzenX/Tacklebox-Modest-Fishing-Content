using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items
{
	public class Plankton : ModItem
	{
		public override void SetStaticDefaults()
		{
            Item.ResearchUnlockCount = 1;
        }

		public override void SetDefaults()
		{
            Item.CloneDefaults(ItemID.ShrimpyTruffle);
			Item.expert = false;
			Item.value = 375000;
			// item.mountType = mod.MountType("AncientRay");
		}
	}
}