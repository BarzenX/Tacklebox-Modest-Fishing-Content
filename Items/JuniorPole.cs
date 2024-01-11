using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class JuniorPole : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Junior Pole");
			// Tooltip.SetDefault("'Some day I'll reel them all...'");
			Tacklebox.modRod.Add(Item.type);
			Tacklebox.noLava.Add(Item.type);
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2289);
			Item.value = 10000;
			Item.rare = 0;
			Item.fishingPole = 10;
			Item.shoot = Mod.Find<ModProjectile>("JuniorBobber").Type;
			Item.shootSpeed = 10.0f;
			}
		}
	}