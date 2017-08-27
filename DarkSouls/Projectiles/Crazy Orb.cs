using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
	public class CrazyOrb : ModProjectile
	{
		public override void SetStaticDefaults()
		{
  			Main.projFrames[projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			projectile.width = 32;               //The width of projectile hitbox
			projectile.height = 34;              //The height of projectile hitbox
			projectile.aiStyle = 0;             //The ai style of the projectile, please reference the source code of Terraria
			projectile.light = 1;
        //Can the projectile deal damage to enemies?
			projectile.hostile = true;         //Can the projectile deal damage to the player?
          //Is the projectile shoot by a ranged weapon?
			projectile.ranged = true;
			projectile.penetrate = 2;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			projectile.timeLeft = 500;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)          //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in)          //How much light emit around the projectile
			projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
			projectile.tileCollide = false;
			          //Can the projectile collide with tiles?

		}

public override void AI()
{
	projectile.rotation += 0.5f;
	
	if (Main.player[(int)projectile.ai[0]].position.X < projectile.position.X)
	{
	if (projectile.velocity.X > -6) projectile.velocity.X -= 0.05f;
	}
	
	if (Main.player[(int)projectile.ai[0]].position.X > projectile.position.X)
	{
	if (projectile.velocity.X < 6) projectile.velocity.X += 0.05f;
	}
	
	if (Main.player[(int)projectile.ai[0]].position.Y < projectile.position.Y)
	{
	if (projectile.velocity.Y > -6) projectile.velocity.Y -= 0.05f;
	}

	if (Main.player[(int)projectile.ai[0]].position.Y > projectile.position.Y)
	{
	if (projectile.velocity.Y < 6) projectile.velocity.Y += 0.05f;
	}
	

	

projectile.frameCounter++;
                                if (projectile.frameCounter > 2)
                                {
                                    projectile.frame++;
                                    projectile.frameCounter = 3;
                                }
                                if (projectile.frame >= 4)
                                {
                                    projectile.frame = 0;
                                }

}





}





		

		
	}

