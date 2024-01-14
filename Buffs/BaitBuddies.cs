using Terraria;
using Terraria.ModLoader;

namespace Tacklebox.Buffs
{
	public class BaitBuddies : ModBuff 
{

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Bait Buddies");
			// Description.SetDefault("Run 4% faster for every active minion");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.moveSpeed += player.numMinions * 0.04f;
		}
	}
}