using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CheeseModDanu.Projectiles;
using Microsoft.Xna.Framework;

namespace CheeseModDanu.Items
{
	public class TrueCheeseSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Cheese Sword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Restored to its true glory");
		}

		public override void SetDefaults()
		{
			Item.damage = 235;
			Item.DamageType = DamageClass.Melee;
			Item.shoot = ModContent.ProjectileType<CheeseProjectile>();
			Item.width = 51;
			Item.height = 47;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(gold: 10);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			//Item.scale = 1.1f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Cheese>(), 10);
			recipe.AddIngredient(ModContent.ItemType<CheeseSword>());
			recipe.AddIngredient(ItemID.FragmentSolar, 5);
			recipe.AddIngredient(ItemID.LunarBar, 5);
			ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);
			if (calamityMod != null)
			{
				calamityMod.TryFind<ModItem>("CryonicBar", out ModItem clamItem);
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