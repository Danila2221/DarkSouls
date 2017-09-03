using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
	public class FlareBall : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flare");

            
        }
        public override void SetDefaults()
		{

			projectile.width = 16;
			projectile.height = 16;
			projectile.penetrate = 1;
			projectile.knockBack = 9;
			projectile.timeLeft = 200;
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
                int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("Flare"), 70, 0, projectile.owner);
                Main.projectile[proj].friendly = projectile.friendly;
                Main.projectile[proj].hostile = projectile.hostile;
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
            }
            projectile.active = false;
        }

    }
}