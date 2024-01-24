using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Poles
{
    public class CaveRod : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tacklebox.modRod.Add(Item.type);
            ItemID.Sets.CanFishInLava[Item.type] = true;

            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.WoodFishingPole);
            Item.value = 40000;
            Item.rare = ItemRarityID.Orange;
            Item.fishingPole = 25;
            Item.shoot = ModContent.ProjectileType<Projectiles.CaveBobberP>();
            Item.shootSpeed = 14.0f;
        }
    }
}