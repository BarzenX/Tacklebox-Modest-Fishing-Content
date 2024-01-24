using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace Tacklebox.Items.Misc
{
    public class Gnomon : ModItem
    {
        // Step 1: Make a static LocalizedText property
        public static LocalizedText ReducedCooldownMessage { get; private set; }
        public override void SetStaticDefaults()
        {
            // Step 2: Assign ReducedCooldownMessage to the result of GetLocalization
            ReducedCooldownMessage = this.GetLocalization(nameof(ReducedCooldownMessage));

            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.value = 40000;
            Item.rare = ItemRarityID.Green;
            Item.maxStack = 1; //only one as it won't be consumed on use
        }
    }
}