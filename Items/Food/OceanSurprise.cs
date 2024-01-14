using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Food
{
    public class OceanSurprise : ModItem
    {
        private static int[] buffList =
        {
            BuffID.Gills,
            BuffID.ManaRegeneration,
            BuffID.MagicPower,
            BuffID.Calm,
            BuffID.Flipper,
            ModContent.BuffType<Buffs.Leapfrog>(),
            ModContent.BuffType<Buffs.Seafood>(),
            ModContent.BuffType<Buffs.WaterBoost>()
        };

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ocean Surprise");
            // Tooltip.SetDefault("'A menagerie of sea things'");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.CookedFish);
            Item.value = 40000;
            Item.rare = ItemRarityID.Green;
            Item.scale = 0.8f;
            Item.buffType = BuffID.WellFed;
            Item.buffTime = 108000;
        }

        public override bool ConsumeItem(Player player)
        {
            player.AddBuff(BuffID.Wet, 28800);
            for (int i = 0; i < buffList.Length; i++)
            {
                if (Chance.OneOut(buffList.Length / 2))   player.AddBuff(buffList[i], 21600);
            }
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.CookingPots);
            recipe.AddRecipeGroup("Tacklebox:AnyRawFish", 3);
            recipe.AddRecipeGroup("Tacklebox:AnyJelly", 3);
            recipe.Register();
        }
    }
}