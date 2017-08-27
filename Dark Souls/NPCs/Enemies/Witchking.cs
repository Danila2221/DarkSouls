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
    public class Witchking : ModNPC
    {

        float customAi1;
        float customspawn1;
        float customspawn2;
        int chargeDamage = 0;
        bool chargeDamageFlag = false;

        int OTimeLeft = 2000;
        int movedTowards = 0;
        int num94 = 0;
        int num95 = 0;
        int noJump = 0;
        bool walkAndShoot = true;

        bool canDrown = true;
        int drownTimerMax = 20000;
        int drownTimer = 20000;
        int drowningRisk = 20000;

        float npcAcSPD = 0.5f; //How fast they accelerate.
        float npcSPD = 2.0f; //Max speed

        float npcEnrAcSPD = 0.95f; //How fast they accelerate.
        float npcEnrSPD = 2.0f; //Max speed

        bool tooBig = true;
        bool lavaJumping = true;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Witchking");
            Main.npcFrameCount[npc.type] = 16;
        }
        
        public override void SetDefaults()
		{

			npc.lifeMax = 20000;
			npc.damage = 100;
			npc.defense = 3000;
			npc.knockBackResist = 0.1f;
			npc.width = 30;
			npc.height = 45;
			npc.aiStyle = -1;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath6;

			npc.value = 0f;
			animationType = 28;
			npc.scale = 1.1f;
			npc.boss = true;
			banner = npc.type;
			bannerItem = mod.ItemType("");
		}

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
            int y = spawnInfo.spawnTileY;
            int tile = Main.tile[x, y].type;
            return (DarkSouls.NoZoneAllowWater(spawnInfo)) && Main.hardMode && y < Main.rockLayer ? 0.001f : 0f;
        }

        public void teleport(bool pre)
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
        public override void AI()  //  warrior ai
        {
            bool enraged = (npc.life < (float)npc.lifeMax * .2f);  //  speed up at low life
            int shotRate = enraged ? 100 : 70;
            float accel = enraged ? npcEnrAcSPD : npcAcSPD;  //  how fast it can speed up
            float topSpeed = enraged ? npcEnrSPD : npcSPD;  //  max walking speed, also affects jump length
            
            Vector2 angle = Main.player[npc.target].Center - npc.Center;
            angle.Y = angle.Y - (Math.Abs(angle.X) * .1f);
            angle.X += (float)Main.rand.Next(-20, 21);
            angle.Y += (float)Main.rand.Next(-20, 21);
            angle.Normalize();
            float distance = npc.Distance(Main.player[npc.target].Center);
            #region shoot and walk
            if (Main.netMode != 1)
            {
                if (npc.justHit)
                    npc.ai[2] = 0f; // reset throw countdown when hit
                if (Main.rand.Next(200) == 1)
                {
                    chargeDamageFlag = true;
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
                    float rotation = (float)Math.Atan2(vector8.Y - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), vector8.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                    npc.velocity.X = (float)(Math.Cos(rotation) * 14) * -1;
                    npc.velocity.Y = (float)(Math.Sin(rotation) * 14) * -1;
                    npc.ai[1] = 1f;
                    npc.netUpdate = true;
                }
                if (chargeDamageFlag == true)
                {
                    npc.damage = 220;
                    chargeDamage++;
                }
                if (chargeDamage >= 50)
                {
                    chargeDamageFlag = false;
                    npc.damage = 50;
                    chargeDamage = 0;
                }
                #region Projectiles
                customAi1 += (Main.rand.Next(2, 5) * 0.1f) * npc.scale;
                if (customAi1 >= 10f)
                {
                    npc.TargetClosest(true);
                    if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
                    {
                        if ((Main.rand.Next(500) == 1) || (Main.rand.Next(300) == 1 && Main.expertMode))
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
                                int damage = 110;
                                int type = mod.ProjectileType("BlackBreath");
                                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
                                Main.projectile[num54].timeLeft = 50;
                                Main.projectile[num54].aiStyle = -1;
                                customAi1 = 1f;
                            }
                            npc.netUpdate = true;
                        }
                        if ((Main.rand.Next(300) == 1) || (Main.rand.Next(150) == 1 && Main.expertMode))
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
                                Main.projectile[num54].timeLeft = 1;
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
            #endregion
            if (npc.velocity.Y == 0f && Main.rand.Next(550) == 1)
            {
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
                float rotation = (float)Math.Atan2(vector8.Y - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), vector8.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                npc.velocity.X = (float)(Math.Cos(rotation) * 7) * -1;
                npc.velocity.Y = (float)(Math.Sin(rotation) * 7) * -1;
                npc.localAI[3] = 1f;
                npc.netUpdate = true;
            }
            #region Too Big and Lava Jumping
            if (tooBig)
            {
                if (npc.velocity.Y == 0f && (npc.velocity.X == 0f && npc.direction < 0))
                {
                    npc.velocity.Y -= 8f;
                    npc.velocity.X -= npcSPD;
                }
                else if (npc.velocity.Y == 0f && (npc.velocity.X == 0f && npc.direction > 0))
                {
                    npc.velocity.Y -= 8f;
                    npc.velocity.X += npcSPD;
                }
            }
            if (lavaJumping)
            {
                if (npc.lavaWet)
                {
                    npc.velocity.Y -= 2;
                }
            }
            #endregion
        }

        public override void NPCLoot()
        {
            
            
            Color color = new Color();
            Rectangle rectangle = new Rectangle((int)npc.position.X, (int)(npc.position.Y + ((npc.height - npc.width) / 2)), npc.width, npc.width);//npc.frame;
            int count = 50;
            float vectorReduce = .4f;
            for (int i = 1; i <= count; i++)
            {
                //int dust = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 6, (npc.velocity.X * 0.2f) + (npc.direction * 3), npc.velocity.Y * 0.2f, 100, color, 1.9f);
                int dust = Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 5, 0, 0, 100, color, 1.8f);
                Main.dust[dust].noGravity = false;
                Main.dust[dust].velocity.X = vectorReduce * (Main.dust[dust].position.X - (npc.position.X + (npc.width / 2)));
                Main.dust[dust].velocity.Y = vectorReduce * (Main.dust[dust].position.Y - (npc.position.Y + (npc.height / 2)));
            }
            int wLoot = (Main.rand.Next(3));
            if (Main.netMode != 1)
            {
            if (wLoot == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WitchkingHelmet"));
            }
            if (wLoot == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WitchkingTop"));
            }
            if (wLoot == 2)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WitchkingBottoms"));
            }
            if (Main.rand.Next(10) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MenRingofPower"));
            }
            if (Main.rand.Next(12) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GreatMagicRing"));
            }
        
        }
        }
    }
}