using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Fish
{
    public class Flyfish : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.FrostDaggerfish);
            Item.shoot = ModContent.ProjectileType<Projectiles.FlyfishP>(); 
            Item.damage = 6;
            Item.knockBack = 3.5f;
        }

        public override void CaughtFishStack(ref int stack)
        {
            stack = Main.rand.Next(4,24);
        }
    }
}