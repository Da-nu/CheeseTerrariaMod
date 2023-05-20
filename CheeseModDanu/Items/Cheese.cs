using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheeseModDanu.Items
{
	public class Cheese : ModItem
	{
		public override void SetStaticDefaults() {
            DisplayName.SetDefault("Cheese");
			Tooltip.SetDefault("Made with the most fresh slime parts :)\nNot edible yet though :(");
		}

		public override void SetDefaults() {
			Item.width = 40;
			Item.height = 40;
			Item.maxStack = 999;
			Item.rare = ItemRarityID.Yellow;
			Item.value = 0;
		}

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(5);
			recipe.AddIngredient(ItemID.Gel, 200);
			recipe.AddIngredient(ItemID.Cobweb, 20);
			recipe.AddTile(TileID.Solidifier);
			recipe.Register();
		}
	}
}