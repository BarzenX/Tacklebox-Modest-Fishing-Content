using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Crates
{
    public class SandCrate : ModCrate
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Desert Crate");
            // Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            biomeLoot = new int[]
            {
                ItemID.SandstorminaBottle,
                ItemID.PharaohsMask,
                ItemID.PharaohsRobe,
                ItemID.FlyingCarpet,
                ItemID.Sandgun,
                ItemID.SandBoots
            };

            miscLoot = new int[]
            {
                ItemID.GoldenBathtub,
                ItemID.GoldenBed,
                ItemID.GoldenBookcase,
                ItemID.GoldenCandelabra,
                ItemID.GoldenCandle,
                ItemID.GoldenChair,
                ItemID.GoldenChandelier,
                ItemID.GoldenChest,
                ItemID.GoldenClock,
                ItemID.GoldenDoor,
                ItemID.GoldenDresser,
                ItemID.GoldenLamp,
                ItemID.GoldenLantern,
                ItemID.GoldenPiano,
                ItemID.GoldenPlatform,
                ItemID.GoldenShower,
                ItemID.GoldenSink,
                ItemID.GoldenSofa,
                ItemID.GoldenTable,
                ItemID.GoldenToilet,
                ItemID.GoldenWorkbench
            };
        }
    }
}