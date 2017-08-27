using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
	public class ShadowOrb : ModProjectile
	{
		
        public override void SetDefaults()
		{

			projectile.width = 15;
			projectile.height = 15;
	

			projectile.friendly = false;
			projectile.hostile = true;
			projectile.magic = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;

		}
        public override void AI()
        {
     

    projectile.rotation++;
    int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 6, 0, 0, 100, Color.Red, 2.0f);
    Main.dust[dust].noGravity = true;

    if (projectile.velocity.X <= 10 && projectile.velocity.Y <= 10 && projectile.velocity.X >= -10 && projectile.velocity.Y >= -10)
    {
    projectile.velocity.X *= 1.01f;
    projectile.velocity.Y *= 1.01f;
    }

Rectangle projrec = new Rectangle((int)projectile.position.X+(int)projectile.velocity.X, (int)projectile.position.Y+(int)projectile.velocity.Y, projectile.width, projectile.height);
Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player[Main.myPlayer].width,(int)Main.player[Main.myPlayer].height);



}
        }
        
    }
