using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Tacklebox.Items._Global
{
    public class GlobalMultiLine : GlobalItem
    {
        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (item.fishingPole != 0 && (Main.myPlayer == player.whoAmI))
            {
                int playerLineCount = player.GetModPlayer<TackleboxPlayer>().LineCount;
                if (item.type == ModContent.ItemType<Poles.TwinPole>())   playerLineCount += 1;

                for (int i = playerLineCount; i > 1; i--) // from right to left because each new bopper will draw it's line in front of the last one...looks prettier that way
                {
                    Projectile.NewProjectile(
                        source,
                        position.X + player.direction * (float)(i-1), //to disperse the boppers a little bit so they are nicely placed in the water
                        position.Y,
                        velocity.X + player.direction * (float)(i-1) *2f, //to disperse the boppers a little more so they are nicely placed in the water
                        velocity.Y,
                        type,
                        damage,
                        knockback,
                        player.whoAmI
                        );
                }
            }
            return base.Shoot(item, player, source, position, velocity, type, damage, knockback);
        }
    }
}