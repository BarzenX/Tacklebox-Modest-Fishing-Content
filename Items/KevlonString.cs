using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class KevlonString : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Kevlon String");
			}

		public override void SetDefaults() {
			Item.value = 20000;
			Item.rare = 2;
			Item.maxStack = 99;
			}
		}
	}