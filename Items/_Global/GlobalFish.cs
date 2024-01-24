using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using Mono.Cecil;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Tacklebox.Items._Global
{
    public class GlobalFish : GlobalItem
	{
		private static readonly int[] bigFish =
		{
			ItemID.Bass,
			ItemID.Salmon,
			ItemID.AtlanticCod,
			ItemID.Tuna,
			ItemID.RedSnapper,
			ItemID.NeonTetra,
			ItemID.ArmoredCavefish,
			ItemID.CrimsonTigerfish,
			ItemID.VariegatedLardfish,
			ItemID.DoubleCod,
			ItemID.ChaosFish,
			ItemID.Ebonkoi,
			ItemID.Hemopiranha,
			ItemID.Stinkfish
		};

		public override bool IsLoadingEnabled(Mod mod)//TODO: tModPorter Suggestion: If you return false for the purposes of manual loading, use the [Autoload(false)] attribute on your class instead
		{
			return true;
		}

		public override void CaughtFishStack(int type, ref int stack)
		{
            TackleboxPlayer player = Main.LocalPlayer.GetModPlayer<TackleboxPlayer>();
			if(JigID.CheckJig(player.jigSet, JigID.CoinHook))
            {
				var source = Main.LocalPlayer.GetSource_FromThis();
                Main.LocalPlayer.QuickSpawnItem(source, ItemID.SilverCoin, Main.rand.Next(0, 3));
                Main.LocalPlayer.QuickSpawnItem(source, ItemID.CopperCoin, Main.rand.Next(0, 100));
            }

            if ( player.globalBait == ModContent.ItemType<Items.Bait.Guppy>() )
			{
				if (bigFish.Contains(type))   stack = Main.rand.Next(1, 4);
            }
		}

		public override bool ConsumeItem(Item item, Player player)
		{
			if(base.ConsumeItem(item, player))
			{
				if(item.type == ItemID.CookedShrimp || item.type == ItemID.Sashimi)
				{
					player.AddBuff(ModContent.BuffType<Buffs.Seafood>(), 7200);
                }
				return true;
			}
			return false;
		}
	}
}