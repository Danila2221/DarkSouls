using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
    public class HoldBall : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hold");
            
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
                int proType = mod.ProjectileType("EffectBuff");
                int proDamage = 0;
                int proj = Projectile.NewProjectile(projectile.position.X + (float)(projectile.width / 2), projectile.position.Y + (float)(projectile.height - 16), 0, 0, proType, proDamage, 20, projectile.owner);
                Main.projectile[proj].friendly = projectile.friendly;
                Main.projectile[proj].hostile = projectile.hostile;
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
            }
            projectile.active = false;
        }

        public override void AI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter > 3)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 6)
            {
                projectile.Kill();
                return;
            }
            int hitPlayer = 0;

            Rectangle projrec = new Rectangle((int)projectile.position.X + (int)projectile.velocity.X, (int)projectile.position.Y + (int)projectile.velocity.Y, projectile.width, projectile.height);
            Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player[Main.myPlayer].width, (int)Main.player[Main.myPlayer].height);
            if (projrec.Intersects(prec))
            {
                if (hitPlayer <= 0)
                {
                    ////if(player.HasBuff(mod.BuffType("OmnirsProtect")) <= -1) projectile.Kill();
                    //Main.player[Main.myPlayer].AddBuff("OmnirsHold", 120, false);
                    hitPlayer = 1;
                }
            }
        }
    }
}