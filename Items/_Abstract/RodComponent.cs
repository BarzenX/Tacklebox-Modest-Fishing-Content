using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Items._Abstract
{
    public abstract class RodComponent : ModItem
	{
        //comments see TackleboxPlayer.cs
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
			TackleboxPlayer modplayer = player.GetModPlayer<TackleboxPlayer>();

            if (jigType != 0)   modplayer.JigSet |= jigType;
			if(modplayer.HookTier < hookTier)   modplayer.HookTier = hookTier;
			if(modplayer.ReelTier < reelTier)   modplayer.ReelTier = reelTier;
			if(modplayer.LineCount < lineCount)
			{
				player.accFishingLine = true; // all multilure accessories include the High Test Fishing Line
				modplayer.LineCount = lineCount;
			}
		}
	}
}