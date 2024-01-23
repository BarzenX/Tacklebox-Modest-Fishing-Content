using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Tacklebox.Items.Misc;

namespace Tacklebox.Tiles
{
    public class GlobalGnomon : GlobalTile
    {
        public override void RightClick(int i, int j, int type)
		{
			if(type == TileID.Sundial)
			{
                base.RightClick(i, j, type); // call the normal use of the sundial
				if(Main.sundialCooldown > 4)
				{
                    int oldCooldown = Main.sundialCooldown;
                    if (Main.LocalPlayer.HasItem(ModContent.ItemType<Items.Misc.Gnomon>()))
					{
                        Main.sundialCooldown = 4;

                        // Step 3: Retrieve the localized text. This example uses the Format method because it has placeholders to populate. The "Value" property could be used otherwise.
                        Main.NewText(Gnomon.ReducedCooldownMessage.Format(oldCooldown, Main.sundialCooldown));
                    }
				}
			}
		}
	}
}