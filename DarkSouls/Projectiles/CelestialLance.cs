using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace DarkSouls.Projectiles
{
    public class CelestialLanceP : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.aiStyle = 19;
            projectile.width = 34;
            projectile.height = 34;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.tileCollide = false;
            projectile.scale = 1f;
            projectile.hide = true;
            projectile.ownerHitCheck = false;
            projectile.melee = true;
            projectile.alpha = 0;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            
            Projectile.NewProjectile(target.position.X - 0, target.position.Y - 25, 0, 5, ProjectileID.FallingStar, 500, 1f, Main.myPlayer);
        }


        public override void AI()
        {
            Lighting.AddLight((int)((projectile.position.X + (float)projectile.width) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), 0.8f, 0.7f, 0.1f);
            Main.player[projectile.owner].direction = projectile.direction;
            Main.player[projectile.owner].heldProj = projectile.whoAmI;
            Main.player[projectile.owner].itemTime = Main.player[projectile.owner].itemAnimation;
            projectile.position.X = Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2) - (float)(projectile.width / 2);
            projectile.position.Y = Main.player[projectile.owner].position.Y + (float)(Main.player[projectile.owner].height / 2) - (float)(projectile.height / 2);
            projectile.position += projectile.velocity * projectile.ai[0]; if (projectile.ai[0] == 0f)
            {
                projectile.ai[0] = 3f;
                projectile.netUpdate = true;
            }
            if (Main.player[projectile.owner].itemAnimation < Main.player[projectile.owner].itemAnimationMax / 3)
            {
                projectile.ai[0] -= 1.1f;
            }
            else
            {
                projectile.ai[0] += 0.95f;
            }

            if (Main.player[projectile.owner].itemAnimation == 0)
            {
                projectile.Kill();
            }

            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 2.355f;
            if (projectile.spriteDirection == -1)
            {
                projectile.rotation -= 1.57f;
            }
        }
    }
}
