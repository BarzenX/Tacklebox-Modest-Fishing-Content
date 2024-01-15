using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tacklebox.Items.Crates
{
    public class ShadowLockbox : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Disclaimer for both of these sets (as per their docs): They are only checked for vanilla item IDs, but for cross-mod purposes it would be helpful to set them for modded crates too
            ItemID.Sets.IsFishingCrate[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.value = 50000;
            Item.rare = ItemRarityID.Green;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
        }

        public override bool CanRightClick()
        {
            return Main.LocalPlayer.HasItem(ItemID.ShadowKey);
        }

        public override void RightClick(Player player)
        {
            SoundEngine.PlaySound(SoundID.Unlock);

            var source = player.GetSource_FromThis();

            int[] biomeReward = new int[]
            {
                ItemID.DarkLance,
                ItemID.Flamelash,
                ItemID.FlowerofFire,
                ItemID.Sunfury,
                ItemID.HellwingBow
            };
            player.QuickSpawnItem(source, biomeReward[Main.rand.Next(biomeReward.Length)]); //TODO: test it

            if (Chance.OneOut(3))   player.QuickSpawnItem(source, ItemID.Dynamite);

            if (Chance.OneOut(2))
            {
                int bars = ItemID.GoldBar;
                if (Chance.OneOut(2))   bars = ItemID.MeteoriteBar;
                player.QuickSpawnItem(source, bars, Main.rand.Next(15,30));
            }

            if (Chance.OneOut(2))
            {
                int ammo = ItemID.HellfireArrow;
                if (Chance.OneOut(2))   ammo = ItemID.SilverBullet;
                player.QuickSpawnItem(source, ammo, Main.rand.Next(50,75));
            }

            if (Chance.OneOut(2))
            {
                int potion = ItemID.LesserRestorationPotion;
                if (Chance.OneOut(2))   potion = ItemID.RestorationPotion;
                player.QuickSpawnItem(source, potion, Main.rand.Next(10,20));
            }

            if (Chance.OneOut(2))
            {
                int[] potion = new int[]
                {
                    ItemID.SpelunkerPotion,
                    ItemID.FeatherfallPotion,
                    ItemID.ManaRegenerationPotion,
                    ItemID.ObsidianSkinPotion,
                    ItemID.MagicPowerPotion,
                    ItemID.InvisibilityPotion,
                    ItemID.HunterPotion
                };
                player.QuickSpawnItem(source, potion[Main.rand.Next(potion.Length)], Main.rand.Next(1, 5)); //TODO: test it
            }

            if (Chance.OneOut(2))
            {
                int[] potion =
                {
                    ItemID.GravitationPotion,
                    ItemID.ThornsPotion,
                    ItemID.WaterWalkingPotion,
                    ItemID.ObsidianSkinPotion,
                    ItemID.BattlePotion
                };
                player.QuickSpawnItem(source, potion[Main.rand.Next(potion.Length)], Main.rand.Next(1, 5)); //TODO: test it
            }

            if (Chance.OneOut(2))
            {
                int torch = ItemID.Torch;
                if (Chance.OneOut(2))   torch = ItemID.Glowstick;
                player.QuickSpawnItem(source, torch, Main.rand.Next(15,30));
            }

            if (Chance.OneOut(2))
            {
                player.QuickSpawnItem(source, ItemID.GoldCoin, Main.rand.Next(2,5));
                player.QuickSpawnItem(source, ItemID.SilverCoin, Main.rand.Next(0, 100));
                player.QuickSpawnItem(source, ItemID.CopperCoin, Main.rand.Next(0, 100));
            }
        }
    }
}