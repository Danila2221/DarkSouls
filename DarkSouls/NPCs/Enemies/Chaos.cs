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
    public class Chaos : ModNPC
    {
        float customAi1;
        int OTimeLeft = 2000;
        bool walkAndShoot = true;
        int choasHealed = 0;
        float customspawn1 = 0;
        int chargeDamage = 0;
        bool chargeDamageFlag = false;

        bool canDrown = false;
        int drownTimerMax = 2000;
        int drownTimer = 2000;
        int drowningRisk = 1200;

        float npcAcSPD = 0.6f; //How fast they accelerate.
        float npcSPD = 1.8f; //Max speed

        float npcEnrAcSPD = 0.95f; //How fast they accelerate.
        float npcEnrSPD = 2.9f; //Max speed

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chaos");

            Main.npcFrameCount[npc.type] = 8;
        }
        public override void SetDefaults()
        {
            
            
            npc.width = 130;
            npc.height = 140;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath5;
            npc.npcSlots = 100;
            npc.scale = 1.2f;
            npc.aiStyle = -1;//22;
            npc.knockBackResist = 0.1f;
           
            animationType = -1;
            npc.lavaImmune = true;
            npc.buffImmune[BuffID.Venom] = true;
            npc.buffImmune[BuffID.Confused] = true;
            npc.buffImmune[BuffID.CursedInferno] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.boss = true;
            npc.damage = 150;
            npc.defense = 80;
            npc.lifeMax = 80000;
            npc.value = 700000f;
            music = MusicID.Boss3;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.3f);
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
        public override void AI()  //  Floater ai
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
            npc.noTileCollide = true;
            npc.noGravity = true;
            bool flag19 = false;
            ////if (npc.justHit)
            ////{
            ////    npc.ai[2] = 0f;
            ////}
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
            //if (npc.justHit)
            //{
            //    npc.ai[3] = 0f;
            //    npc.localAI[1] = 0f;
            //}
            float num287 = 7f;
            Vector2 vector33 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
            float num288 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector33.X;
            float num289 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector33.Y;
            float num290 = (float)Math.Sqrt((double)(num288 * num288 + num289 * num289));
            num290 = num287 / num290;
            num288 *= .03f; //num290;
            num289 *= .03f; //num290;
            int oDamage1 = 70;//damage
            int oType1 = mod.ProjectileType("Lightning4Ball");//type
            int oDamage2 = 70;//damage
            int oType2 = mod.ProjectileType("Ice4Ball");//type
            int oDamage3 = 70;//damage
            int oType3 = mod.ProjectileType("Fire4Ball");//type
            int oDamage4 = 60;//damage
            int oType4 = mod.ProjectileType("BlazeBall");//type
            int oDamage5 = 60;//damage
            int oType5 = mod.ProjectileType("FlareBall");//type
            int oDamage6 = 60;//damage
            int oType6 = mod.ProjectileType("FlareBall");//type
            int oDamage7 = 25;//damage
            int oType7 = mod.ProjectileType("FlareBall");//type
            int oDamage8 = 25;//damage
            int oType8 = mod.ProjectileType("FlareBall");//type
            if (Main.netMode != 1 && npc.ai[3] == 32f && !Main.player[npc.target].npcTypeNoAggro[npc.type])
            {
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
                    npc.netUpdate = true;
                }
                if (chargeDamage >= 50)
                {
                    chargeDamageFlag = false;
                    npc.damage = 50;
                    chargeDamage = 0;
                }
                int OChaosSpell = (Main.rand.Next(3));
                int OChaosSpell2 = (Main.rand.Next(4));
                if (OChaosSpell == 0)
                {
                    int num291 = oDamage1;//damage
                    int num292 = oType1;//type
                    Projectile.NewProjectile(vector33.X, vector33.Y, num288, num289, num292, num291, 0f, Main.myPlayer, 0f, 0f);
                }
                if (OChaosSpell == 1)
                {
                    int num291 = oDamage2;//damage
                    int num292 = oType2;//type
                    Projectile.NewProjectile(vector33.X, vector33.Y, num288, num289, num292, num291, 0f, Main.myPlayer, 0f, 0f);
                }
                if (OChaosSpell == 2)
                {
                    int num291 = oDamage3;//damage
                    int num292 = oType3;//type
                    Projectile.NewProjectile(vector33.X, vector33.Y, num288, num289, num292, num291, 0f, Main.myPlayer, 0f, 0f);
                }
                if (OChaosSpell2 == 0)
                {
                    int num291 = oDamage4;//damage
                    int num292 = oType4;//type
                    Projectile.NewProjectile(vector33.X, vector33.Y, num288, num289, num292, num291, 0f, Main.myPlayer, 0f, 0f);
                }
                if (OChaosSpell2 == 1)
                {
                    int num291 = oDamage5;//damage
                    int num292 = oType5;//type
                    Projectile.NewProjectile(vector33.X, vector33.Y, num288, num289, num292, num291, 0f, Main.myPlayer, 0f, 0f);
                }
                if (OChaosSpell2 == 2)
                {
                    int num291 = oDamage6;//damage
                    int num292 = oType6;//type
                    Projectile.NewProjectile(vector33.X, vector33.Y, num288, num289, num292, num291, 0f, Main.myPlayer, 0f, 0f);
                }
                if (OChaosSpell2 == 3)
                {
                    int num291 = oDamage7;//damage
                    int num292 = oType7;//type
                    Projectile.NewProjectile(vector33.X, vector33.Y, num288, num289, num292, num291, 0f, Main.myPlayer, 0f, 0f);
                }
                if (OChaosSpell2 == 4)
                {
                    int num291 = oDamage8;//damage
                    int num292 = oType8;//type
                    Projectile.NewProjectile(vector33.X, vector33.Y, num288, num289, num292, num291, 0f, Main.myPlayer, 0f, 0f);
                }
                if (npc.life <= 5000)
                {
                    if (choasHealed == 1)
                    {
                        if (Main.rand.Next(300) == 1)
                        {
                            npc.life += 40000;
                            if (npc.life > npc.lifeMax) npc.life = npc.lifeMax;
                            float num48 = 8f;
                            int num291 = 0;//damage
                            int num292 = mod.ProjectileType("Cure4Ball");//type
                            Projectile.NewProjectile(vector33.X, vector33.Y, num288, num289, num292, num291, 0f, Main.myPlayer, 0f, 0f);
                            choasHealed += 1;
                        }
                    }
                }
            }
            num286 = 8;
            if (npc.ai[3] > 0f)
            {
                npc.ai[3] += 1f;
                if (npc.ai[3] >= 64f)
                {
                    npc.ai[3] = 0f;
                }
            }
            if (Main.netMode != 1 && npc.ai[3] == 0f)
            {
                npc.localAI[1] += 1f;
                if (npc.localAI[1] > 120f && Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height) && !Main.player[npc.target].npcTypeNoAggro[npc.type])
                {
                    npc.localAI[1] = 0f;
                    npc.ai[3] = 1f;
                    npc.netUpdate = true;
                }
            }

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
                for (int num310 = num285; num310 < num285 + num286 - 2; num310 = num + 1)
                {
                    if (Main.tile[num284, num310] == null)
                    {
                        Main.tile[num284, num310] = new Tile();
                    }
                    if ((Main.tile[num284, num310].nactive() && Main.tileSolid[(int)Main.tile[num284, num310].type]) || Main.tile[num284, num310].liquid > 0)
                    {
                        flag25 = true;
                        break;
                    }
                    num = num310;
                }
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
                if (npc.velocity.Y > 6f)
                {
                    npc.velocity.Y = 6f;
                }

            }
            else
            {
                if (npc.directionY < 0 && npc.velocity.Y > 0f)
                {
                    npc.velocity.Y = npc.velocity.Y - 0.1f;
                }
                if (npc.velocity.Y < -7f)
                {
                    npc.velocity.Y = -7f;
                }
            }
            //if (npc.collideX)
            //{
            //    npc.velocity.X = npc.oldVelocity.X * -0.4f;
            //    if (npc.direction == -1 && npc.velocity.X > 0f && npc.velocity.X < 1f)
            //    {
            //        npc.velocity.X = 2f;
            //    }
            //    if (npc.direction == 1 && npc.velocity.X < 0f && npc.velocity.X > -1f)
            //    {
            //        npc.velocity.X = -2f;
            //    }
            //}
            //if (npc.collideY)
            //{
            //    npc.velocity.Y = npc.oldVelocity.Y * -0.25f;
            //    if (npc.velocity.Y > 0f && npc.velocity.Y < 1f)
            //    {
            //        npc.velocity.Y = 2f;
            //    }
            //    if (npc.velocity.Y < 0f && npc.velocity.Y > -1f)
            //    {
            //        npc.velocity.Y = -2f;
            //    }
            //}
            float num312 = 6f;
            if (npc.direction == -1)
            {
                npc.velocity.X = npc.velocity.X - 0.2f;
                if (npc.velocity.X > num312)
                {
                    npc.velocity.X = npc.velocity.X - 0.2f;
                }
                else if (npc.velocity.X > 0f)
                {
                    npc.velocity.X = npc.velocity.X + 0.05f;
                }
                if (npc.velocity.X < -num312)
                {
                    npc.velocity.X = -num312;
                }
            }
            else if (npc.direction == 1)
            {
                npc.velocity.X = npc.velocity.X + 0.2f;
                if (npc.velocity.X < -num312)
                {
                    npc.velocity.X = npc.velocity.X + 0.2f;
                }
                else if (npc.velocity.X < 0f)
                {
                    npc.velocity.X = npc.velocity.X - 0.05f;
                }
                if (npc.velocity.X > num312)
                {
                    npc.velocity.X = num312;
                }
            }
            num312 = 3f;
            if (npc.direction == -1)
            {
                npc.velocity.Y = npc.velocity.Y - 0.04f;
                if (npc.velocity.Y > num312)
                {
                    npc.velocity.Y = npc.velocity.Y - 0.05f;
                }
                else if (npc.velocity.Y > 0f)
                {
                    npc.velocity.Y = npc.velocity.Y + 0.03f;
                }
                if (npc.velocity.Y < -num312)
                {
                    npc.velocity.Y = -num312;
                }
            }
            else if (npc.direction == 1)
            {
                npc.velocity.Y = npc.velocity.Y + 0.04f;
                if (npc.velocity.Y < -num312)
                {
                    npc.velocity.Y = npc.velocity.Y + 0.05f;
                }
                else if (npc.velocity.Y < 0f)
                {
                    npc.velocity.Y = npc.velocity.Y - 0.03f;
                }
                if (npc.velocity.Y > num312)
                {
                    npc.velocity.Y = num312;
                }
            }

            Player player = Main.player[npc.target];
            //for (int m = npc.oldPos.Length - 1; m > 0; m--)
            //{
            //    npc.oldPos[m] = npc.oldPos[m - 1];
            //}
            //npc.oldPos[0] = npc.position;
            bool seeplayer = npc.ai[0] >= 200 || Collision.CanHit(npc.position, npc.width, npc.height, player.position, player.width, player.height);
            //public static void AIFlier(NPC npc, ref float[] ai, bool sporadic = true, float moveIntervalX = 0.1f, float moveIntervalY = 0.04f, float maxSpeedX = 4f, float maxSpeedY = 1.5f, bool canBeBored = true, int timeUntilBoredom = 300)
            //npc.rotation = npc.velocity.X * 0.08f;
            if (npc.life <= 0)
            {
                if (customspawn1 <= 0)
                {
                    int npcToSpawn = mod.NPCType("ChaosDeathAnimation");
                    int npcIndex = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, npcToSpawn, 0, 0f, 0f, 0f, 0f, 255);
                    Main.npc[npcIndex].whoAmI = npcIndex;
                    NetMessage.SendData(23, -1, -1, null, npcIndex, 0f, 0f, 0f, 0, 0, 0);
                    Main.npc[npcIndex].BigMimicSpawnSmoke();
                    npc.life = 0;
                }
            }
        }
        public override void NPCLoot()
        {
            if (npc.life <= 0)
            {
                if (customspawn1 <= 0)
                {
                    int npcToSpawn = mod.NPCType("ChaosDeathAnimation");
                    int npcIndex = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, npcToSpawn, 0, 0f, 0f, 0f, 0f, 255);
                    Main.npc[npcIndex].whoAmI = npcIndex;
                    NetMessage.SendData(23, -1, -1, null, npcIndex, 0f, 0f, 0f, 0, 0, 0);
                    Main.npc[npcIndex].BigMimicSpawnSmoke();
                    npc.life = 0;
                }
            }
            
        



        }
    }
}
