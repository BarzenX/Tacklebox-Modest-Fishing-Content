using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Poles
{
    public class GemRod : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Jewel Fishing Rod");
            // Tooltip.SetDefault("Catch gems instead of fish\nFishing power is halved\n'Likely to get a lot of junk...'/nCrab Claws would be the perfect bait for this");
            Tacklebox.modRod.Add(Item.type);
            Tacklebox.noLava.Add(Item.type);
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.WoodFishingPole);
            Item.value = 400000;
            Item.rare = ItemRarityID.Orange;
            Item.fishingPole = 1;
            Item.shoot = ModContent.ProjectileType<Projectiles.GemBobberP>();
            Item.shootSpeed = 8.0f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.Anvils);
            recipe.AddIngredient(Mod.Find<ModItem>("TheVoyager").Type, 1);
            recipe.AddIngredient(ItemID.Amethyst, 16);
            recipe.AddIngredient(ItemID.Topaz, 16);
            recipe.AddIngredient(ItemID.Sapphire, 16);
            recipe.AddIngredient(ItemID.Emerald, 16);
            recipe.AddIngredient(ItemID.Ruby, 16);
            recipe.AddIngredient(ItemID.Diamond, 16);
            recipe.Register();
        }
    }
}