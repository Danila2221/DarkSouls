using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DarkSouls.NPCs.Enemies
{
    public class TheEarthFiendLich : ModNPC
    {
        float customAi1;
        int OTimeLeft = 2000;
        bool walkAndShoot = true;

        bool canDrown = false;
        int drownTimerMax = 2000;
        int drownTimer = 2000;
        int drowningRisk = 1200;

        float npcAcSPD = 0.6f; //How fast they accelerate.
        float npcSPD = 1.5f; //Max speed

        float npcEnrAcSPD = 0.95f; //How fast they accelerate.
        float npcEnrSPD = 2.0f; //Max speed

        bool tooBig = false;
        bool lavaJumping = false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lich, the Earth Fiend");

            Main.npcFrameCount[npc.type] = 1;
        }
        public override void SetDefaults()
        {
            
            npc.width = 90;
            npc.height = 150;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath5;
            npc.value = 80000f;
            npc.npcSlots = 100;
            npc.scale = 1f;
            npc.aiStyle = -1;//22;
            npc.knockBackResist = 0.1f;
            
            animationType = -1;
            npc.lavaImmune = true;
            npc.buffImmune[BuffID.Venom] = true;
            npc.buffImmune[BuffID.Confused] = true;
            npc.buffImmune[BuffID.CursedInferno] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.damage = 95;
            npc.defense = 40;
            npc.lifeMax = 30000;
            npc.boss = true;
            music = MusicID.Boss1;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.6f);
        }

        public void teleport(bool pre)
        {
            if (!Main.expertMode)
            {
                if (Main.netMode != 2)
                {
                    Main.PlaySound(2, (int)npc.Center.X, (int)npc.Center.Y, 8);
                    for (int m = 0; m < 25; m++)
                    {
                        int dustID = Dust.NewDust(npc.position, npc.width, npc.height, 6, 0, 0, 100, Color.White, 2f);
                        Main.dust[dustID].noGravity = true;
                        Main.dust[dustID].velocity = new Vector2(MathHelper.Lerp(-1f, 1f, (float)Main.rand.NextDouble()), MathHelper.Lerp(-1f, 1f, (float)Main.rand.NextDouble()));
                        Main.dust[dustID].velocity *= 7f;
                    }
                }
            }
        }  
        public override void AI()  //  warrior ai
        {
            #region Ogre/custom frames
            int num = 1;
            if (!Main.dedServ)
            {
                num = Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type];
            }
            if (npc.direction == 1)
            {
                npc.spriteDirection = 1;
            }
            if (npc.direction == -1)
            {
                npc.spriteDirection = -1;
            }
            npc.rotation = npc.velocity.X * 0.08f;
            npc.frameCounter += 1.0;
            if (npc.frameCounter >= 8.0)
            {
                npc.frame.Y = npc.frame.Y + num;
                npc.frameCounter = 0.0;
            }
            if (npc.frame.Y >= num * Main.npcFrameCount[npc.type])
            {
                npc.frame.Y = 0;
            }
            #endregion
            #region Floater
            bool flag19 = false;
            if (npc.justHit)
            {
                npc.ai[2] = 0f;
            }
            if (npc.ai[2] >= 0f)
            {
                int num283 = 16;
                bool flag21 = false;
                bool flag22 = false;
                if (npc.position.X > npc.ai[0] - (float)num283 && npc.position.X < npc.ai[0] + (float)num283)
                {
                    flag21 = true;
                }
                else if ((npc.velocity.X < 0f && npc.direction > 0) || (npc.velocity.X > 0f && npc.direction < 0))
                {
                    flag21 = true;
                }
                num283 += 24;
                if (npc.position.Y > npc.ai[1] - (float)num283 && npc.position.Y < npc.ai[1] + (float)num283)
                {
                    flag22 = true;
                }
                if (flag21 & flag22)
                {
                    npc.ai[2] += 1f;
                    if (npc.ai[2] >= 30f && num283 == 16)
                    {
                        flag19 = true;
                    }
                    if (npc.ai[2] >= 60f)
                    {
                        npc.ai[2] = -200f;
                        npc.direction *= -1;
                        npc.velocity.X = npc.velocity.X * -1f;
                        npc.collideX = false;
                    }
                }
                else
                {
                    npc.ai[0] = npc.position.X;
                    npc.ai[1] = npc.position.Y;
                    npc.ai[2] = 0f;
                }
                npc.TargetClosest(true);
            }
            else
            {
                npc.ai[2] += 1f;
                if (Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) > npc.position.X + (float)(npc.width / 2))
                {
                    npc.direction = -1;
                }
                else
                {
                    npc.direction = 1;
                }
            }
            int num284 = (int)((npc.position.X + (float)(npc.width / 2)) / 16f) + npc.direction * 2;
            int num285 = (int)((npc.position.Y + (float)npc.height) / 16f);
            bool flag23 = true;
            bool flag24 = false;
            int num286 = 3;
            //int num;
            for (int num309 = num285; num309 < num285 + num286; num309 = num + 1)
            {
                if (Main.tile[num284, num309] == null)
                {
                    Main.tile[num284, num309] = new Tile();
                }
                if ((Main.tile[num284, num309].nactive() && Main.tileSolid[(int)Main.tile[num284, num309].type]) || Main.tile[num284, num309].liquid > 0)
                {
                    if (num309 <= num285 + 1)
                    {
                        flag24 = true;
                    }
                    flag23 = false;
                    break;
                }
                num = num309;
            }
            if (Main.player[npc.target].npcTypeNoAggro[npc.type])
            {
                bool flag25 = false;
                //for (int num310 = num285; num310 < num285 + num286 - 2; num310 = num + 1)
                //{
                //    if (Main.tile[num284, num310] == null)
                //    {
                //        Main.tile[num284, num310] = new Tile();
                //    }
                //    if ((Main.tile[num284, num310].nactive() && Main.tileSolid[(int)Main.tile[num284, num310].type]) || Main.tile[num284, num310].liquid > 0)
                //    {
                //        flag25 = true;
                //        break;
                //    }
                //    num = num310;
                //}
                npc.directionY = (!flag25).ToDirectionInt();
            }
            if (flag19)
            {
                flag24 = false;
                flag23 = true;
            }
            if (flag23)
            {
                npc.velocity.Y = npc.velocity.Y + 0.1f;
                if (npc.velocity.Y > 3f)
                {
                    npc.velocity.Y = 3f;
                }
            }
            else
            {
                if (npc.directionY < 0 && npc.velocity.Y > 0f)
                {
                    npc.velocity.Y = npc.velocity.Y - 0.1f;
                }
                if (npc.velocity.Y < -4f)
                {
                    npc.velocity.Y = -4f;
                }
            }
            if (npc.collideX)
            {
                npc.velocity.X = npc.oldVelocity.X * -0.4f;
                if (npc.direction == -1 && npc.velocity.X > 0f && npc.velocity.X < 1f)
                {
                    npc.velocity.X = 1f;
                }
                if (npc.direction == 1 && npc.velocity.X < 0f && npc.velocity.X > -1f)
                {
                    npc.velocity.X = -1f;
                }
            }
            if (npc.collideY)
            {
                npc.velocity.Y = npc.oldVelocity.Y * -0.25f;
                if (npc.velocity.Y > 0f && npc.velocity.Y < 1f)
                {
                    npc.velocity.Y = 1f;
                }
                if (npc.velocity.Y < 0f && npc.velocity.Y > -1f)
                {
                    npc.velocity.Y = -1f;
                }
            }

            float npcSPD = 4f;
            if (npc.direction == -1 && npc.velocity.X > -npcSPD)// Facing left, velo.x is above -10
            {
                npc.velocity.X = npc.velocity.X - 0.1f;//accelerate left
                if (npc.velocity.X > npcSPD)//speed is greater that maxspeed
                {
                    npc.velocity.X = npcSPD; //set speed to 10
                }
                else if (npc.velocity.X > 0f)//speed is at 1/2 point
                {
                    npc.velocity.X = npc.velocity.X + 0.05f;//accelerate left, slowly
                }
                if (npc.velocity.X < -npcSPD)//speed is below -10
                {
                    npc.velocity.X = -npcSPD; //set speed to -10
                }
            }
            else if (npc.direction == 1 && npc.velocity.X < npcSPD)// Facing right, velo.x is below 10
            {
                npc.velocity.X = npc.velocity.X + 0.1f;
                if (npc.velocity.X < -npcSPD)
                {
                    npc.velocity.X = -npcSPD;
                }
                else if (npc.velocity.X < 0f)
                {
                    npc.velocity.X = npc.velocity.X - 0.05f;
                }
                if (npc.velocity.X > npcSPD)
                {
                    npc.velocity.X = npcSPD;
                }
            }
            npcSPD = 1.5f;//Vertical speed?
            if (npc.directionY == -1 && npc.velocity.Y > -npcSPD)
            {
                npc.velocity.Y = npc.velocity.Y - npcAcSPD; // 0.04f;
                if (npc.velocity.Y > npcSPD)
                {
                    npc.velocity.Y = npc.velocity.Y - npcAcSPD;//0.05f;
                }
                else if (npc.velocity.Y > 0f)
                {
                    npc.velocity.Y = npc.velocity.Y + npcAcSPD;//0.03f;
                }
                if (npc.velocity.Y < -npcSPD)
                {
                    npc.velocity.Y = -npcSPD;
                }
            }
            else if (npc.directionY == 1 && npc.velocity.Y < npcSPD)
            {
                npc.velocity.Y = npc.velocity.Y + npcAcSPD;// 0.04f;
                if (npc.velocity.Y < -npcSPD)
                {
                    npc.velocity.Y = npc.velocity.Y + npcAcSPD;
                }
                else if (npc.velocity.Y < 0f)
                {
                    npc.velocity.Y = npc.velocity.Y - npcAcSPD;//0.03f;
                }
                if (npc.velocity.Y > npcSPD)
                {
                    npc.velocity.Y = npcSPD;
                }
            }
            #endregion

            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];
            for (int m = npc.oldPos.Length - 1; m > 0; m--)
            {
                npc.oldPos[m] = npc.oldPos[m - 1];
            }
            npc.oldPos[0] = npc.position;
            bool seeplayer = npc.ai[0] >= 200 || Collision.CanHit(npc.position, npc.width, npc.height, player.position, player.width, player.height);
            //public static void AIFlier(NPC npc, ref float[] ai, bool sporadic = true, float moveIntervalX = 0.1f, float moveIntervalY = 0.04f, float maxSpeedX = 4f, float maxSpeedY = 1.5f, bool canBeBored = true, int timeUntilBoredom = 300)
            npc.rotation = npc.velocity.X * 0.08f;
            if (Main.netMode != 1)
            {
                customAi1 += (Main.rand.Next(2, 5) * 0.1f) * npc.scale;
                if (customAi1 >= 10f)
                {
                    #region Projectiles
                    customAi1 += (Main.rand.Next(2, 5) * 0.1f) * npc.scale;
                    if (customAi1 >= 10f)
                    {
                        npc.TargetClosest(true);
                        if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
                        {
                            if (Main.rand.Next(100) == 1)
                            {
                                float num48 = 8f;
                                float aNV1;
                                //int aNV2;
                                if (npc.direction > 0)
                                {
                                    aNV1 = (((npc.width) * 1.1f));
                                }
                                else
                                {
                                    aNV1 = (((npc.width) * -.1f));
                                }
                                Vector2 vector8 = new Vector2((npc.position.X + aNV1), npc.position.Y + (npc.height - 75));
                                float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-20, 0x15);
                                float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-20, 0x15);
                                if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
                                {
                                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 5);
                                    float num51 = (float)Math.Sqrt((double)((speedX * speedX) + (speedY * speedY)));
                                    num51 = num48 / num51;
                                    speedX *= num51;
                                    speedY *= num51;
                                    int damage = 40;
                                    if (Main.expertMode) { damage = 60; }
                                    int type = mod.ProjectileType("Ice2Ball");
                                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
                                    Main.projectile[num54].timeLeft = 100;
                                    Main.projectile[num54].aiStyle = -1;
                                    customAi1 = 1f;
                                }
                                npc.netUpdate = true;
                            }
                            if (Main.rand.Next(250) == 1)
                            {
                                float num48 = 8f;
                                float aNV1;
                                //int aNV2;
                                if (npc.direction > 0)
                                {
                                    aNV1 = (((npc.width) * 1.1f));
                                }
                                else
                                {
                                    aNV1 = (((npc.width) * -.1f));
                                }
                                Vector2 vector8 = new Vector2((npc.position.X + aNV1), npc.position.Y + (npc.height - 75));
                                float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-20, 0x15);
                                float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-20, 0x15);
                                if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
                                {
                                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 5);
                                    float num51 = (float)Math.Sqrt((double)((speedX * speedX) + (speedY * speedY)));
                                    num51 = num48 / num51;
                                    speedX *= num51;
                                    speedY *= num51;
                                    int damage = 80;
                                    int type = mod.ProjectileType("Ice3Ball");
                                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
                                    Main.projectile[num54].timeLeft = 100;
                                    Main.projectile[num54].aiStyle = -1;
                                    customAi1 = 1f;
                                }
                                npc.netUpdate = true;
                            }
                            if (Main.rand.Next(120) == 1)
                            {
                                float num48 = 8f;
                                float aNV1;
                                //int aNV2;
                                if (npc.direction > 0)
                                {
                                    aNV1 = (((npc.width) * 1.1f));
                                }
                                else
                                {
                                    aNV1 = (((npc.width) * -.1f));
                                }
                                Vector2 vector8 = new Vector2((npc.position.X + aNV1), npc.position.Y + (npc.height - 75));
                                float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-20, 0x15);
                                float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-20, 0x15);
                                if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
                                {
                                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 5);
                                    float num51 = (float)Math.Sqrt((double)((speedX * speedX) + (speedY * speedY)));
                                    num51 = num48 / num51;
                                    speedX *= num51;
                                    speedY *= num51;
                                    int damage = 40;
                                    if (Main.expertMode) { damage = 60; }
                                    int type = mod.ProjectileType("Lightning2Ball");
                                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
                                    Main.projectile[num54].timeLeft = 100;
                                    Main.projectile[num54].aiStyle = -1;
                                    customAi1 = 1f;
                                }
                                npc.netUpdate = true;
                            }
                            //if (Main.rand.Next(280) == 1)
                            //{
                            //    float num48 = 8f;
                            //    Vector2 vector8 = new Vector2((npc.position.X + ((((npc.width + 50) * 5f) * (npc.direction * 2)) / 20f) + 130), npc.position.Y + (npc.height / 2));
                            //    float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-20, 0x15);
                            //    float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-20, 0x15);
                            //    if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
                            //    {
                            //        Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 5);
                            //        float num51 = (float)Math.Sqrt((double)((speedX * speedX) + (speedY * speedY)));
                            //        num51 = num48 / num51;
                            //        speedX *= num51;
                            //        speedY *= num51;
                            //        int damage = 60;
                            //        if (Main.expertMode) { damage = 80; }
                            //        int type = mod.ProjectileType("OmnirsEnemySpellLightning3Ball");
                            //        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
                            //        Main.projectile[num54].timeLeft = 100;
                            //        Main.projectile[num54].aiStyle = -1;
                            //        customAi1 = 1f;
                            //    }
                            //    npc.netUpdate = true;
                            //}
                            if ((Main.rand.Next(1000) == 1) || (Main.rand.Next(800) == 1 && Main.expertMode))
                            {
                                float num48 = 8f;
                                float aNV1;
                                //int aNV2;
                                if (npc.direction > 0)
                                {
                                    aNV1 = (((npc.width) * 1.1f));
                                }
                                else
                                {
                                    aNV1 = (((npc.width) * -.1f));
                                }
                                Vector2 vector8 = new Vector2((npc.position.X + aNV1), npc.position.Y + (npc.height - 75));
                                float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-20, 0x15);
                                float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-20, 0x15);
                                if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
                                {
                                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 5);
                                    float num51 = (float)Math.Sqrt((double)((speedX * speedX) + (speedY * speedY)));
                                    num51 = num48 / num51;
                                    speedX *= num51;
                                    speedY *= num51;
                                    int damage = 10;
                                    int type = mod.ProjectileType("DoomBall");
                                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
                                    Main.projectile[num54].timeLeft = 100;
                                    Main.projectile[num54].aiStyle = -1;
                                    customAi1 = 1f;
                                }
                                npc.netUpdate = true;
                            }
                            if ((Main.rand.Next(400) == 1) || (Main.rand.Next(250) == 1 && Main.expertMode))
                            {
                                float num48 = 8f;
                                float aNV1;
                                //int aNV2;
                                if (npc.direction > 0)
                                {
                                    aNV1 = (((npc.width) * 1.1f));
                                }
                                else
                                {
                                    aNV1 = (((npc.width) * -.1f));
                                }
                                Vector2 vector8 = new Vector2((npc.position.X + aNV1), npc.position.Y + (npc.height - 75));
                                float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-20, 0x15);
                                float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-20, 0x15);
                                if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
                                {
                                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 5);
                                    float num51 = (float)Math.Sqrt((double)((speedX * speedX) + (speedY * speedY)));
                                    num51 = num48 / num51;
                                    speedX *= num51;
                                    speedY *= num51;
                                    int damage = 10;
                                    if (Main.expertMode) { damage = 20; }
                                    int type = mod.ProjectileType("HoldBall");
                                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
                                    Main.projectile[num54].timeLeft = 100;
                                    Main.projectile[num54].aiStyle = -1;
                                    customAi1 = 1f;
                                }
                                npc.netUpdate = true;
                            }
                        }
                        #region Charge
                        if (npc.velocity.Y == 0f && Main.rand.Next(550) == 1)
                        {
                            Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
                            float rotation = (float)Math.Atan2(vector8.Y - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), vector8.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                            npc.velocity.X = (float)(Math.Cos(rotation) * 7) * -1;
                            npc.velocity.Y = (float)(Math.Sin(rotation) * 7) * -1;
                            npc.ai[1] = 1f;
                            npc.netUpdate = true;
                        }
                        #endregion
                    }
                    #endregion
                }

            }

            if (npc.velocity.Y == 0f && Main.rand.Next(550) == 1)
            {
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
                float rotation = (float)Math.Atan2(vector8.Y - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), vector8.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                npc.velocity.X = (float)(Math.Cos(rotation) * 7) * -1;
                npc.velocity.Y = (float)(Math.Sin(rotation) * 7) * -1;
                npc.localAI[3] = 1f;
                npc.netUpdate = true;
            }
        }
        public override void NPCLoot()
        {
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/EarthFiendLichGore1"), 1.0f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/EarthFiendLichGore2"), 1.0f);
            
            
        }
    }
}
