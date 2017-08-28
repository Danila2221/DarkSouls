using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
	public class FGravity4Strike : ModProjectile
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Demi 4");
            Main.projFrames[projectile.type] = 7;

        }
        public override void SetDefaults()
		{

			projectile.width = 90;
			projectile.height = 90;
			projectile.penetrate = 100;
			projectile.knockBack = 9;
			projectile.timeLeft = 200;
			projectile.alpha = 100;
			projectile.light = 1f;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.magic = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
        }
		public override void AI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter > 3)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 7)
            {
                projectile.Kill();
                return;
            }
            int hitPlayer = 0;
            int gravDamPerc = (int)(Main.player[Main.myPlayer].statLife * 0.05f);

            Rectangle projrec = new Rectangle((int)projectile.position.X + (int)projectile.velocity.X, (int)projectile.position.Y + (int)projectile.velocity.Y, projectile.width, projectile.height);
            Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player[Main.myPlayer].width, (int)Main.player[Main.myPlayer].height);
            if (projrec.Intersects(prec))
            {
                if (hitPlayer <= 0)
                {
                    Main.player[Main.myPlayer].statLife = gravDamPerc;
                    hitPlayer = 1;
                }
            }
		}
	}
}