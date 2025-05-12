using System.Collections.Generic;
using Tacklebox.Items.Bait;
using Tacklebox.Items.Misc;
using Tacklebox.Items.Poles;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items._Global
{
    public class DropItems : GlobalNPC
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

        public override void ModifyNPCLoot(NPC npc, NPCLoot loot)
        {
            if (npc.type == NPCID.Crab)
            {
                if (npc.SpawnedFromStatue) loot.Add(ItemDropRule.Common(ModContent.ItemType<CrabClaw>(),  2)); // 50%
                else                       loot.Add(ItemDropRule.Common(ModContent.ItemType<CrabClaw>(), 10)); // 10%
            }

            if (npc.type == NPCID.FlyingFish) loot.Add(ItemDropRule.Common(ModContent.ItemType<Guppy>(), 4)); // 25%

            if (npc.type == NPCID.Angler)
            {
                loot.Add(ItemDropRule.Common(ItemID.WoodFishingPole, 4)); // 25%
                loot.Add(ItemDropRule.Common(ModContent.ItemType<JuniorPole>(), 4)); // 25%
            }

            if (npc.type == NPCID.DukeFishron) loot.Add(ItemDropRule.Common(ModContent.ItemType<KevlonString>(), 1)); // 100%

            if (npc.type == NPCID.MoonLordCore) loot.Add(ItemDropRule.Common(ModContent.ItemType<OddString>(), 1)); // 100%
        }
	}
}