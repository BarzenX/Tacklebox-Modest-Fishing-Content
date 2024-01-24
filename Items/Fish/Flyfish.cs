using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Fish
{
    public class Flyfish : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 10;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.FrostDaggerfish);
            Item.shoot = ModContent.ProjectileType<Projectiles.FlyfishP>(); 
            Item.damage = 8;
            Item.knockBack = 4f;
            Item.autoReuse = true;
        }

        public override void CaughtFishStack(ref int stack)
        {
            stack = Main.rand.Next(4,24);
        }
    }
}