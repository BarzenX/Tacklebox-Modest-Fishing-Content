using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using Terraria.ModLoader.IO;
using Terraria.Localization;

namespace Tacklebox {

	class Tacklebox : Mod {

		public static int[] allCrates = new int[]
		{
			ItemID.WoodenCrate,
			ItemID.IronCrate,
			ItemID.GoldenCrate,
			ItemID.CorruptFishingCrate,
			ItemID.CrimsonFishingCrate,
			ItemID.DungeonFishingCrate,
			ItemID.FloatingIslandFishingCrate,
			ItemID.HallowedFishingCrate,
			ItemID.JungleFishingCrate,
			ItemID.FrozenCrate,
			ItemID.OasisCrate,
			ItemID.LavaCrate,
			ItemID.OceanCrate,

			ItemID.WoodenCrateHard,
			ItemID.IronCrateHard,
			ItemID.GoldenCrateHard,
			ItemID.CorruptFishingCrateHard,
			ItemID.CrimsonFishingCrateHard,
			ItemID.DungeonFishingCrateHard,
			ItemID.FloatingIslandFishingCrateHard,
			ItemID.HallowedFishingCrateHard,
			ItemID.JungleFishingCrateHard,
			ItemID.FrozenCrateHard,
			ItemID.OasisCrateHard,
			ItemID.LavaCrateHard,
			ItemID.OceanCrateHard
		};

		public static int[] basicCrates =
		{
			ItemID.WoodenCrate,
			ItemID.IronCrate,
			ItemID.GoldenCrate,

			ItemID.WoodenCrateHard,
			ItemID.IronCrateHard,
			ItemID.GoldenCrateHard
		};
		public static List<int> modRod = new(); //TODO: why "List<int>" ?
        public static List<int> noLava = new( new int[]
			{
			    ItemID.WoodFishingPole,
			    ItemID.ReinforcedFishingPole,
			    ItemID.FisherofSouls,
			    ItemID.Fleshcatcher,
			    ItemID.FiberglassFishingPole,
			    ItemID.MechanicsRod,
			    ItemID.SittingDucksFishingRod,
			    ItemID.HotlineFishingHook, //TODO: but this one can fish in lava...
				ItemID.GoldenFishingRod,
			    ItemID.ScarabFishingRod,
			    ItemID.BloodFishingRod
			}
		);

		public Tacklebox() 
		{
            //TODO: tModPorter Note: Removed. Instead, assign the properties directly (ContentAutoloadingEnabled, GoreAutoloadingEnabled, MusicAutoloadingEnabled, and BackgroundAutoloadingEnabled)
            //Properties = new ModProperties()
            //         {

            //             Autoload = true
            //};
        }

		//TODO: What's this for?
        //private Recipe CreateRecipe()
        //{
        //    throw new NotImplementedException();
        //}
	}
}