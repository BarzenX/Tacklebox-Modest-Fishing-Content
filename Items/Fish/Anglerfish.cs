using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Fish
{
    public class Anglerfish : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.WaterTorches[this.Type] = true;
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.value = 50000;
            Item.rare = ItemRarityID.Orange;
            Item.holdStyle = 1;
        }

        public override void HoldItem(Player player)
        {
            Lighting.AddLight(
                player.itemLocation,
                0.8f,
                0.4f,
                0.0f
                );
        }

        public override void HoldStyle(Player player, Rectangle heldItemFrame)
        {
            player.itemLocation.X = player.Center.X + (player.direction * 4.0f);
            player.itemLocation.Y = player.Center.Y + (player.gravDir * 16.0f);
        }
    }
}