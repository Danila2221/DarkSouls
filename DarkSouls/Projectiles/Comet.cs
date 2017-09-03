using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using DarkSouls.Projectiles;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace DarkSouls.Projectiles
{
    public class Comet : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.aiStyle = -1;
            projectile.hostile = true;
            projectile.friendly = false;
            projectile.penetrate = 3;
            projectile.scale = 1;
            projectile.width = 15;
            projectile.height = 15;
            projectile.alpha = 255;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;

        }
        Vector2[] lastpos = new Vector2[20];
        int lastposindex = 0;
        public void AI()
        {
            this.projectile.rotation = (float)Math.Atan2((double)this.projectile.velocity.Y, (double)this.projectile.velocity.X);


            this.projectile.rotation += (Main.rand.Next(-100, 100)) / 2400f;

            this.projectile.velocity.Y = (float)Math.Sin(this.projectile.rotation) * 10;
            this.projectile.velocity.X = (float)Math.Cos(this.projectile.rotation) * 10;



            if (this.projectile.timeLeft < 100)
            {
                this.projectile.scale *= 0.9f;
                this.projectile.damage = 0;
            }





            lastpos[lastposindex] = this.projectile.position;
            lastposindex++;
            if (lastposindex > 19) lastposindex = 0;



        }



        public void PostDraw(SpriteBatch sp)
        {
            Random rand1 = new Random((int)Main.time);
            Texture2D MyTexture = Main.projectileTexture[mod.ProjectileType("Comet")];
            Rectangle fromrect = new Rectangle(0, 0, this.projectile.width, this.projectile.height);
            Vector2 PC;
            Color targetColor = new Color(0, 50, 255, 0);
            int modlastposindex = lastposindex;
            for (int i = 0; i < 19; i++)
            {
                float rotmod = rand1.Next(-100, 100) / 100f;
                float scalemod = rand1.Next(50, 150) / 100f;
                lastpos[modlastposindex].X += rand1.Next(-1, 1);
                lastpos[modlastposindex].Y += rand1.Next(-1, 1);
                PC = lastpos[modlastposindex] + new Vector2(this.projectile.width / 2, this.projectile.height / 2);


                sp.Draw(
                            MyTexture,
                            PC - Main.screenPosition,
                            fromrect,
                            targetColor,
                            this.projectile.rotation + rotmod,
                            new Vector2(this.projectile.width / 2, this.projectile.height / 2),
                            1f * (0.1f * i) * this.projectile.scale * scalemod,
                            SpriteEffects.None,
                            0f);
                modlastposindex++;
                if (modlastposindex > 19) modlastposindex = 0;

            }
            targetColor = new Color(0, 0, 255, 0);
            modlastposindex = lastposindex;
            rand1 = new Random((int)Main.time);

            for (int i = 0; i < 19; i++)
            {
                float rotmod = rand1.Next(-100, 100) / 100f;
                float scalemod = rand1.Next(50, 150) / 100f;
                PC = lastpos[modlastposindex] + new Vector2(this.projectile.width / 2, this.projectile.height / 2);

                sp.Draw(
                            MyTexture,
                            PC - Main.screenPosition,
                            fromrect,
                            targetColor,
                            this.projectile.rotation + rotmod,
                            new Vector2(this.projectile.width / 2, this.projectile.height / 2),
                            1f * (0.09f * i) * this.projectile.scale * scalemod,
                            SpriteEffects.None,
                            0f);
                modlastposindex++;
                if (modlastposindex > 19) modlastposindex = 0;

            }
            return;
        }


    }
}
