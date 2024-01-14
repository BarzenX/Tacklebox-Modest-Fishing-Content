using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Fish
{
    public class RedHerring : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Red Herring");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Bass);
        }
    }
}