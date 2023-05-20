using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CheeseModDanu.Projectiles;
using Microsoft.Xna.Framework;

namespace CheeseModDanu.Items
{
	public class OriginalCheeseSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cheese Sword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Original");
		}

		public override void SetDefaults()
		{
			Item.damage = 6000;
			Item.DamageType = DamageClass.Melee;
			Item.shoot = ModContent.ProjectileType<CheeseP>();
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 2;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(gold: 99);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.scale = 13f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Cheese>());
			//recipe.AddIngredient(ModContent.ItemType<TrueCheeseSword>());
			recipe.AddIngredient(ModContent.ItemType<RawCheeseSword>());
			recipe.AddIngredient(ModContent.ItemType<CheeseSword>());
			//recipe.AddIngredient(ModContent.ItemType<DevourerCheeseSword>());
			ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);
			if (calamityMod != null)
			{
				calamityMod.TryFind<ModItem>("ShadowspecBar", out ModItem clamItem);
				if (clamItem != null)
				{
					recipe.AddIngredient(clamItem, 999);
				}
			}
			recipe.AddTile(TileID.Solidifier);
			recipe.Register();
		}
    }
}