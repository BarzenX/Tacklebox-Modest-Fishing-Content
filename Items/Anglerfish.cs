using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class Anglerfish : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Anglerfish");
			// Tooltip.SetDefault("Provides light when held");
			}

		public override void SetDefaults() {
			Item.value = 50000;
			Item.rare = 3;
			Item.holdStyle = 1;
			}

		public override void HoldItem(Player player) {
			Lighting.AddLight(
				player.itemLocation,
				0.8f,
				0.4f,
				0.0f
				);
			}

		public override void HoldStyle(Player player, Rectangle heldItemFrame) {
			player.itemLocation.X = player.Center.X + 4.0f * player.direction;
			player.itemLocation.Y = player.Center.Y + 16.0f * player.gravDir;
			}

		public override void AutoLightSelect(ref bool dryTorch, ref bool wetTorch, ref bool glowstick)/* tModPorter Note: Removed. Use ItemID.Sets.Torches[Type], ItemID.Sets.WaterTorches[Type], and ItemID.Sets.Glowsticks[Type] in SetStaticDefaults */ {
			wetTorch = true;
			}
		}
	}