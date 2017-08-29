using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
	public class FireTrails : ModProjectile
	{
		public override void SetStaticDefaults()
		{
  			
		}

		public override void SetDefaults()
		{
			projectile.width = 15;               //The width of projectile hitbox
			projectile.height = 15;              //The height of projectile hitbox
			projectile.aiStyle = 0;             //The ai style of the projectile, please reference the source code of Terraria
			projectile.light = 1;
        //Can the projectile deal damage to enemies?
			projectile.hostile = true;         //Can the projectile deal damage to the player?
          //Is the projectile shoot by a ranged weapon?
			
			projectile.penetrate = 1;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			        //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)          //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in)          //How much light emit around the projectile
			projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
			projectile.tileCollide = true;
			          //Can the projectile collide with tiles?

		}

public override void AI()
        {
            this.projectile.rotation = (float)Math.Atan2((double)this.projectile.velocity.Y, (double)this.projectile.velocity.X) + 1.01f;
            if (this.projectile.ai[0] == 0f)
            {
                #region phoenix shit
                for (int num154 = 0; num154 < 1; num154++)
                {
                    int num155 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
                    if (Main.rand.Next(3) != 0 || true)
                    {
                        Main.dust[num155].noGravity = true;
                        Main.dust[num155].scale *= 2f;
                        Dust expr_6767_cp_0 = Main.dust[num155];
                        expr_6767_cp_0.velocity.X = expr_6767_cp_0.velocity.X * 2f; //1 was 2
                        Dust expr_6785_cp_0 = Main.dust[num155];
                        expr_6785_cp_0.velocity.Y = expr_6785_cp_0.velocity.Y * 2f; //1 was 2
                    }
                    Main.dust[num155].scale *= 1.5f;
                    Dust expr_67BC_cp_0 = Main.dust[num155];
                    expr_67BC_cp_0.velocity.X = expr_67BC_cp_0.velocity.X * 2.2f; //2 was 1.2
                    Dust expr_67DA_cp_0 = Main.dust[num155];
                    expr_67DA_cp_0.velocity.Y = expr_67DA_cp_0.velocity.Y * 1.2f; //0.5 was 1.2
                    Main.dust[num155].scale *= (float)((((projectile.ai[0] + 1) / 2) * 25) / 50);

                }
                #endregion
                #region not last frame
                this.projectile.alpha -= 50;
                if (this.projectile.alpha <= 0)
                {
                    this.projectile.alpha = 0;
                    this.projectile.ai[0] = 1f;
                    if (this.projectile.ai[1] == 0f)
                    {
                        this.projectile.ai[1] += 1f;
                        this.projectile.position += this.projectile.velocity * 14f; //12 seemed good was 2
                    }
                    #region if not last thorn
                    if (this.projectile.type == 7 && Main.myPlayer == this.projectile.owner)
                    {
                        int num14 = this.projectile.type;
                        #region should be last thorn
                        if (this.projectile.ai[1] >= 9f) // change for max parts was 17
                        {
                            num14 = mod.ProjectileType("FireTrail");
                        }
                        else
                            num14 = mod.ProjectileType("FireTrails");
                        #endregion
                        
                                                                int num15 = Projectile.NewProjectile(this.projectile.position.X + this.projectile.velocity.X + (float)(this.projectile.width / 2), this.projectile.position.Y + this.projectile.velocity.Y + (float)(this.projectile.height / 2), this.projectile.velocity.X, this.projectile.velocity.Y, num14, this.projectile.damage, this.projectile.knockBack, this.projectile.owner);
                                                                Main.projectile[num15].damage = this.projectile.damage;
                                                                Main.projectile[num15].ai[1] = this.projectile.ai[1] + 1f;
                                                                NetMessage.SendData(27, -1, -1, null, num15, 0f, 0f, 0f, 0);
                         
                        #region funtime
                        
                                                                Vector2 holdme = new Vector2(this.projectile.velocity.X,this.projectile.velocity.Y);
                                                                this.projectile.velocity=RotateByRightAngle(holdme);
                                                                num15 = Projectile.NewProjectile(this.projectile.position.X + this.projectile.velocity.X + (float)(this.projectile.width / 2), this.projectile.position.Y + this.projectile.velocity.Y + (float)(this.projectile.height / 2), this.projectile.velocity.X, this.projectile.velocity.Y, num14, this.projectile.damage, this.projectile.knockBack, this.projectile.owner);
                                                                Main.projectile[num15].damage = this.projectile.damage;
                                                                Main.projectile[num15].ai[1] = this.projectile.ai[1] + 1f;
                                                                NetMessage.SendData(27, -1, -1, null, num15, 0f, 0f, 0f, 0);
                                                                this.projectile.velocity=RotateByLeftAngle(holdme);
                                                                num15 = Projectile.NewProjectile(this.projectile.position.X + this.projectile.velocity.X + (float)(this.projectile.width / 2), this.projectile.position.Y + this.projectile.velocity.Y + (float)(this.projectile.height / 2), this.projectile.velocity.X, this.projectile.velocity.Y, num14, this.projectile.damage, this.projectile.knockBack, this.projectile.owner);
                                                                Main.projectile[num15].damage = this.projectile.damage;
                                                                Main.projectile[num15].ai[1] = this.projectile.ai[1] + 1f;
                                                                NetMessage.SendData(27, -1, -1, null, num15, 0f, 0f, 0f, 0);
                         
                        #endregion
                        #region more funtime
                        
                                                                Vector2 holdme1 = new Vector2(this.projectile.velocity.X,this.projectile.velocity.Y);
                                                                this.projectile.velocity=RotateAboutOrigin(holdme,(float)((Math.PI*7)/4f)); // 1 WAS 4
                                                                num15 = Projectile.NewProjectile(this.projectile.position.X + this.projectile.velocity.X + (float)(this.projectile.width / 2), this.projectile.position.Y + this.projectile.velocity.Y + (float)(this.projectile.height / 2), this.projectile.velocity.X, this.projectile.velocity.Y, num14, this.projectile.damage, this.projectile.knockBack, this.projectile.owner);
                                                                Main.projectile[num15].damage = this.projectile.damage;
                                                                Main.projectile[num15].ai[1] = this.projectile.ai[1] + 1f;
                                                                NetMessage.SendData(27, -1, -1, null, num15, 0f, 0f, 0f, 0);
                                                                this.projectile.velocity.X = holdme.X;
                                                                this.projectile.velocity.Y = holdme.Y;
                                                                this.projectile.velocity=RotateAboutOrigin(holdme,(float)((Math.PI*1)/4f)); //1 was 4
                                                                num15 = Projectile.NewProjectile(this.projectile.position.X + this.projectile.velocity.X + (float)(this.projectile.width / 2), this.projectile.position.Y + this.projectile.velocity.Y + (float)(this.projectile.height / 2), this.projectile.velocity.X, this.projectile.velocity.Y, num14, this.projectile.damage, this.projectile.knockBack, this.projectile.owner);
                                                                Main.projectile[num15].damage = this.projectile.damage;
                                                                Main.projectile[num15].ai[1] = this.projectile.ai[1] + 1f;
                                                                NetMessage.SendData(27, -1, -1, null, num15, 0f, 0f, 0f, 0);
                         
                        #endregion
                        #region most fun ever
                        
                        if((int)(this.projectile.ai[1])%8<4)
                        {
                                                                Vector2 holdme2 = new Vector2(this.projectile.velocity.X,this.projectile.velocity.Y);
                                                                this.projectile.velocity=RotateAboutOrigin(holdme,(float)((Math.PI*1)/8f)); //4 was 8
                                                                int num151 = Projectile.NewProjectile(this.projectile.position.X + this.projectile.velocity.X + (float)(this.projectile.width / 2), this.projectile.position.Y + this.projectile.velocity.Y + (float)(this.projectile.height / 2), this.projectile.velocity.X, this.projectile.velocity.Y, num14, this.projectile.damage, this.projectile.knockBack, this.projectile.owner);
                                                                Main.projectile[num15].damage = this.projectile.damage;
                                                                Main.projectile[num15].ai[1] = this.projectile.ai[1] + 1f;
                                                                NetMessage.SendData(27, -1, -1, null, num15, 0f, 0f, 0f, 0);
                        }
                        else
                        {
                                                                Vector2 holdme3 = new Vector2(this.projectile.velocity.X,this.projectile.velocity.Y);
                                                                this.projectile.velocity=RotateAboutOrigin(holdme,(float)((Math.PI*15)/4f)); //4 was 8
                                                                int num151 = Projectile.NewProjectile(this.projectile.position.X + this.projectile.velocity.X + (float)(this.projectile.width / 2), this.projectile.position.Y + this.projectile.velocity.Y + (float)(this.projectile.height / 2), this.projectile.velocity.X, this.projectile.velocity.Y, num14, this.projectile.damage, this.projectile.knockBack, this.projectile.owner);
                                                                Main.projectile[num15].damage = this.projectile.damage;
                                                                Main.projectile[num15].ai[1] = this.projectile.ai[1] + 1f;
                                                                NetMessage.SendData(27, -1, -1, null, num15, 0f, 0f, 0f, 0);
                        }
                         
                        #endregion
                        int z1 = Main.rand.Next(2, 3);
                        if (projectile.ai[1] % 3 != 0) z1 = 1;
                        else z1 = (6 - (int)(projectile.ai[1] / 3)) / 2;
                        for (int zzz = 0; zzz < z1; zzz++)
                        {


                            int z2 = Main.rand.Next(-1, 2);
                            if (z2 < 0) z2 += 16;
                            Vector2 holdme4 = new Vector2(this.projectile.velocity.X, this.projectile.velocity.Y);
                            holdme = RotateAboutOrigin(holdme, (float)((Math.PI * z2) / 8f)); //4 last time was 8
                            int num151 = Projectile.NewProjectile(this.projectile.position.X + holdme.X + (float)(this.projectile.width / 2), this.projectile.position.Y + holdme.Y + (float)(this.projectile.height / 2), holdme.X, holdme.Y, num14, this.projectile.damage, this.projectile.knockBack, this.projectile.owner);
                            Main.projectile[num15].damage = this.projectile.damage;
                            Main.projectile[num15].ai[1] = this.projectile.ai[1] + 1f;
                            NetMessage.SendData(27, -1, -1, null, num15, 0f, 0f, 0f, 0);
                        }
                        return;
                    }
                    #endregion
                }
                #endregion
            }
            else
            {
                #region makes it pretty
                if (this.projectile.alpha < 170 && this.projectile.alpha + 5 >= 170)
                {
                    /*
                    for (int j = 0; j < 3; j++)
                    {
                        Dust.NewDust(this.projectile.position, this.projectile.width, this.projectile.height, 18, this.projectile.velocity.X * 0.025f, this.projectile.velocity.Y * 0.025f, 170, default(Color), 1f);
                    }
                    Dust.NewDust(this.projectile.position, this.projectile.width, this.projectile.height, 14, 0f, 0f, 170, default(Color), 1f);

                     */
                }
                #endregion
                this.projectile.alpha += 5;
                if (this.projectile.alpha >= 255)
                {
                    this.projectile.Kill();
                    return;
                }
            }

        }

               
        public Vector2 RotateByRightAngle(Vector2 vector)
        {
            return new Vector2(vector.Y, -vector.X);
        }
        public Vector2 RotateByLeftAngle(Vector2 vector)
        {
            return new Vector2(-vector.Y, vector.X);
        }
        /*
        public Vector2 MyRotate(Vector2 vector,float rot)
        {
            float (
            px = cos(rot) * (px-ox) - sin(rot) * (py-oy) + ox;
            py = sin(rot) * (px-ox) + cos(rot) * (py-oy) + oy;
        }
        */
        public Vector2 RotateAboutOrigin(Vector2 point, float rotation)
        {
            if (rotation < 0)
                rotation += (float)(Math.PI * 4);
            Vector2 u = point; //point relative to origin  

            if (u == Vector2.Zero)
                return point;

            float a = (float)Math.Atan2(u.Y, u.X); //angle relative to origin  
            a += rotation; //rotate  

            //u is now the new point relative to origin  
            u = u.Length() * new Vector2((float)Math.Cos(a), (float)Math.Sin(a));
            return u;
        }





    }





		

		
	}

