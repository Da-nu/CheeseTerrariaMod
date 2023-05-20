using Terraria;
using Terraria.ModLoader;

namespace CheeseModDanu.Buffs
{
	public class CheeseBuff2 : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Cheese Delight 2: Devourer of Cheese");
			Description.SetDefault("CRAZY improvement to all stats");
		}

		public override void Update(Player player, ref int buffIndex) {
			// this is originally was supposed to copy effects of major improvement of all stats
			// this is now crazy improvement
            player.statDefense = (int)(player.statDefense * 1.25f);
			player.moveSpeed *= 1.75f;
			player.pickSpeed *= 1.35f;
			player.GetAttackSpeed(DamageClass.Generic) += 0.25f;
			player.GetCritChance(DamageClass.Generic) += 10;
			player.GetDamage(DamageClass.Generic) += 0.25f;
			player.GetKnockback(DamageClass.Summon) += 5;
			player.lifeRegen = (int)(player.lifeRegen * 2f);
			player.manaCost *= 0.65f;
		}
	}
}
