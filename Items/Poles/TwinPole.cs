using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Poles
{
    public class TwinPole : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tacklebox.modRod.Add(Item.type);
            Tacklebox.noLava.Add(Item.type);
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.WoodFishingPole);
            Item.value = 100000;
            Item.rare = ItemRarityID.Green;
            Item.fishingPole = 32;
            Item.shoot = ModContent.ProjectileType<Projectiles.TwinBobberP>();
            Item.shootSpeed = 14.0f;
        }

        public override void AddRecipes()
        {
            Recipe recipe;
            recipe = CreateRecipe();
            recipe.AddTile(TileID.Anvils);
            recipe.AddIngredient(ItemID.FiberglassFishingPole, 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Hooks.GoldHook>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Items.Junk.Cattail>(), 2);
            recipe.Register();

            recipe = CreateRecipe();
            recipe.AddTile(TileID.Anvils);
            recipe.AddIngredient(ItemID.FiberglassFishingPole, 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Hooks.PlatinumHook>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Items.Junk.Cattail>(), 2);
            recipe.Register();
        }
    }
}