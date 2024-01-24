using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Tacklebox.Items.Food
{
    public class Sweetglub : ModItem
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
            Item.CloneDefaults(ItemID.CookedFish);
            Item.value = 20000;
            Item.rare = ItemRarityID.Blue;
            Item.buffType = ModContent.BuffType<Buffs.Seafood>();
            Item.buffTime = 10800;
        }
    }
}