using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CheeseModDanu.Projectiles;
using Microsoft.Xna.Framework;

namespace CheeseModDanu.Items
{
	public class SupremeCheeseSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Supreme Cheese Sword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Liquid molten cheese\nBypasses resistance of cultists");
		}

		public override void SetDefaults()
		{
			Item.damage = 885;
			Item.DamageType = DamageClass.Melee;
			Item.shoot = ModContent.ProjectileType<SupremeProjectile>();
			Item.width = 103;
			Item.height = 116;
			Item.useTime = 19;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(gold: 10);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			//Item.scale = 1.1f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Cheese>(), 20);
			recipe.AddIngredient(ModContent.ItemType<TrueCheeseSword>());
			recipe.AddIngredient(ModContent.ItemType<CheeseSword>());
			recipe.AddIngredient(ModContent.ItemType<DevourerCheeseSword>());
			ModLoader.TryGetMod("CalamityMod", out Mod calamityMod);
			if (calamityMod != null)
			{
				calamityMod.TryFind<ModItem>("AuricBar", out ModItem clamItem);
				if (clamItem != null)
				{
					recipe.AddIngredient(clamItem, 5);
				}
				calamityMod.TryFind<ModItem>("PurifiedGel", out ModItem clamItem2);
				if (clamItem2 != null)
				{
					recipe.AddIngredient(clamItem2, 20);
				}
			}
			recipe.AddTile(TileID.Solidifier);
			recipe.Register();
		}
    }
}