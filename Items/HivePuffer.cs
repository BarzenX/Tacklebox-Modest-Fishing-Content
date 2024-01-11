using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class HivePuffer : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Hive Puffer");
			// Tooltip.SetDefault("'It's... buzzing!'");
			}

		public override void SetDefaults() {
			Item.CloneDefaults(1121);
			Item.value = 75000;
			Item.rare = 2;
			Item.scale = 1.0f;
			Item.useTime = 6;
			Item.damage = 6;
			Item.knockBack = 1.0f;
			Item.mana = 0;
			Item.magic = false/* tModPorter Suggestion: Remove. See Item.DamageType */;
			Item.DamageType = DamageClass.Ranged;
			}
		}
	}