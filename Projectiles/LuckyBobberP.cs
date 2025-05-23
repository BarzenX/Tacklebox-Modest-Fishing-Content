using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Projectiles
{
	public class LuckyBobberP : ModProjectile
	{
        public override void SetDefaults()
        {
            // These are copied through the CloneDefaults method
            // Projectile.width = 14;
            // Projectile.height = 14;
            // Projectile.aiStyle = 61;
            // Projectile.bobber = true;
            // Projectile.penetrate = -1;
            // Projectile.netImportant = true;
            Projectile.CloneDefaults(ProjectileID.BobberWooden);

            DrawOriginOffsetY = -8; // Adjusts the draw position
        }

        // What if we want to randomize the line color
        public override void AI()
        {
            // Always ensure that graphics-related code doesn't run on dedicated servers via this check.
            if (!Main.dedServ)
            {
                // Create some light based on the color of the line.
                Lighting.AddLight(Projectile.Center, new Color(70, 55, 5).ToVector3());
            }
        }

        public override void ModifyFishingLine(ref Vector2 lineOriginOffset, ref Color lineColor)
        {
            // Change these two values in order to change the origin of where the line is being drawn.
            // This will make it draw 47 pixels right and 31 pixels up from the player's center, while they are looking right and in normal gravity.
            lineOriginOffset = new Vector2(49, -33);
        }
    }
}