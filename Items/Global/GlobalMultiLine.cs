using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class GlobalMultiLine : GlobalItem {

		public override bool IsLoadingEnabled(Mod mod)/* tModPorter Suggestion: If you return false for the purposes of manual loading, use the [Autoload(false)] attribute on your class instead */ {
			return true;
			}

		public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			if(item.fishingPole != 0) {
				int lineCount = player.GetModPlayer<TackleboxPlayer>(Mod).lineCount;
				if(item.type == Mod.Find<ModItem>("TwinPole").Type) {
					lineCount += 1 + (int)System.Math.Log(lineCount, 2);
					}
				if(Tacklebox.modRod.Contains(item.type)) {
					position.X += (float)(43 * player.direction);
					if(player.direction == -1) {
						position.X -= 13.0f;
						}
					position.Y -= 36.0f * player.gravDir;
					}
				for(int i = 1; i < lineCount; i++) {
					Projectile.NewProjectile(
						position.X + player.direction * (float)i / (float)System.Math.Log(
							(float)lineCount
							),
						position.Y,
						speedX + player.direction * (float)i / (float)System.Math.Log(
							(float)lineCount
							),
						speedY,
						type,
						damage,
						knockBack,
						player.whoAmI
						);
					}
				}
			return base.Shoot(item, player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
			}
		}
	}