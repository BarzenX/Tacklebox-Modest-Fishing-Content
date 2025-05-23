using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Tacklebox.Items.Weapons
{
    public class HivePuffer : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.BeeGun);
            Item.value = 75000;
            Item.rare = ItemRarityID.Green;
            Item.scale = 1.0f;
            Item.useTime = 6;
            Item.damage = 6;
            Item.knockBack = 1.0f;
            Item.mana = 0;
            Item.DamageType = DamageClass.Ranged;
        }
    }
}