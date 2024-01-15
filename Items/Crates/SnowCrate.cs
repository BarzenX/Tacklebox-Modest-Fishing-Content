using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Crates
{
    public class SnowCrate : _Abstract.ModCrate
    {

        public override void SetStaticDefaults()
        {
            // Disclaimer for both of these sets (as per their docs): They are only checked for vanilla item IDs, but for cross-mod purposes it would be helpful to set them for modded crates too
            ItemID.Sets.IsFishingCrate[Type] = true;
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
                ItemID.FlurryBoots,
                ItemID.IceMirror,
            };

            miscLoot = new int[]
            {
                ItemID.IceMachine,
                ItemID.Extractinator,
                ItemID.Fish
            };
        }
    }
}