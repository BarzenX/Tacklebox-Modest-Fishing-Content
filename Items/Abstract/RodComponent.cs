using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items {

	public abstract class RodComponent : ModItem {

		protected int jigType = 0;
		protected int lineCount = 0;
		protected int hookValue = 0;
		protected int reelValue = 0;

		protected override bool CloneNewInstances {
			get {
				return true;
				}
			}

		public override void SetDefaults() {
			Item.accessory = true;
			}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			TackleboxPlayer modplayer = player.GetModPlayer<TackleboxPlayer>(Mod);
			if(jigType != 0) {
				modplayer.jigSet |= jigType;
				}
			if(modplayer.hookValue < hookValue) {
				modplayer.hookValue = hookValue;
				}
			if(modplayer.reelValue < reelValue) {
				modplayer.reelValue = reelValue;
				}
			if(modplayer.lineCount < lineCount) {
				player.accFishingLine = true;
				modplayer.lineCount = lineCount;
				}
			}
		}
	}