using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
	public class Ice4Ball : ModProjectile
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice 4");

        }
        public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.penetrate = 1;
			projectile.knockBack = 9;
			projectile.timeLeft = 50;
			projectile.alpha = 100;
			projectile.light = 1f;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.magic = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
		}
        public override void Kill(int timeLeft)
        {
            if (!projectile.active)
            {
                return;
            }
            projectile.timeLeft = 0;
            {
                int proType = mod.ProjectileType("Ice4Icicle");
                int proDamage = 70;
                    int proj = Projectile.NewProjectile(projectile.position.X + (float)(projectile.width * 2), projectile.position.Y + (float)(projectile.height), 0, 5, proType, proDamage, 3, projectile.owner);
                    int proj2 = Projectile.NewProjectile(projectile.position.X + (float)(projectile.width * 5), projectile.position.Y + (float)(projectile.height * 4), 0, 5, proType, proDamage, 3, projectile.owner);
                    int proj3 = Projectile.NewProjectile(projectile.position.X + (float)(projectile.width * -3), projectile.position.Y + (float)(projectile.height * 7), 0, 5, proType, proDamage, 3, projectile.owner);
                    int proj4 = Projectile.NewProjectile(projectile.position.X + (float)(projectile.width * -6), projectile.position.Y + (float)(projectile.height * 10), 0, 5, proType, proDamage, 3, projectile.owner);
                    Main.projectile[proj].friendly = projectile.friendly;
                    Main.projectile[proj].hostile = projectile.hostile;
                projectile.active = false;
            }
        }
    }
}