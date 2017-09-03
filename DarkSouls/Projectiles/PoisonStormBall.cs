using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
	public class PoisonStormBall : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Poison Storm");
        }
        public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
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
			Main.projFrames[projectile.type] = 5;
		}
		public override void AI() 
		{
			projectile.frameCounter++;
			if (projectile.frameCounter > 3)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
			}
			if (projectile.frame >= 5)
			{
				projectile.Kill();
				return;
			}
		}
        public override void Kill(int timeLeft)
        {
            if (!projectile.active)
            {
                return;
            }
            projectile.timeLeft = 0;
            {
                int proType = mod.ProjectileType("PoisonStorm");
                int proDamage = 10;
                int proj = Projectile.NewProjectile(projectile.position.X + (float)((projectile.width / 2) + 30), projectile.position.Y + (float)(projectile.height / 2), 0, 0, proType, proDamage, 8, projectile.owner);
                Main.projectile[proj].friendly = projectile.friendly;
                Main.projectile[proj].hostile = projectile.hostile;
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
            }
            projectile.active = false;
        }
    }
}