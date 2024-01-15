using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Poles
{
    public class AdeptPole : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tacklebox.modRod.Add(Item.type);
            Tacklebox.noLava.Add(Item.type);
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
            recipe.AddIngredient(Mod.Find<ModItem>("JuniorPole").Type, 1);
            recipe.AddRecipeGroup("IronBar", 8);
            recipe.Register();
        }
    }
}