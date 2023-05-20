using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheeseModDanu.Items
{
	public class SwissCheese : ModItem
	{
		public override void SetStaticDefaults() {
            DisplayName.SetDefault("Swiss Cheese");
			Tooltip.SetDefault("Heals for half of your maximum life"
                + "\nMajor improvement to all stats for 20 seconds");
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
			Item.rare = ItemRarityID.Yellow;
			Item.healLife = 1; // While we change the actual healing value in GetHealLife, item.healLife still needs to be higher than 0 for the item to be considered a healing item
			Item.potion = true; // Makes it so this item applies potion sickness on use and allows it to be used with quick heal
			Item.value = Item.buyPrice(gold: 1);
			Item.buffType = ModContent.BuffType<Buffs.CheeseBuff>(); // Specify an existing buff to be applied when used.
			Item.buffTime = 1200; // The amount of time the buff declared in Item.buffType will last in ticks. 1200 / 60 is 20, so this buff will last 20 seconds.
		}

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);
			if (calamityMod != null)
			{
				recipe.AddIngredient(ModContent.ItemType<Cheese>(), 1);
				calamityMod.TryFind<ModItem>("SupremeHealingPotion", out ModItem clamItem);
				if (clamItem != null)
				{
					recipe.AddIngredient(clamItem,1);
				}
			}
			recipe.AddTile(TileID.Solidifier);
			recipe.Register();
		}

		public override void GetHealLife(Player player, bool quickHeal, ref int healValue) {
			healValue = player.statLifeMax2 / 2;
		}
	}
}