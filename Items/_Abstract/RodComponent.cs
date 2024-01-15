using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items._Abstract
{
	public abstract class RodComponent : ModItem
	{
        //TODO: find good comments
        protected int jigType = 0;
		protected int lineCount = 0;
		protected int hookTier = 0;
		protected int reelTier = 0;

		protected override bool CloneNewInstances
		{
			get {return true;}
		}

		public override void SetDefaults()
		{
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			TackleboxPlayer modplayer = player.GetModPlayer<TackleboxPlayer>(); //TODO: was "<TackleboxPlayer>(Mod)", check if it makes a hassle

            if (jigType != 0)   modplayer.jigSet |= jigType;
			if(modplayer.hookTier < hookTier)   modplayer.hookTier = hookTier;
			if(modplayer.reelTier < reelTier)   modplayer.reelTier = reelTier;
			if(modplayer.lineCount < lineCount)
			{
				player.accFishingLine = true;
				modplayer.lineCount = lineCount;
			}
		}
	}
}