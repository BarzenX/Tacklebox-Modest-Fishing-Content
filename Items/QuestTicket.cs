using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items
{
	public class QuestTicket : ModItem
	{
		public override void SetStaticDefaults()
		{

		}

		public override void SetDefaults()
		{
			Item.value = 7500;
            Item.rare = ItemRarityID.White;
			Item.maxStack = Item.CommonMaxStack;
			Item.consumable = true;
		}

		public override bool? UseItem(Player player)//TODO: tModPorter Suggestion: Return null instead of false
		{
			Main.AnglerQuestSwap();
			return true;
		}
	}
}