using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
	public class FrozenSaw : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frozen Saw");
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            projectile.width = 34;
            projectile.height = 34;
            projectile.timeLeft = 150;
            projectile.alpha = 100;
            projectile.light = 1f;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.magic = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.damage = 40;
        }
        public override void AI()
        {
    projectile.rotation++;




if (projectile.velocity.X <= 10 && projectile.velocity.Y <= 10 && projectile.velocity.X >= -10 && projectile.velocity.Y >= -10)
    {
    projectile.velocity.X *= 1.01f;
    projectile.velocity.Y *= 1.01f;
    }

    if (Main.rand.Next(2)==0)
    {


    return;

    }

projectile.frameCounter++;
                                if (projectile.frameCounter > 2)
                                {
                                    projectile.frame++;
                                    projectile.frameCounter = 0;
                                }
                                if (projectile.frame >= 4)
                                {
                                    projectile.frame = 0;
                                }

Rectangle projrec = new Rectangle((int)projectile.position.X+(int)projectile.velocity.X, (int)projectile.position.Y+(int)projectile.velocity.Y, projectile.width, projectile.height);
Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player[Main.myPlayer].width,(int)Main.player[Main.myPlayer].height);

    

}
        
    }
}