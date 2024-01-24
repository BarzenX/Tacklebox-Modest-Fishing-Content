using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Poles
{
    public class JuniorPole : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tacklebox.modRod.Add(Item.type);
            Tacklebox.noLava.Add(Item.type);

            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.WoodFishingPole);
            Item.value = 10000;
            Item.rare = ItemRarityID.White;
            Item.fishingPole = 10;
            Item.shoot = ModContent.ProjectileType<Projectiles.JuniorBobberP>();
            Item.shootSpeed = 10.0f;
        }
    }
}