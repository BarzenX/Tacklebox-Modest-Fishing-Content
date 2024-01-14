using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Poles
{
    public class LadyLuck : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Lady Luck");
            // Tooltip.SetDefault("Fishing power based on highest Critical Chance");
            Tacklebox.modRod.Add(Item.type);
            Tacklebox.noLava.Add(Item.type);
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.WoodFishingPole);
            Item.value = 400000;
            Item.rare = ItemRarityID.Red;
            Item.fishingPole = 1;
            Item.shoot = ModContent.ProjectileType<Projectiles.LuckyBobberP>();
            Item.shootSpeed = 16.0f;
        }

        public override void HoldItem(Player player)
        {
            float bestCrit = 10.0f;
            if (bestCrit < player.GetCritChance(DamageClass.Melee))   bestCrit = player.GetCritChance(DamageClass.Melee);
            if (bestCrit < player.GetCritChance(DamageClass.Ranged))   bestCrit = player.GetCritChance(DamageClass.Ranged);
            if (bestCrit < player.GetCritChance(DamageClass.Magic))   bestCrit = player.GetCritChance(DamageClass.Magic);
            if (bestCrit < player.GetCritChance(DamageClass.Throwing))   bestCrit = player.GetCritChance(DamageClass.Throwing);
            Item.fishingPole = (int)(bestCrit * 0.75f);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddIngredient(ModContent.ItemType<Items.Poles.TheVoyager>(), 1);
            recipe.AddIngredient(ItemID.LuckyCoin, 1);
            recipe.AddIngredient(ItemID.LunarBar, 8);
            recipe.Register();
        }
    }
}