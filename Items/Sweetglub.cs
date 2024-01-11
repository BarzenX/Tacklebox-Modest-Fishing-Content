using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class Sweetglub : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Sweetglub");
			// Tooltip.SetDefault("'Honeyed fish!'");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2425);
			Item.value = 20000;
			Item.rare = 1;
			Item.buffType = Mod.Find<ModBuff>("Seafood").Type;
			Item.buffTime = 10800;
			}
		}
	}