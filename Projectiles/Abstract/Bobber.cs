using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Projectiles {

	public abstract class Bobber : ModProjectile {

		public bool disco = false;
		public Vector3 light = new Vector3(0.0f, 0.0f, 0.0f);

		public override void SetDefaults() {
			Projectile.CloneDefaults(360);
			DrawOriginOffsetY = -6;
			}
		
		public override bool PreDrawExtras() {
			Player player = Main.player[Projectile.owner];
			if(player.inventory[player.selectedItem].holdStyle > 0) {
				Vector2 pos = new Vector2(
					player.MountedCenter.X + (float)(43 * player.direction),
					player.MountedCenter.Y + player.gfxOffY - 36.0f * player.gravDir
					);
				if (player.direction < 0) {
					pos.X -= 13.0f;
					}
				if (player.gravDir == -1f) {
					pos.Y -= 12.0f;
					}
				pos = player.RotatedRelativePoint(
					pos + new Vector2(8.0f),
					true
					) - new Vector2(8.0f);
				float x = Projectile.position.X + (float)Projectile.width * 0.5f - pos.X;
				float y = Projectile.position.Y + (float)Projectile.height * 0.5f - pos.Y;
				float rotation2 = (float)Math.Atan2((double)y, (double)x) - 1.57f;
				bool flag = x != 0.0f && y != 0.0f;
				if(flag) {
					float z = 12.0f / (float)Math.Sqrt((double)(x * x + y * y));
					pos.X -= x * z;
					pos.Y -= y * z;
					x = Projectile.position.X + (float)Projectile.width * 0.5f - pos.X;
					y = Projectile.position.Y + (float)Projectile.height * 0.5f - pos.Y;
					}
				while (flag) {
					float h = 12.0f;
					float w = (float)Math.Sqrt((double)(x * x + y * y));
					if(float.IsNaN(w)) {
						break;
						}
					if(w < 20.0f) {
						h = w - 8.0f;
						flag = false;
						}
					pos.X += x * (12.0f / w);
					pos.Y += y * (12.0f / w);
					x = Projectile.position.X + (float)Projectile.width * 0.5f - pos.X;
					y = Projectile.position.Y + (float)Projectile.height * 0.1f - pos.Y;
					if (w > 12f) {
						float num19 = 0.3f;
						float num20 = Math.Abs(Projectile.velocity.X) + Math.Abs(Projectile.velocity.Y);
						if (num20 > 16f) {
							num20 = 16f;
							}
						num20 = 1f - num20 / 16f;
						num19 *= num20;
						num20 = w / 80f;
						if (num20 > 1f) {
							num20 = 1f;
							}
						num19 *= num20;
						if (num19 < 0f) {
							num19 = 0f;
							}
						num20 = 1f - Projectile.localAI[0] / 100f;
						num19 *= num20;
						if (y > 0f) {
							y *= 1f + num19;
							x *= 1f - num19;
							}
						else {
							num20 = Math.Abs(Projectile.velocity.X) / 3f;
							if (num20 > 1f) {
								num20 = 1f;
								}
							num20 -= 0.5f;
							num19 *= num20;
							if (num19 > 0f) {
								num19 *= 2f;
								}
							y *= 1f + num19;
							x *= 1f - num19;
							}
						}
					rotation2 = (float)Math.Atan2((double)y, (double)x) - 1.57f;
					Color color2 = Lighting.GetColor(
						(int)(pos.X / 16.0f),
						(int)(pos.Y / 16.0f),
						new Color(200, 200, 200, 100)
						);
					Main.spriteBatch.Draw(
						TextureAssets.FishingLine.Value,
						new Vector2(
							(float)TextureAssets.FishingLine.Value.Width * 0.5f,
							(float)TextureAssets.FishingLine.Value.Height * 0.5f
							) + pos - Main.screenPosition,
						new Rectangle ? (
							new Rectangle(
								0,
								0,
								TextureAssets.FishingLine.Value.Width,
								(int)h
								)
							),
						color2,
						rotation2,
						new Vector2(
							(float)TextureAssets.FishingLine.Value.Width * 0.5f,
							0.0f
							),
						1.0f,
						SpriteEffects.None,
						0.0f
						);
					}
				}
			return false;
			}

		public override bool PreDraw(ref Color lightColor) {
			if(light.X > 0 || light.Y > 0 || light.Z > 0) {
				if(disco) {
					Lighting.AddLight(
						Projectile.Center,
						(float)Main.DiscoR * light.X,
						(float)Main.DiscoG * light.Y,
						(float)Main.DiscoB * light.Z
						);
					}
				else {
					Lighting.AddLight(Projectile.Center, light);
					}
				}
			return true;
			}
		}
	}