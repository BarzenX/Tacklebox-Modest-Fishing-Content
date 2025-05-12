using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Poles
{
    public class AdeptPole : ModItem
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
            Item.value = 20000;
            Item.rare = ItemRarityID.Blue;
            Item.fishingPole = 18;
            Item.shoot = ModContent.ProjectileType<Projectiles.AdeptBobberP>();
            Item.shootSpeed = 12.0f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.Anvils);
            recipe.AddIngredient(ModContent.ItemType<JuniorPole>(), 1);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 8);
            recipe.Register();
        }
    }
}