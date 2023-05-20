using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheeseModDanu.Items
{
	public class SwissCheese2 : ModItem
	{
		public override void SetStaticDefaults() {
            DisplayName.SetDefault("Swiss Cheese 2: Devourer of Cheese");
			Tooltip.SetDefault("Heals for full of your maximum life"
                + "\nCRAZY improvement to all stats for 40 seconds");
		}

		public override void SetDefaults() {
			Item.width = 40;
			Item.height = 40;
			Item.useStyle = ItemUseStyleID.DrinkOld;
			Item.useAnimation = 17;
			Item.useTime = 17;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item2;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.rare = ItemRarityID.Purple;
			Item.healLife = 2; // While we change the actual healing value in GetHealLife, item.healLife still needs to be higher than 0 for the item to be considered a healing item
			Item.potion = true; // Makes it so this item applies potion sickness on use and allows it to be used with quick heal
			Item.value = Item.buyPrice(gold: 2);
			Item.buffType = ModContent.BuffType<Buffs.CheeseBuff2>(); // Specify an existing buff to be applied when used.
			Item.buffTime = 2400; // The amount of time the buff declared in Item.buffType will last in ticks. 2400 / 60 is 40, so this buff will last 40 seconds.
		}

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);
			if (calamityMod != null)
			{
				recipe.AddIngredient(ModContent.ItemType<SwissCheese>(), 1);
				recipe.AddIngredient(ModContent.ItemType<CalamityCheese>(), 1);
				calamityMod.TryFind<ModItem>("OmegaHealingPotion", out ModItem clamItem);
				if (clamItem != null)
				{
					recipe.AddIngredient(clamItem, 1);
				}
			}
			recipe.AddTile(TileID.Solidifier);
			recipe.Register();
		}

		public override void GetHealLife(Player player, bool quickHeal, ref int healValue) {
			healValue = player.statLifeMax2;
		}
	}
}