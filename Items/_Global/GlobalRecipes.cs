using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Tacklebox.Items._Global
{
    // This class contains thoughtful examples of item recipe creation.
    // Recipes are explained in detail on the https://github.com/tModLoader/tModLoader/wiki/Basic-Recipes and https://github.com/tModLoader/tModLoader/wiki/Intermediate-Recipes wiki pages. Please visit the wiki to learn more about recipes if anything is unclear.
    public class GlobalRecipes : ModSystem
    {
        // A place to store the recipe group so we can easily use it later
        public static RecipeGroup AnyJellyRecipeGroup;
        public static RecipeGroup AnyRawFishRecipeGroup;

        public override void Unload()
        {
            AnyJellyRecipeGroup = null;
            AnyRawFishRecipeGroup = null;
        }

        public override void AddRecipeGroups()
        {
            // Create a recipe group and store it
            // Language.GetTextValue("LegacyMisc.37") is the word "Any" in English, and the corresponding word in other languages
            AnyJellyRecipeGroup = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.BlueJellyfish)}", // text will be: "Any Blue Jellyfish"
                ItemID.GreenJellyfish,
                ItemID.BlueJellyfish,
                ItemID.PinkJellyfish,
                ModContent.ItemType<Bait.GoldJelly>()
                );

            AnyRawFishRecipeGroup = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.Trout)}", // text will be: "Any Trout"
                ItemID.ArmoredCavefish,
                ItemID.AtlanticCod,
                ItemID.Bass,
                ItemID.ChaosFish,
                ItemID.CrimsonTigerfish,
                ItemID.Damselfish,
                ItemID.DoubleCod,
                ItemID.Ebonkoi,
                ItemID.FlarefinKoi,
                ItemID.Flounder,
                ItemID.FrostMinnow,
                ItemID.Hemopiranha,
                ItemID.Honeyfin,
                ItemID.NeonTetra,
                ItemID.Obsidifish,
                ItemID.PrincessFish,
                ItemID.Prismite,
                ItemID.RedSnapper,
                ItemID.Salmon,
                ItemID.SpecularFish,
                ItemID.Trout,
                ItemID.Tuna,
                ItemID.VariegatedLardfish,

                ModContent.ItemType<Fish.Angling>(),
                ModContent.ItemType<Fish.Boxfish>(),
                ModContent.ItemType<Fish.Clusterfish>(),
                ModContent.ItemType<Fish.Coelacanth>(),
                ModContent.ItemType<Fish.DesertEel>(),
                ModContent.ItemType<Fish.Flounder>(),
                ModContent.ItemType<Fish.Gamifish>(),
                ModContent.ItemType<Fish.Glittergill>(),
                ModContent.ItemType<Fish.LavaEel>(),
                ModContent.ItemType<Fish.Lobster>(),
                ModContent.ItemType<Fish.Mushfin>(),
                ModContent.ItemType<Fish.Pupfish>(),
                ModContent.ItemType<Fish.RedHerring>(),
                ModContent.ItemType<Fish.SandShark>(),
                ModContent.ItemType<Fish.Sardine>(),
                ModContent.ItemType<Fish.Sturgeon>(),
                ModContent.ItemType<Fish.Whiskeyfish>()
                );

            AnyRawFishRecipeGroup.IconicItemId = ItemID.Trout;

            // To avoid name collisions, when a modded item is the iconic or 1st item in a recipe group, name the recipe group: ModName:ItemName
            RecipeGroup.RegisterGroup("Tacklebox:AnyJelly", AnyJellyRecipeGroup);
            RecipeGroup.RegisterGroup("Tacklebox:AnyRawFish", AnyRawFishRecipeGroup);


            // more examples from ExampleMod:
            // Add an item to an existing Terraria recipeGroup. ExampleCritterItem isn't gold but it serves as an example for this.
            //RecipeGroup.recipeGroups[RecipeGroupID.GoldenCritter].ValidItems.Add(ModContent.ItemType<ExampleCritterItem>());

            // While an "IronBar" group exists, "SilverBar" does not. tModLoader will merge recipe groups registered with the same name, so if you are registering a recipe group with a vanilla item as the 1st item, you can register it using just the internal item name if you anticipate other mods wanting to use this recipe group for the same concept. By doing this, multiple mods can add to the same group without extra effort. In this case we are adding a SilverBar group. Don't store the RecipeGroup instance, it might not be used, use the same nameof(ItemID.ItemName) or RecipeGroupID returned from RegisterGroup when using Recipe.AddRecipeGroup instead.
            //RecipeGroup SilverBarRecipeGroup = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.SilverBar)}",
            //ItemID.SilverBar, ItemID.TungstenBar, ModContent.ItemType<Items.Placeable.ExampleBar>());
            //RecipeGroup.RegisterGroup(nameof(ItemID.SilverBar), SilverBarRecipeGroup);
        }

        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.CookedFish);
            recipe.AddTile(TileID.CookingPots);
            recipe.AddRecipeGroup("Tacklebox:AnyRawFish", 1);
            recipe.Register();
        }
    }
}
