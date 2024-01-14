using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections;

namespace Tacklebox.NPCs
{
    public class GlobalLoot : GlobalNPC
	{
		//TODO: I think Fooksie wanted to create an Angler Shop...There are other mods doing this. So keep the task for later
  //      private static int[] anglerShop = 
		//	[
		//		ItemID.SonarPotion,
  //              ItemID.FishingPotion,
  //              ItemID.CratePotion,
  //              ItemID.ApprenticeBait,
  //              ItemID.JourneymanBait,
  //              ItemID.MasterBait,
  //              ItemID.SuperAbsorbantSponge,
  //              ItemID.BottomlessBucket,
  //              ItemID.FinWings
  //          ];
		//private static int[] anglerShopQuestsDone = 
		//	[
		//		10,
		//		20,
		//		40,
		//		10,
		//		20,
		//		40,
		//		80,
		//		80,
		//		60
		//	];
		//private static int[] anglerShopFlags = 
		//	[ 
		//		0,
		//		0,
		//		0,
		//		0,
		//		0,
		//		0,
		//		1,
		//		1,
		//		3
		//	];

		//public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
		//{
  //          if (npc.type == NPCID.Angler)
		//	{
		//		int quests = Main.player[Main.myPlayer].anglerQuestsFinished;
		//		for(int i = 0; i < anglerShop.Length; i++)
		//		{
		//			if(quests >= anglerShopQuestsDone[i]) {
		//				if((anglerShopFlags[i] & 1) == 1 && !Main.hardMode)   continue;
		//				if((anglerShopFlags[i] & 2) == 2 && !Main.raining)   continue;
		//				items[++nextSlot].SetDefaults(anglerShop[i]);
		//			}
		//		}
		//	}
		//}

		public override void OnKill(NPC npc)
        {
			List<int> loot = new List<int> { };
            if (npc.type == NPCID.Crab)
			{
				if((npc.SpawnedFromStatue && Chance.OneOut(10)) || !npc.SpawnedFromStatue)   loot.Add(Mod.Find<ModItem>("CrabClaw").Type);
			}
			else if(npc.type == NPCID.FlyingFish)
			{
				if(Chance.OneOut(2))   loot.Add(ModContent.ItemType<Items.Bait.Guppy>());
			}
			else if(npc.type == NPCID.Angler)
			{
				if(Chance.OneOut(4))   loot.Add(ItemID.WoodFishingPole);
				else if(Chance.OneOut(4))   loot.Add(ModContent.ItemType<Items.Poles.JuniorPole>());
			}
			else if(npc.type == NPCID.DukeFishron)
			{
				loot.Add(ModContent.ItemType<Items.Misc.KevlonString>());
			}
			else if(npc.type == NPCID.MoonLordCore)
			{
				loot.Add(ModContent.ItemType<Items.Misc.OddString>());
			}
			foreach(int item in loot)
			{
                Item.NewItem(
                    npc.GetSource_FromThis(),
                    (int)npc.position.X,
					(int)npc.position.Y,
					npc.width,
					npc.height,
					item,
					1
					);
			}
        }
	}
}