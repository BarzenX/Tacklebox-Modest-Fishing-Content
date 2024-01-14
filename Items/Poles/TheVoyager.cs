using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Poles
{
    public class TheVoyager : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("The Voyager");
            // Tooltip.SetDefault("'From across the seven depths'");
            Tacklebox.modRod.Add(Item.type);
            Tacklebox.noLava.Add(Item.type);
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