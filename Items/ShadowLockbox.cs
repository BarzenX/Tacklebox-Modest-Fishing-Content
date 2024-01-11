using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public class ShadowLockbox : ModItem {

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Shadow Lock Box");
			// Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}\nRequires a Shadow Key");
			}

		public override void SetDefaults() {
			Item.value = 50000;
			Item.rare = 2;
			Item.maxStack = 99;
			Item.consumable = true;
			}

		public override bool CanRightClick() {
			return Main.LocalPlayer.HasItem(329);
			}

		public override void RightClick(Player player) {
			SoundEngine.PlaySound(SoundID.Unlock);
			int biomeReward = 0;
			switch(Main.rand.Next(5)) {
				case 0:
					biomeReward = 274;
					break;
				case 1:
					biomeReward = 218;
					break;
				case 2:
					biomeReward = 112;
					break;
				case 3:
					biomeReward = 220;
					break;
				case 4:
					biomeReward = 3019;
					break;
				}
			player.QuickSpawnItem(biomeReward);
			if(Main.rand.Next(3) == 0) {
				player.QuickSpawnItem(167);
				}
			if(Main.rand.Next(2) == 0) {
				int bars = 19;
				if(Main.rand.Next(2) == 0) {
					bars = 117;
					}
				player.QuickSpawnItem(bars, 15 + Main.rand.Next(15));
				}
			if(Main.rand.Next(2) == 0) {
				int ammo = 265;
				if(Main.rand.Next(2) == 0) {
					ammo = 278;
					}
				player.QuickSpawnItem(ammo, 50 + Main.rand.Next(25));
				}
			if(Main.rand.Next(2) == 0) {
				int potion = 226;
				if(Main.rand.Next(2) == 0) {
					potion = 227;
					}
				player.QuickSpawnItem(potion, 15 + Main.rand.Next(15));
				}
			if(Main.rand.Next(2) == 0) {
				int potion = 0;
				switch(Main.rand.Next(7)) {
					case 0:
						potion = 296;
						break;
					case 1:
						potion = 295;
						break;
					case 2:
						potion = 293;
						break;
					case 3:
						potion = 288;
						break;
					case 4:
						potion = 294;
						break;
					case 5:
						potion = 297;
						break;
					case 6:
						potion = 304;
						break;
					}
				player.QuickSpawnItem(potion, 1 + Main.rand.Next(2));
				}
			if(Main.rand.Next(2) == 0) {
				int potion = 0;
				switch(Main.rand.Next(5)) {
					case 0:
						potion = 305;
						break;
					case 1:
						potion = 301;
						break;
					case 2:
						potion = 302;
						break;
					case 3:
						potion = 288;
						break;
					case 4:
						potion = 300;
						break;
					}
				player.QuickSpawnItem(potion, 1 + Main.rand.Next(2));
				}
			if(Main.rand.Next(2) == 0) {
				int torch = 4;
				if(Main.rand.Next(2) == 0) {
					torch = 282;
					}
				player.QuickSpawnItem(torch, 15 + Main.rand.Next(15));
				}
			if(Main.rand.Next(2) == 0) {
				player.QuickSpawnItem(73, 2 + Main.rand.Next(3));
				}
			}
		}
	}