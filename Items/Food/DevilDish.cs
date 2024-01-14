using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Food
{
    public class DevilDish : ModItem
    {
        private static int[] buffList =
        {
            BuffID.Regeneration,
            BuffID.Battle,
            BuffID.Thorns,
            BuffID.Hunter,
            BuffID.Heartreach,
            BuffID.Rage,
            BuffID.Inferno,
            BuffID.Wrath,
            BuffID.Warmth,
            ModContent.BuffType<Buffs.LavaBoost>()
        };

    public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Devil's Dish");
            // Tooltip.SetDefault("'An underworld delicacy'");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.CookedFish);
            Item.value = 40000;
            Item.rare = ItemRarityID.Orange;
            Item.scale = 0.8f;
            Item.buffType = BuffID.WellFed;
            Item.buffTime = 216000;
        }

        public override bool ConsumeItem(Player player)
        {
            player.AddBuff(BuffID.OnFire, 1200);
            for (int i = 0; i < buffList.Length; i++)
            {
                if (Chance.OneOut(buffList.Length / 3))   player.AddBuff(buffList[i], Main.rand.Next(2, 8) * 3600);
            }
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.CookingPots);
            recipe.AddIngredient(ModContent.ItemType<Items.Fish.Pupfish>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Bait.CrabClaw>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Fish.Lobster>(), 1);
            recipe.Register();
        }
    }
}