using Terraria;
using Terraria.ModLoader;

namespace CheeseModDanu.Buffs
{
	public class CheeseBuff : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Cheese Delight");
			Description.SetDefault("Major improvement to all stats");
		}

		public override void Update(Player player, ref int buffIndex) {
			// this is supposed to copy effects of major improvement of all stats
            player.statDefense += 4;
			player.moveSpeed *= 1.4f;
			player.pickSpeed *= 1.15f;
			player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
			player.GetCritChance(DamageClass.Generic) += 4;
			player.GetDamage(DamageClass.Generic) += 0.1f;
			player.GetKnockback(DamageClass.Summon) += 1;
		}
	}
}
