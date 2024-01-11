using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class XolaRod : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Xola's Fishing Rod");
			// Tooltip.SetDefault("Bait power is doubled");
			Tacklebox.modRod.Add(Item.type);
			Tacklebox.noLava.Add(Item.type);
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2289);
			Item.value = 400000;
			Item.rare = 5;
			Item.fishingPole = 5;
			Item.shoot = Mod.Find<ModProjectile>("XolaBobber").Type;
			Item.shootSpeed = 16.0f;
			}
		}
	}