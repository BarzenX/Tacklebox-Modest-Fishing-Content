using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Food
{
    public class DevilDish : ModItem
    {
        private static readonly int[] buffList =
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
            Item.ResearchUnlockCount = 10;

            // This is to show the correct frame in the inventory
            // The MaxValue argument is for the animation speed, we want it to be stuck on frame 1
            // Setting it to max value will cause it to take 414 days to reach the next frame
            // No one is going to have game open that long so this is fine
            // The second argument is the number of frames, which is 3
            // The first frame is the inventory texture, the second frame is the holding texture,
            // and the third frame is the placed texture
            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));

            ItemID.Sets.IsFood[Type] = true; //This allows it to be placed on a plate and held correctly
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