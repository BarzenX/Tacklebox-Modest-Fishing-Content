using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Poles
{
    public class GemRod : ModItem
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
            Item.value = 400000;
            Item.rare = ItemRarityID.Orange;
            Item.fishingPole = 40;
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