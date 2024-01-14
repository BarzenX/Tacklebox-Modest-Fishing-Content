using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Crates
{
    public class HellCrate : ModCrate
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Underworld Crate");
            // Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
        }

        public override void RightClick(Player player)
        {
            var source = player.GetSource_FromThis();

            if (Chance.OneOut(40))   player.QuickSpawnItem(source, ModContent.ItemType<Items.Misc.CharredLine>()); 
            player.QuickSpawnItem(source, ItemID.HellfireArrow, Main.rand.Next(6, 21));
            player.QuickSpawnItem(source, ModContent.ItemType<Items.Crates.ShadowLockbox>()); 
            base.RightClick(player);
        }
    }
}