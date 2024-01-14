using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Fish
{
    public class Sturgeon : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Snow Sturgeon");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Bass);
            Item.value = 10000;
        }
    }
}