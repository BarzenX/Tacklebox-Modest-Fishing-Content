using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Tools
{
    public class Ocarina : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ocarina");
            // Tooltip.SetDefault("Summons rain when played");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Harp);
            Item.value = 62500;
            Item.rare = ItemRarityID.Green;
        }

        public override bool? UseItem(Player player) //TODO: tModPorter Suggestion: Return null instead of false
        {
            Main.rainTime = Main.rand.Next(43200, 86400);
            Main.raining = true;
            Main.maxRaining = Main.rand.Next(20, 60) * 0.01f;
            return base.UseItem(player);
        }
    }
}