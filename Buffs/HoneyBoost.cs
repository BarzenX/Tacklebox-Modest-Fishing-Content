using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Buffs
{
	public class HoneyBoost : ModBuff
	{

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Honey Boost");
			// Description.SetDefault("Seafood Effect\nLife regeneration increased even more!");
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.lifeRegenCount += 2;
		}
	}
}