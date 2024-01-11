using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class Ocarina : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Ocarina");
			// Tooltip.SetDefault("Summons rain when played");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(508);
			Item.value = 62500;
			Item.rare = 2;
			}

		public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */ {
			Main.rainTime = Main.rand.Next(43200, 86400);
			Main.raining = true;
			Main.maxRaining = (float)Main.rand.Next(20, 60) * 0.01f;
			return base.UseItem(player);
			}
		}
	}