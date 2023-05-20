using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CheeseModDanu.Projectiles;
using Microsoft.Xna.Framework;

namespace CheeseModDanu.Items
{
	public class CheeseSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Moldy Cheese Sword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("The mold keeps its true power hidden");
		}

		public override void SetDefaults()
		{
			Item.damage = 100;
			Item.DamageType = DamageClass.Melee;
			Item.shoot = ModContent.ProjectileType<MoldProjectile>();
			Item.width = 50;
			Item.height = 43;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(gold: 10);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Cheese>(), 15);
			recipe.AddIngredient(ItemID.WoodenSword, 1); // might change later idk
			ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);
			if (calamityMod != null)
			{
				calamityMod.TryFind<ModItem>("LivingShard", out ModItem clamItem);
				if (clamItem != null)
				{
					recipe.AddIngredient(clamItem, 5);
				}
			}
			recipe.AddTile(TileID.Solidifier);
			recipe.Register();
		}
    }
}