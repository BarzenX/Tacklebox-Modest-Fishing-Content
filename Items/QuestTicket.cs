using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items
{
	public class QuestTicket : ModItem
	{
		public override void SetStaticDefaults()
		{
            Item.ResearchUnlockCount = 5;
        }

		public override void SetDefaults()
		{
			Item.value = 7500;
            Item.rare = ItemRarityID.White;
			Item.maxStack = Item.CommonMaxStack;
			Item.consumable = true;
			Item.useTime = 30;
			Item.useTurn = true;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useAnimation = 15;
            Item.UseSound = SoundID.Item4;
        }

        public override bool? UseItem(Player player)
        {
            return true;
        }

        public override bool ConsumeItem(Player player)
        {
            return true;
        }

        public override void OnConsumeItem(Player player)
        {
            int lastQuest = Main.anglerQuest;

            do Main.AnglerQuestSwap();  // happens really rare but sometimes the new quest fish is the same as the old one...
            while (lastQuest == Main.anglerQuest);
        }

    }
}