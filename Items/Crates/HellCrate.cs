using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Crates
{
    public class HellCrate : _Abstract.ModCrate
    {
        public override void SetStaticDefaults()
        {
            // Disclaimer for both of these sets (as per their docs): They are only checked for vanilla item IDs, but for cross-mod purposes it would be helpful to set them for modded crates too
            ItemID.Sets.IsFishingCrate[Type] = true;
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