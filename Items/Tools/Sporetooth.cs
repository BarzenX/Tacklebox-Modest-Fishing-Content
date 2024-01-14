using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Tools
{
    public class Sporetooth : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sporetooth Mushark");
            // Tooltip.SetDefault("'Oh, I get it!'");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.SawtoothShark);
            Item.shoot = ModContent.ProjectileType<Projectiles.SporetoothP>();
        }
    }
}