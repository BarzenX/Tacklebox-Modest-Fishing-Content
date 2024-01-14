using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Crates
{
    public class SnowCrate : ModCrate
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Frozen Crate");
            // Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            biomeLoot = new int[]
            {
                ItemID.IceBoomerang,
                ItemID.IceBlade,
                ItemID.IceSkates,
                ItemID.BlizzardinaBottle,
                ItemID.SnowballCannon,
                ItemID.FlurryBoots
            };

            miscLoot = new int[]
            {
                ItemID.IceMachine,
                ItemID.IceMirror,
                ItemID.Extractinator,
                ItemID.Fish
            };
        }
    }
}