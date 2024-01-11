using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class CaveRod : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Spelunking Rod");
			// Tooltip.SetDefault("'We have to fish deeper!'");
			Tacklebox.modRod.Add(Item.type);
			ItemID.Sets.CanFishInLava[Item.type] = true;
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2289);
			Item.value = 40000;
			Item.rare = 3;
			Item.fishingPole = 25;
			Item.shoot = Mod.Find<ModProjectile>("CaveBobber").Type;
			Item.shootSpeed = 14.0f;
			}
		}
	}