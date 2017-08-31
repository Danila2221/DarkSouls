using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
    public class Oracle : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.aiStyle = 24;
            projectile.hostile = true;
            projectile.height = 16;
            projectile.scale = 1;
            projectile.tileCollide = false;
            projectile.width = 16;
            projectile.timeLeft = 250;
        }
        public override void AI()
        {
            projectile.rotation += 1f;
            if (Main.rand.Next(4) == 0)
            {
                int dust = Dust.NewDust(new Vector2((float)projectile.position.X, (float)projectile.position.Y), projectile.width, projectile.height, 6, 0, 0, 50, Color.Green, 3.0f);
                Main.dust[dust].noGravity = false;
            }
            Lighting.AddLight((int)(projectile.position.X / 16f), (int)(projectile.position.Y / 16f), 0.4f, 0.1f, 0.1f);

            if (projectile.velocity.X <= 4 && projectile.velocity.Y <= 4 && projectile.velocity.X >= -4 && projectile.velocity.Y >= -4)
            {
                float accel = 1f + (Main.rand.Next(10, 30) * 0.001f);
                projectile.velocity.X *= accel;
                projectile.velocity.Y *= accel;
            }

            Rectangle projrec = new Rectangle((int)projectile.position.X + (int)projectile.velocity.X, (int)projectile.position.Y + (int)projectile.velocity.Y, projectile.width, projectile.height);
            Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player[Main.myPlayer].width, (int)Main.player[Main.myPlayer].height);

            if (projrec.Intersects(prec))
            {
                Main.player[Main.myPlayer].AddBuff(13, 600, true);
                Main.player[Main.myPlayer].AddBuff(36, 300, false);
                Main.player[Main.myPlayer].AddBuff(30, 7200, false);
                Main.player[Main.myPlayer].AddBuff(20, 3600, false);
            }

        }


    }
}
