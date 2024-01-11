using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class FulgurShark : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Fulgur Shark");
			// Tooltip.SetDefault("'When the depths aren't deep enough'");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2341);
			Item.value = 400000;
			Item.rare = 8;
			Item.scale = 1.0f;
			Item.useTime = 8;
			Item.pick = 220;
			Item.damage = 80;
			Item.knockBack = 8.0f;
			Item.tileBoost = 8;
			}
		}
	}