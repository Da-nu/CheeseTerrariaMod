using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheeseModDanu.Projectiles
{
	public class CheeseP : ModProjectile
	{
		float maxDetectRadius = 600f; // The maximum radius at which a projectile can detect a target
		float projSpeed = 19f; // The speed at which the projectile moves towards the target
		int dividedBy = 100;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Original Sword Projectile"); // Name of the projectile. It can be appear in chat

			ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = false; // Make the cultist resistant to this projectile, as it's resistant to all homing projectiles.
		}

		// Setting the default parameters of the projectile
		// You can check most of Fields and Properties here https://github.com/tModLoader/tModLoader/wiki/Projectile-Class-Documentation
		public override void SetDefaults()
		{
			Projectile.width = 145; // The width of projectile hitbox
			Projectile.height = 48; // The height of projectile hitbox
			Projectile.penetrate = 1;
			Projectile.aiStyle = 0; // The ai style of the projectile (0 means custom AI). For more please reference the source code of Terraria
			Projectile.DamageType = DamageClass.Melee; // What type of damage does this projectile affect?
			Projectile.friendly = true; // Can the projectile deal damage to enemies?
			Projectile.hostile = false; // Can the projectile deal damage to the player?
			Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
			//Projectile.light = 0f; // How much light emit around the projectile
			Projectile.tileCollide = false; // Can the projectile collide with tiles?
			Projectile.timeLeft = 140; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			Projectile.alpha = 130;
		}

		//bool cloneCodeUsed = false;
		int cloneType1 = ModContent.ProjectileType<MoldProjectile>();
		int cloneType2 = ModContent.ProjectileType<CheeseProjectile>();
		int cloneType3 = ModContent.ProjectileType<CalamityProjectile>();
		int cloneType4 = ModContent.ProjectileType<CalamityCloneProjectile>();
		int cloneType5 = ModContent.ProjectileType<SupremeProjectile>();
		int cloneType6 = ModContent.ProjectileType<CloneProjectile>();

		int timer = 140;

		public override void OnSpawn(IEntitySource source)
        {
            base.OnSpawn(source);
			timer = Projectile.timeLeft;
			Projectile.velocity = (Main.MouseWorld - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;
			Projectile.rotation = Projectile.velocity.ToRotation();
			//Projectile.spriteDirection = Projectile.direction;
			Projectile.NewProjectile(source, Projectile.position, Projectile.velocity, cloneType1, Projectile.damage, Projectile.knockBack, Projectile.owner, Projectile.ai[0], Projectile.ai[1]);
			Projectile.NewProjectile(source, Projectile.position, Projectile.velocity, cloneType2, Projectile.damage, Projectile.knockBack, Projectile.owner, Projectile.ai[0], Projectile.ai[1]);
			Projectile.NewProjectile(source, Projectile.position, Projectile.velocity, cloneType3, Projectile.damage, Projectile.knockBack, Projectile.owner, Projectile.ai[0], Projectile.ai[1]);
			Projectile.NewProjectile(source, Projectile.position, Projectile.velocity, cloneType4, Projectile.damage, Projectile.knockBack, Projectile.owner, Projectile.ai[0], Projectile.ai[1]);
			Projectile.NewProjectile(source, Projectile.position, Projectile.velocity, cloneType5, Projectile.damage, Projectile.knockBack, Projectile.owner, Projectile.ai[0], Projectile.ai[1]);
			Projectile.NewProjectile(source, Projectile.position, Projectile.velocity, cloneType6, Projectile.damage, Projectile.knockBack, Projectile.owner, Projectile.ai[0], Projectile.ai[1]);
		}

		//public override void 

		// Custom AI | note from danu: i hate example projectile code

		public override void AI()
		{
			// Trying to find NPC closest to the projectile
			NPC closestNPC = FindClosestNPC(maxDetectRadius);

			Lighting.AddLight(Projectile.position, 255 / dividedBy, 209 / dividedBy, 81 / dividedBy);

			if (timer < 10)
			{
				Projectile.alpha += 13;
			}
			else if (timer > timer-10)
			{
				Projectile.alpha -= 13;
			}
			else
			{
				Projectile.alpha = 0;
			}

			if (closestNPC != null)
			{
				Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * (projSpeed + 10f);
				Projectile.rotation = Projectile.velocity.ToRotation();
				//Projectile.spriteDirection = Projectile.direction;
			}

			timer -= 1;
		}

		// Finding the closest NPC to attack within maxDetectDistance range
		// If not found then returns null
		public NPC FindClosestNPC(float maxDetectDistance)
		{
			NPC closestNPC = null;

			// Using squared values in distance checks will let us skip square root calculations, drastically improving this method's speed.
			float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

			// Loop through all NPCs(max always 200)
			for (int k = 0; k < Main.maxNPCs; k++)
			{
				NPC target = Main.npc[k];
				// Check if NPC able to be targeted. It means that NPC is
				// 1. active (alive)
				// 2. chaseable (e.g. not a cultist archer)
				// 3. max life bigger than 5 (e.g. not a critter)
				// 4. can take damage (e.g. moonlord core after all it's parts are downed)
				// 5. hostile (!friendly)
				// 6. not immortal (e.g. not a target dummy)
				if (target.CanBeChasedBy())
				{
					// The DistanceSquared function returns a squared distance between 2 points, skipping relatively expensive square root calculations
					float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);

					// Check if it is within the radius
					if (sqrDistanceToTarget < sqrMaxDetectDistance)
					{
						sqrMaxDetectDistance = sqrDistanceToTarget;
						closestNPC = target;
					}
				}
			}

			return closestNPC;
		}
	}
}
