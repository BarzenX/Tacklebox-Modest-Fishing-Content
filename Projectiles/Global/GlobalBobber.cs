using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Projectiles {

	public class GlobalBobber : GlobalProjectile {

		public override bool IsLoadingEnabled(Mod mod)/* tModPorter Suggestion: If you return false for the purposes of manual loading, use the [Autoload(false)] attribute on your class instead */ {
			return true;
			}

		public override void AI(Projectile projectile) {
			if(projectile.aiStyle == 61) {
				projectile.localAI[0] ++;
				/*

				int power = Main.player[projectile.owner].FishingLevel();
				this.localAI[1] += (float)(power / 30);
				if ((double) this.localAI[1] > 660.0) {
					this.localAI[1] = 0.0f;
					this.FishingCheck();
					}
				*/
				}
			}
		}
	}