using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
	public class Lightning4Ball : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lightning 4");
        }
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.penetrate = 1;
            projectile.knockBack = 9;
            projectile.timeLeft = 360;
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
                int proType = mod.ProjectileType("Lightning4Bolt1");
                int proDamage = 80;
                int proj = Projectile.NewProjectile(projectile.position.X + (float)(projectile.width / 2), projectile.position.Y + (float)(projectile.height / 2), 0, 0, proType, proDamage, 8, projectile.owner);
                Main.projectile[proj].friendly = projectile.friendly;
                Main.projectile[proj].hostile = projectile.hostile;
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
            }
            projectile.active = false;
        }
    }
}