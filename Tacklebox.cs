using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Tacklebox {

	class Tacklebox : Mod {

		public const int[] allCrates = {
			2334, 2335, 2336, 3203, 3204, 3205, 3206, 3207, 3208
			};
		public const int[] basicCrates = {
			2334, 2335, 2336
			};
		public static List<int> modRod = new List<int>();
		public static List<int> noLava = new List<int>(
			new int[] {
				2289, 2291, 2293, 2421, 2292, 2295, 2296, 2422, 2294
				}
			);

		public Tacklebox() {
			Properties/* tModPorter Note: Removed. Instead, assign the properties directly (ContentAutoloadingEnabled, GoreAutoloadingEnabled, MusicAutoloadingEnabled, and BackgroundAutoloadingEnabled) */ = new ModProperties() {
				Autoload = true
				};
			}

		public override void AddRecipes()/* tModPorter Note: Removed. Use ModSystem.AddRecipes */ {
			Recipe recipe;
			recipe = Recipe.Create(2425);
			recipe.AddTile(345);
			recipe.AddRecipeGroup("RawFish", 1);
			recipe.Register();
			}

		public override void AddRecipeGroups()/* tModPorter Note: Removed. Use ModSystem.AddRecipeGroups */ {
			RecipeGroup.RegisterGroup("AnyJelly",
				new RecipeGroup(
					() => "Any Jelly", new int[] {
						2436, 2437, 2438,
Find<ModItem>("GoldJelly").Type
						}
					)
				);
			RecipeGroup.RegisterGroup("RawFish",
				new RecipeGroup(
					() => "Any Raw Fish", new int[] {
						2290, 2297, 2298, 2299, 2300, 2301, 2316,
Find<ModItem>("Coelacanth").Type,
Find<ModItem>("Flounder").Type,
Find<ModItem>("RedHerring").Type,
Find<ModItem>("Sardine").Type
						}
					)
				);
			}
		}
	}