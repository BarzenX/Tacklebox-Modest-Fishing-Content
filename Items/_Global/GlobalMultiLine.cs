using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Tacklebox.Items._Global
{
    public class GlobalMultiLine : GlobalItem
    {
        public override bool IsLoadingEnabled(Mod mod) //TODO: tModPorter Suggestion: If you return false for the purposes of manual loading, use the [Autoload(false)] attribute on your class instead
        {
            return true;
        }

        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (item.fishingPole != 0)
            {
                int playerLineCount = player.GetModPlayer<TackleboxPlayer>().lineCount; //TODO: was player.GetModPlayer<TackleboxPlayer>(Mod).lineCount
                if (item.type == ModContent.ItemType<Poles.TwinPole>()) //TODO: was Mod.Find<ModItem>("TwinPole").Type
                {
                    playerLineCount += 1 + (int)Math.Log(playerLineCount, 2); //TODO: why use logarithm? And why use "+= 1"?
                }

                if (Tacklebox.modRod.Contains(item.type))
                {
                    position.X += 43 * player.direction;
                    if (player.direction == -1) position.X -= 13.0f; //TODO: what does this do?

                    position.Y -= 36.0f * player.gravDir;
                }

                for (int i = 1; i < playerLineCount; i++)
                {
                    Projectile.NewProjectile(
                        source,
                        position.X + player.direction * (float)i / (float)Math.Log(playerLineCount),
                        position.Y,
                        velocity.X + player.direction * (float)i / (float)Math.Log(playerLineCount),
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