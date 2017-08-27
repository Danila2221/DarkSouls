using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
	public class PhantomSeeker : ModProjectile
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			projectile.width = 15;               //The width of projectile hitbox
			projectile.height = 15;              //The height of projectile hitbox
			projectile.damage = 40;
			projectile.aiStyle = -1;             //The ai style of the projectile, please reference the source code of Terraria
			projectile.light = 1;
        //Can the projectile deal damage to enemies?
			projectile.hostile = true;         //Can the projectile deal damage to the player?
          //Is the projectile shoot by a ranged weapon?
			projectile.penetrate = 3;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			projectile.timeLeft = 500;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)          //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in)          //How much light emit around the projectile
			projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
			projectile.tileCollide = false;
			          //Can the projectile collide with tiles?

		}

public override void AI()
{
	
}





}





		

		
	}

