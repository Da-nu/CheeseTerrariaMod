using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheeseModDanu.Items
{
	public class CalamityCheese : ModItem
	{
		public override void SetStaticDefaults() {
            DisplayName.SetDefault("Calamity Cheese");
			Tooltip.SetDefault("Now with cool god worm stuff\nSTILL not edible >:(");
		}

		public override void SetDefaults() {
			Item.width = 40;
			Item.height = 40;
			Item.maxStack = 999;
			Item.rare = ItemRarityID.Purple;
			Item.value = 0;
		}

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(5);
			ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);
			if (calamityMod != null)
			{
				recipe.AddIngredient(ModContent.ItemType<Cheese>(), 5);
				calamityMod.TryFind<ModItem>("CosmiliteBar", out ModItem clamItem);
				if (clamItem != null)
				{
					recipe.AddIngredient(clamItem, 1);
				}
			}
			recipe.AddIngredient(ItemID.Gel, 20);
			recipe.AddTile(TileID.Solidifier);
			recipe.Register();
		}
	}
}