using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
	public class LightPillarBall : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Light Pillar");
            Main.projFrames[projectile.type] = 15;
        }
		public override void SetDefaults()
		{
			projectile.width = 220;
			projectile.height = 40;
			projectile.penetrate = 1;
			projectile.knockBack = 9;
			projectile.timeLeft = 360;
			projectile.alpha = 100;
			projectile.light = 0.8f;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.magic = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
			
		}
        public override void AI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter > 3)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 15)
            {
                projectile.Kill();
                return;
            }
        }
    }
}