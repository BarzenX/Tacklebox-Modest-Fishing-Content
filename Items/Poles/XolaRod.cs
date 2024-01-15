using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Poles
{
    public class XolaRod : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tacklebox.modRod.Add(Item.type);
            Tacklebox.noLava.Add(Item.type);
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.WoodFishingPole);
            Item.value = 400000;
            Item.rare = ItemRarityID.Pink;
            Item.fishingPole = 5;
            Item.shoot = ModContent.ProjectileType<Projectiles.XolaBobberP>();
            Item.shootSpeed = 16.0f;
        }
    }
}