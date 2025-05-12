using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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

		public override void CaughtFishStack(int type, ref int stack)
		{
            TackleboxPlayer player = Main.LocalPlayer.GetModPlayer<TackleboxPlayer>();
			if(JigID.CheckJig(player.JigSet, JigID.CoinHook))
            {
				var source = Main.LocalPlayer.GetSource_FromThis();
                Main.LocalPlayer.QuickSpawnItem(source, ItemID.SilverCoin, Main.rand.Next(0, 3));
                Main.LocalPlayer.QuickSpawnItem(source, ItemID.CopperCoin, Main.rand.Next(0, 100));
            }

            if ( player.GlobalBait == ModContent.ItemType<Items.Bait.Guppy>() )
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