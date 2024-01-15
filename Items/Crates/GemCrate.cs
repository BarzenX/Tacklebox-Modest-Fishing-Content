using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Crates
{

    public class GemCrate : _Abstract.ModCrate
    {

        public override void SetStaticDefaults()
        {
            // Disclaimer for both of these sets (as per their docs): They are only checked for vanilla item IDs, but for cross-mod purposes it would be helpful to set them for modded crates too
            ItemID.Sets.IsFishingCrate[Type] = true;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = 100000;
            Item.rare = ItemRarityID.Orange;
        }

        public override void RightClick(Player player)
        {
            var source = player.GetSource_FromThis();

            if (Chance.OneOut(2))   player.QuickSpawnItem(source, ItemID.Amethyst, Main.rand.Next(1,7));
            if (Chance.OneOut(2))   player.QuickSpawnItem(source, ItemID.Topaz, Main.rand.Next(1,7));
            if (Chance.OneOut(3))   player.QuickSpawnItem(source, ItemID.Sapphire, Main.rand.Next(1,6));
            if (Chance.OneOut(3))   player.QuickSpawnItem(source, ItemID.Emerald, Main.rand.Next(1,6));
            if (Chance.OneOut(4))   player.QuickSpawnItem(source, ItemID.Ruby, Main.rand.Next(1,5));
            if (Chance.OneOut(4))   player.QuickSpawnItem(source, ItemID.Diamond, Main.rand.Next(1,4));
            if (Chance.OneOut(48))  player.QuickSpawnItem(source, ModContent.ItemType<Items.Poles.CaveRod>());

            player.QuickSpawnItem(source, ItemID.GoldCoin, Main.rand.Next(1,11));
            player.QuickSpawnItem(source, ItemID.SilverCoin, Main.rand.Next(0, 100));
            player.QuickSpawnItem(source, ItemID.CopperCoin, Main.rand.Next(0, 100));

            if (Main.hardMode)
            {
                if (Chance.OneOut(2)) player.QuickSpawnItem(source, ItemID.CrystalShard, Main.rand.Next(2, 8));
                if (Chance.OneOut(24)) player.QuickSpawnItem(source, ModContent.ItemType<Items.Placeables.Gnomon>());
            }
        }
    }
}