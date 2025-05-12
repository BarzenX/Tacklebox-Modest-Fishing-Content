using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Food
{
    public class Moonshine : ModItem
    {
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
            Item.CloneDefaults(ItemID.AppleJuice);
            Item.value = 10000;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.buffType = 0;
            Item.buffTime = 10800;
        }

        public override bool? UseItem(Player player)
        {
            return true;
        }

        public override bool ConsumeItem(Player player)
        {
            if (Chance.OneOut(2))   player.AddBuff(ModContent.BuffType<Buffs.Redonkulous>(), Item.buffTime);
            else   player.AddBuff(ModContent.BuffType<Buffs.DrunkWisdom>(), Item.buffTime);

            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.Bottles);
            recipe.AddIngredient(ItemID.Ale, 1);
            recipe.AddIngredient(ItemID.Moonglow, 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Fish.Whiskeyfish>(), 1);
            recipe.Register();
        }
    }
}