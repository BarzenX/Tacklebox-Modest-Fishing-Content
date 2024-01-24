using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;

namespace Tacklebox.Items.Tools
{
    public class Ocarina : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Harp);
            Item.value = 62500;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = new SoundStyle($"{nameof(Tacklebox)}/Assets/Sounds/Ocarina")
            {
                Volume = 0.9f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.useTime = 270;
            Item.useAnimation = 270; //track is 4.5s long
            Item.useTurn = true;
        }

        public override bool? UseItem(Player player)
        {
            Main.rainTime = Main.rand.Next(43200, 86400);
            Main.raining = true;
            Main.maxRaining = Main.rand.Next(20, 60) * 0.01f;
            return base.UseItem(player);
        }
    }
}