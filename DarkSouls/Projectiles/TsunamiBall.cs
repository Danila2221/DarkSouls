using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
	public class TsunamiBall : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tsunami");
        }
        public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.penetrate = 8;
			projectile.knockBack = 9;
			projectile.timeLeft = 0;
			projectile.alpha = 100;
			projectile.light = 1f;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.magic = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
		}
        public override void Kill(int timeLeft)
        {
            if (!projectile.active)
            {
                return;
            }
        projectile.timeLeft = 0;
            {
                if (projectile.position.X + (float)(projectile.width / 2) > Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2))
                {
                    int proType = mod.ProjectileType("TsunamiReverse");
                    int proDamage = 60;
                    int proj = Projectile.NewProjectile(projectile.position.X + (float)(projectile.width * 10f), 0, 0, proType, proDamage, 8, projectile.owner);
                    Main.projectile[proj].friendly = projectile.friendly;
                    Main.projectile[proj].hostile = projectile.hostile;
                }
                else
                {
                    int proType = mod.ProjectileType("Tsunami");
                    int proDamage = 60;
                    int proj = Projectile.NewProjectile(projectile.position.X + (float)(projectile.width * -9), 0, 0, proType, proDamage, 8, projectile.owner);
                    Main.projectile[proj].friendly = projectile.friendly;
                    Main.projectile[proj].hostile = projectile.hostile;
                }
                projectile.active = false;
            }
        }
    }
}