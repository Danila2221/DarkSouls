using DarkSouls.Projectiles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
    public class ChaosBall2 : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.scale = 1;
            projectile.alpha = 200;
            projectile.aiStyle = -1;
            projectile.timeLeft = 300;
            projectile.friendly = true;
            projectile.penetrate = 10;
            projectile.light = 1;
            projectile.tileCollide = false;
            projectile.magic = true;
        }
        public override void  AI()
        {
            if (projectile.type == 96 && projectile.localAI[0] == 0f)
            {
                projectile.localAI[0] = 1f;
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 20);
            }
            if (projectile.type == mod.ProjectileType("ChaosBall2"))
            {
                int num40 = Dust.NewDust(new Vector2(projectile.position.X + projectile.velocity.X, projectile.position.Y + projectile.velocity.Y), projectile.width, projectile.height, 27, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 3f);
                Main.dust[num40].noGravity = true;
                if (Main.rand.Next(10) == 0)
                {
                    num40 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 27, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1.4f);
                }
            }
            else
            {
                if (projectile.type == 95 || projectile.type == 96)
                {
                    int num41 = Dust.NewDust(new Vector2(projectile.position.X + projectile.velocity.X, projectile.position.Y + projectile.velocity.Y), projectile.width, projectile.height, 75, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 3f * projectile.scale);
                    Main.dust[num41].noGravity = true;
                }
                else
                {
                    for (int num42 = 0; num42 < 2; num42++)
                    {
                        int num43 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
                        Main.dust[num43].noGravity = true;
                        Dust expr_225D_cp_0 = Main.dust[num43];
                        expr_225D_cp_0.velocity.X = expr_225D_cp_0.velocity.X * 0.3f;
                        Dust expr_227B_cp_0 = Main.dust[num43];
                        expr_227B_cp_0.velocity.Y = expr_227B_cp_0.velocity.Y * 0.3f;
                    }
                }
            }
            if (projectile.type != mod.ProjectileType("ChaosBall2") && projectile.type != 96)
            {
                projectile.ai[1] += 1f;
            }
            if (projectile.ai[1] >= 20f)
            {
                projectile.velocity.Y = projectile.velocity.Y + 0.2f;
            }
            projectile.rotation += 0.3f * (float)projectile.direction;
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
                return;
            }
        }

    }
}
