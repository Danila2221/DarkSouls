using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
	public class ObscureSaw : ModProjectile
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wave Attack");

        }
        public override void SetDefaults()
		{

			projectile.width = 34;
			projectile.height = 34;


			projectile.timeLeft = 160;

			projectile.friendly = false;
			projectile.hostile = true;
			projectile.magic = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;

		}
        public override void AI()
        {
    projectile.rotation++;
    
    

    if (projectile.velocity.X <= 6 && projectile.velocity.Y <= 6 && projectile.velocity.X >= -6 && projectile.velocity.Y >= -6)
    {
    projectile.velocity.X *= 1.02f;
    projectile.velocity.Y *= 1.02f;
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