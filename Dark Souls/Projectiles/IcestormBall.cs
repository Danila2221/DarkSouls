using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
	public class IcestormBall : ModProjectile
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Icestorm");

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
                    int proType = mod.ProjectileType("IcestormIcicle1");
                int proType2 = mod.ProjectileType("IcestormIcicle2");
                int proType3 = mod.ProjectileType("IcestormIcicle3");
                int proType4 = mod.ProjectileType("IcestormIcicle4");
                int proDamage = 100;
                int count = 5;
                for (int i = 1; i <= count; i++)
                {
                    int proj = Projectile.NewProjectile(projectile.position.X + (float)(projectile.width * (Main.rand.Next(50))), projectile.position.Y + (float)(projectile.height * (Main.rand.Next(60) - 2)), ((Main.rand.Next(30)) * -1), 0, proType, proDamage, 3, projectile.owner);
                    int proj2 = Projectile.NewProjectile(projectile.position.X + (float)(projectile.width * (Main.rand.Next(50))), projectile.position.Y + (float)(projectile.height * (Main.rand.Next(60) - 2)), ((Main.rand.Next(30)) * -1), 0, proType2, proDamage, 3, projectile.owner);
                    int proj3 = Projectile.NewProjectile(projectile.position.X + (float)(projectile.width * (Main.rand.Next(50))), projectile.position.Y + (float)(projectile.height * (Main.rand.Next(60) - 2)), ((Main.rand.Next(30)) * -1), 0, proType3, proDamage, 3, projectile.owner);
                    int proj4 = Projectile.NewProjectile(projectile.position.X + (float)(projectile.width * (Main.rand.Next(50))), projectile.position.Y + (float)(projectile.height * (Main.rand.Next(60) - 2)), ((Main.rand.Next(30)) * -1), 0, proType4, proDamage, 3, projectile.owner);
                    Main.projectile[proj].friendly = projectile.friendly;
                    Main.projectile[proj].hostile = projectile.hostile;
                }
                projectile.active = false;
            }
        }
    }
}