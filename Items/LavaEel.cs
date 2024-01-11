using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class LavaEel : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Infernal Eel");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(2290);
			Item.value = 40000;
			Item.rare = 3;
			}
		}
	}