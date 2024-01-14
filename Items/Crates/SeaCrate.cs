using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Crates
{
    public class SeaCrate : ModCrate
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ocean Crate");
            // Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            biomeLoot = new int[]
            {
                ItemID.BreathingReed,
                ItemID.Flipper,
                ItemID.DivingHelmet,
                ItemID.Trident,
                ItemID.WaterWalkingBoots,
                ItemID.JellyfishNecklace
            };

            
            
            miscLoot = new int[]
            {
                ItemID.Coral,
                ItemID.Glowstick,
                ItemID.SharkFin,
                ItemID.PurpleMucos,
                ItemID.BlackInk,
                ItemID.Seashell,
                ItemID.Starfish
            };
        }

        public override void RightClick(Player player)
        {
            var source = player.GetSource_FromThis();

            if (Chance.OneOut(24))   player.QuickSpawnItem(source, ItemID.PirateMap);
            if (Chance.OneOut(32))   player.QuickSpawnItem(source, ModContent.ItemType<Items.Tools.Ocarina>());

            base.RightClick(player);
        }
    }
}