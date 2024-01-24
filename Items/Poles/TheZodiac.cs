using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Poles
{
    public class TheZodiac : ModItem
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
            Item.value = 80000;
            Item.rare = ItemRarityID.LightRed;
            Item.fishingPole = 48;
            Item.shoot = ModContent.ProjectileType<Projectiles.ZodiacBobberP>();
            Item.shootSpeed = 16.0f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddIngredient(ModContent.ItemType<Items.Poles.TheVoyager>(), 1);
            recipe.AddIngredient(ItemID.Sundial, 1);
            recipe.Register();
        }
    }
}