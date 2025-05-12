using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Poles
{
    public class TheVoyager : ModItem
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
            Item.rare = ItemRarityID.Green;
            Item.fishingPole = 32;
            Item.shoot = ModContent.ProjectileType<Projectiles.VoyageBobberP>();
            Item.shootSpeed = 16.0f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.Anvils);
            recipe.AddIngredient(ModContent.ItemType<Items.Poles.AdeptPole>(), 1);
            recipe.AddIngredient(ItemID.Ruby, 8);
            recipe.Register();
        }
    }
}