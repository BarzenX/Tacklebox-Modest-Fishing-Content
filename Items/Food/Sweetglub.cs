using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Food
{
    public class Sweetglub : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sweetglub");
            // Tooltip.SetDefault("'Honeyed fish!'");
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