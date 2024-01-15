using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Tacklebox.Items._Global
{
    public class GlobalFish : GlobalItem
	{
		private static int[] bigFish =
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
			if((player.jigSet & 16) == 16) //TODO: there has to be a better way!   ...furthermore what does "jigSet" do?
            {
				Main.LocalPlayer.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ItemID.CopperCoin, Main.rand.Next(8, 16000));
			}

			if ( player.bait == ModContent.ItemType<Items.Bait.Guppy>() ) //TODO: was Mod.Find<ModItem>("Guppy").Type)
			{
				if (bigFish.Contains(type))   stack = Main.rand.Next(1, 4); //TODO: was   if(System.Array.IndexOf(bigFish, type) != -1)
            }
		}

		public override bool ConsumeItem(Item item, Player player)
		{
			if(base.ConsumeItem(item, player))
			{
				if(item.type == ItemID.CookedShrimp || item.type == ItemID.Sashimi)
				{
					player.AddBuff(ModContent.BuffType<Buffs.Seafood>(), 7200); //TODO: was    player.AddBuff(Mod.Find<ModBuff>("Seafood").Type, 7200);
                }
				return true;
			}
			return false;
		}
	}
}