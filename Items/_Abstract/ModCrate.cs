using Mono.Cecil;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items._Abstract
{
	public abstract class ModCrate : ModItem
	{
		protected int[] biomeLoot = System.Array.Empty<int>();
        protected int[] miscLoot = System.Array.Empty<int>();

		protected override bool CloneNewInstances
		{
			get	{return true;}
		}

		public override void SetDefaults()
		{
			Item.value = 50000;
			Item.rare = ItemRarityID.Green;
			Item.maxStack = Item.CommonMaxStack;
			Item.consumable = true;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			var source = player.GetSource_FromThis(); //TODO: was player.GetSource_OpenItem(Type);

            if (biomeLoot.Length > 0)   player.QuickSpawnItem(source, biomeLoot[Main.rand.Next(biomeLoot.Length)] );


            for (int i = 0; i < miscLoot.Length; i++)
			{
				if (Chance.OneOut( 1 + miscLoot.Length / 2 ))   player.QuickSpawnItem(source, miscLoot[i]);
			}
			
			int item = 0; //init

			// prehardmode bars
			if( !Main.hardMode && Chance.OneOut(4) ||
                 Main.hardMode && Chance.OneOut(18) ) 
			{
                int[] bars =
					{
						ItemID.IronBar,
						ItemID.LeadBar,
						ItemID.SilverBar,
						ItemID.TungstenBar,
						ItemID.GoldBar,
						ItemID.PlatinumBar,
					};
                player.QuickSpawnItem(source, bars[Main.rand.Next(bars.Length)], Main.rand.Next(3, 14)); //TODO: test it
			}

            // hardmode bars
            if (Main.hardMode && Chance.OneOut(8))
			{
                int[] hardBars =
					{
						ItemID.CobaltBar,
						ItemID.MythrilBar,
						ItemID.AdamantiteBar,
						ItemID.PalladiumBar,
						ItemID.OrichalcumBar,
						ItemID.TitaniumBar
					};
                player.QuickSpawnItem(source, hardBars[Main.rand.Next(0, hardBars.Length)], Main.rand.Next(8, 12)); //TODO: test it
			}

            // buff potions
            if (Chance.OneOut(4))
			{
                int[] potions =
					{
						ItemID.FishingPotion,
						ItemID.SonarPotion,
						ItemID.CratePotion,
						ItemID.GillsPotion,
						ItemID.WaterWalkingPotion,
						ItemID.HunterPotion
					};
                player.QuickSpawnItem(source, potions[Main.rand.Next(potions.Length)], Main.rand.Next(2, 6)); //TODO: test it
			}

			// healing + mana potions
			if(Chance.OneOut(2))
			{
				int[] lifeMana =
					{
						ItemID.HealingPotion,
						ItemID.ManaPotion
					};
                if (Main.hardMode)
                {
					lifeMana[0] = ItemID.GreaterHealingPotion;
					lifeMana[1] = ItemID.GreaterManaPotion;
                }
                player.QuickSpawnItem(source, lifeMana[Main.rand.Next(lifeMana.Length)], Main.rand.Next(2, 6)); //TODO: test it
			}

			// bait
			if(Chance.OneOut(2))
			{
				item = ItemID.JourneymanBait;
				if(Chance.OneOut(2))	item = ItemID.MasterBait;
				player.QuickSpawnItem(source, item, Main.rand.Next(2, 6));
			}

			// coins
			if (Chance.OneOut(4))
			{
                player.QuickSpawnItem(source, ItemID.GoldCoin, Main.rand.Next(6, 12));
                player.QuickSpawnItem(source, ItemID.SilverCoin, Main.rand.Next(0, 100));
                player.QuickSpawnItem(source, ItemID.CopperCoin, Main.rand.Next(0, 100));
            }
        }
	}
}