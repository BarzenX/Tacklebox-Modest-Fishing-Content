using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Projectiles
{
	public class FlyfishP : ModProjectile
	{
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.FrostDaggerfish);

            Projectile.width = 16; // The width of projectile hitbox
            Projectile.height = 16; // The height of projectile hitbox
            Projectile.aiStyle = 0; // The ai style of the projectile (0 means custom AI). For more please reference the source code of Terraria
            Projectile.friendly = true; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
            Projectile.DamageType = DamageClass.Ranged; // Makes the projectile deal ranged damage. You can set in to DamageClass.Throwing, but that is not used by any vanilla items
            Projectile.penetrate = 1; // How many monsters the projectile can penetrate.
            Projectile.timeLeft = 600; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            //Projectile.light = 0.5f; // How much light emit around the projectile
            Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true; // Can the projectile collide with tiles?
        }

        private const int GravityDelay = 45;
        public int GravityDelayTimer
        {
            get => (int)Projectile.ai[2];
            set => Projectile.ai[2] = value;
        }

        public override void AI()
        {
            NormalAI();
        }

        private void NormalAI()
        {
            GravityDelayTimer++; // doesn't make sense.

            // For a little while, the javelin will travel with the same speed, but after this, the javelin drops velocity very quickly.
            if (GravityDelayTimer >= GravityDelay)
            {
                GravityDelayTimer = GravityDelay;

                // wind resistance
                Projectile.velocity.X *= 0.98f;
                // gravity
                Projectile.velocity.Y += 0.35f;
            }

            // Let the projectile point in the direction of velocity
            // Offset the rotation by 90 degrees because the sprite is oriented vertically.
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);

            Projectile.spriteDirection = Projectile.direction;


            // Spawn some random dusts as the javelin travels
            if (Main.rand.NextBool(3))
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.height, Projectile.width, DustID.Water_Cavern, Projectile.velocity.X * .2f, Projectile.velocity.Y * .2f, 200, Scale: 1.2f);
                dust.velocity += Projectile.velocity * 0.3f;
                dust.velocity *= 0.2f;
            }
            if (Main.rand.NextBool(4))
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.height, Projectile.width, DustID.Water_Cavern,
                    0, 0, 254, Scale: 0.3f);
                dust.velocity += Projectile.velocity * 0.5f;
                dust.velocity *= 0.5f;
            }
        }


        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position); // Play a death sound
            Vector2 usePos = Projectile.position; // Position to use for dusts

            // Offset the rotation by 0 degrees because the sprite is oriented vertically.
            Vector2 rotationVector = (Projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2(); // rotation vector to use for dust velocity
            usePos += rotationVector * 16f;

            // Spawn some dusts upon javelin death
            for (int i = 0; i < 20; i++)
            {
                // Create a new dust
                Dust dust = Dust.NewDustDirect(usePos, Projectile.width, Projectile.height, DustID.Water_Cavern);
                dust.position = (dust.position + Projectile.Center) / 2f;
                dust.velocity += rotationVector * 2f;
                dust.velocity *= 0.5f;
                dust.noGravity = true;
                usePos -= rotationVector * 8f;
            }

            // Make sure to only spawn items if you are the projectile owner.
            // This is an important check as Kill() is called on clients, and you only want the item to drop once
            if (Projectile.owner == Main.myPlayer)
            {
                // Drop a javelin item, 1 in 18 chance (~5.5% chance)
                int item = 0;
                if (Main.rand.NextBool(18))
                {
                    item = Item.NewItem(Projectile.GetSource_DropAsItem(), Projectile.getRect(), ModContent.ItemType<Items.Fish.Flyfish>());
                }

                // Sync the drop for multiplayer
                // Note the usage of Terraria.ID.MessageID, please use this!
                if (Main.netMode == NetmodeID.MultiplayerClient && item >= 0)
                {
                    NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item, 1f);
                }
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.velocity = (target.Center - Projectile.Center) *
                0.75f; // Change velocity based on delta center of targets (difference between entity centers)
            Projectile.netUpdate = true; // netUpdate this javelin

        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
        {
            // For going through platforms and such, javelins use a tad smaller size
            width = height = 10; // notice we set the width to the height, the height to 10. so both are 10
            return true;
        }

        //public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        //{
        //    // By shrinking target hitboxes by a small amount, this projectile only hits if it more directly hits the target.
        //    // This helps the javelin stick in a visually appealing place within the target sprite.
        //    if (targetHitbox.Width > 8 && targetHitbox.Height > 8)
        //    {
        //        targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
        //    }
        //    // Return if the hitboxes intersects, which means the javelin collides or not
        //    return projHitbox.Intersects(targetHitbox);
        //}
    }
}