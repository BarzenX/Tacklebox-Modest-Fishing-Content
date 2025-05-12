using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Tools
{
    public class Sporetooth : ModItem
    {
        public override void SetStaticDefaults()
        {
            // As mentioned in the documentation, IsDrill and IsChainsaw automatically reduce useTime and useAnimation to 60% of what is set in SetDefaults and decrease tileBoost by 1, but only for vanilla items.
            // We set it here despite it doing nothing because it is likely to be used by other mods to provide special effects to drill or chainsaw items globally.
            ItemID.Sets.IsChainsaw[Type] = true;

            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.SawtoothShark);
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shoot = ModContent.ProjectileType<Projectiles.SporetoothP>(); // Create the saw projectile
            Item.shootSpeed = 48f; // Adjusts how far away from the player to hold the projectile (value set to match the SawtoothShark
            Item.noMelee = true; // Turns off damage from the item itself, as we have a projectile
            //Item.noUseGraphic = true; // Stops the item from drawing in your hands, for the aforementioned reason
            Item.channel = true; // Important as the projectile checks if the player channels

            Item.DamageType = DamageClass.MeleeNoSpeed; // ignores melee speed bonuses. There's no need for chainsaw animations to play faster, nor chainsaws to dig faster with melee speed.
            // IsDrill/IsChainsaw effects must be applied manually, so 60% or 0.6 times the time of the corresponding axe. In this case, 60% of 7 is 4 and 60% of 25 is 15.
            // If you decide to copy values from vanilla chainsaws, you should multiply each one by 0.6 to get the expected behavior.
            Item.useTime = 4;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 2.4f;
            Item.UseSound = SoundID.Item23;
            


            // tileBoost changes the range of tiles that the item can reach.
            // To match Titanium Drill, we should set this to -1, but we'll set it to 10 blocks of extra range for the sake of an example.
            //Item.tileBoost = 10;

            Item.axe = 16; // (16 * 5% = 80%) How strong the saw is, see https://terraria.wiki.gg/wiki/Pickaxe_power for a list of common values
        }
    }
}