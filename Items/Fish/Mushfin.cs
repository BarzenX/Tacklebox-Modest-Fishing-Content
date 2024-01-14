using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tacklebox.Items.Fish
{
    public class Mushfin : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Spongy Onuso");
            // Tooltip.SetDefault("'Strangely familiar... Eat it?'");
        }

        public override void SetDefaults()
        {
            Item.value = 15000;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = Item.CommonMaxStack;
            Item.healLife = 6;
            Item.consumable = true;
        }

        public override bool? UseItem(Player player) //TODO: tModPorter Suggestion: Return null instead of false
        {
            player.statLife += Item.healLife;
            if (player.whoAmI == Main.myPlayer)
            {
                player.HealEffect(Item.healLife, true);
            }
            return true;
        }
    }
}