using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace DarkSouls
{
    class DarkSouls : Mod
    {
        
        
        public override void PostSetupContent()
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if(bossChecklist != null)
            {
                // AddBoss, bossname, order or value in terms of vanilla bosses, inline method for retrieving downed value.
                bossChecklist.Call("AddBoss", "Abysmal Oolacile Sorcerer", 7f, (Func<bool>)(() => DarkSoulsWorld.downedSorcerer));
                bossChecklist.Call("AddBoss", "Attraidies", 5.5f, (Func<bool>)(() => DarkSoulsWorld.downedAttraidies));
                //bossChecklist.Call(....
                // To include a description:
                
            }
        }



        public int iexp = 0;
        public int ilevel = 0;
        public int itnl = 0;
        public string oritemname = "";
        public int oridamage = 0;
        public int oricrit = 0;

       



        public static bool NoZoneAllowWater(NPCSpawnInfo spawnInfo)
        {
            return !spawnInfo.sky && !spawnInfo.player.ZoneMeteor && !spawnInfo.spiderCave;
        }
        public static void AIWorm(NPC npc, int headType, int[] bodyTypes, int tailType, int wormLength = 3, float partDistanceAddon = 0f, float maxSpeed = 8f, float gravityResist = 0.07f, bool fly = false, bool split = false, bool ignoreTiles = false, bool spawnTileDust = true, bool soundEffects = true)
        {
            if (split)
            {
                npc.realLife = -1;
            }
            else
            if (npc.ai[3] > 0f) { npc.realLife = (int)npc.ai[3]; }

            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead) { npc.TargetClosest(true); }
            if (Main.player[npc.target].dead && npc.timeLeft > 300) { npc.timeLeft = 300; }
            if (Main.netMode != 1)
            {
                //spawn pieces (flying)
                if (fly && npc.type == headType && npc.ai[0] == 0f)
                {
                    npc.ai[3] = (float)npc.whoAmI;
                    npc.realLife = npc.whoAmI;
                    int npcID = npc.whoAmI;

                    for (int m = 0; m < wormLength - 1; m++)
                    {
                        int npcType = (m == wormLength - 2 ? tailType : bodyTypes[m]);

                        int newnpcID = NPC.NewNPC((int)(npc.Center.X), (int)(npc.Center.Y), npcType, npc.whoAmI);
                        Main.npc[newnpcID].ai[3] = (float)npc.whoAmI;
                        Main.npc[newnpcID].realLife = npc.whoAmI;
                        Main.npc[newnpcID].ai[1] = (float)npcID;
                        Main.npc[npcID].ai[0] = (float)newnpcID;
                        NetMessage.SendData(23, -1, -1, null, newnpcID, 0f, 0f, 0f, 0);
                        npcID = newnpcID;
                    }
                    npc.netUpdate = true;
                }
                else //spawn pieces
                if ((npc.type == headType || (npc.type != headType && npc.type != tailType)) && npc.ai[0] == 0f)
                {
                    if (npc.type == headType)
                    {
                        if (!split)
                        {
                            npc.ai[3] = (float)npc.whoAmI;
                            npc.realLife = npc.whoAmI;
                        }
                        npc.ai[2] = (float)(wormLength - 2);
                        int nextPiece = (bodyTypes.Length == 0 ? tailType : bodyTypes[0]);
                        npc.ai[0] = (float)NPC.NewNPC((int)(npc.Center.X), (int)(npc.Center.Y), nextPiece, npc.whoAmI);
                    }
                    else
                    if ((npc.type != headType && npc.type != tailType) && npc.ai[2] > 0f)
                    {
                        npc.ai[0] = (float)NPC.NewNPC((int)(npc.Center.X), (int)(npc.Center.Y), bodyTypes[wormLength - 3 - (int)npc.ai[2]], npc.whoAmI);
                    }
                    else
                    {
                        npc.ai[0] = (float)NPC.NewNPC((int)(npc.Center.X), (int)(npc.Center.Y), tailType, npc.whoAmI);
                    }
                    if (!split)
                    {
                        Main.npc[(int)npc.ai[0]].ai[3] = npc.ai[3];
                        Main.npc[(int)npc.ai[0]].realLife = npc.realLife;
                    }
                    Main.npc[(int)npc.ai[0]].ai[1] = (float)npc.whoAmI;
                    Main.npc[(int)npc.ai[0]].ai[2] = npc.ai[2] - 1f;
                    npc.netUpdate = true;
                }
                //if npc can split, check if pieces are dead and if so split.
                if (split)
                {
                    if (!Main.npc[(int)npc.ai[1]].active && !Main.npc[(int)npc.ai[0]].active)
                    {
                        npc.life = 0;
                        npc.HitEffect(0, 10.0);
                        npc.active = false;
                    }
                    if (npc.type == headType && !Main.npc[(int)npc.ai[0]].active)
                    {
                        npc.life = 0;
                        npc.HitEffect(0, 10.0);
                        npc.active = false;
                    }
                    if (npc.type == tailType && !Main.npc[(int)npc.ai[1]].active)
                    {
                        npc.life = 0;
                        npc.HitEffect(0, 10.0);
                        npc.active = false;
                    }
                    if ((npc.type != headType && npc.type != tailType) && !Main.npc[(int)npc.ai[1]].active)
                    {
                        npc.type = headType;
                        int npcID = npc.whoAmI;
                        float lifePercent = (float)npc.life / (float)npc.lifeMax;
                        float lastPiece = npc.ai[0];
                        npc.SetDefaults(npc.type, -1f);
                        npc.life = (int)((float)npc.lifeMax * lifePercent);
                        npc.ai[0] = lastPiece;
                        npc.TargetClosest(true);
                        npc.netUpdate = true;
                        npc.whoAmI = npcID;
                    }
                    else
                    if ((npc.type != headType && npc.type != tailType) && !Main.npc[(int)npc.ai[0]].active)
                    {
                        npc.type = tailType;
                        int npcID = npc.whoAmI;
                        float lifePercent = (float)npc.life / (float)npc.lifeMax;
                        float lastPiece = npc.ai[1];
                        npc.SetDefaults(npc.type, -1f);
                        npc.life = (int)((float)npc.lifeMax * lifePercent);
                        npc.ai[1] = lastPiece;
                        npc.TargetClosest(true);
                        npc.netUpdate = true;
                        npc.whoAmI = npcID;
                    }
                }
                else
                {
                    if (npc.type != headType && (!Main.npc[(int)npc.ai[1]].active || Main.npc[(int)npc.ai[1]].aiStyle != npc.aiStyle))
                    {
                        npc.life = 0;
                        npc.HitEffect(0, 10.0);

                        npc.active = false;
                    }
                    if (npc.type != tailType && (!Main.npc[(int)npc.ai[0]].active || Main.npc[(int)npc.ai[0]].aiStyle != npc.aiStyle))
                    {
                        npc.life = 0;
                        npc.HitEffect(0, 10.0);

                        npc.active = false;
                    }
                }
                if (!npc.active && Main.netMode == 2) { NetMessage.SendData(28, -1, -1, null, npc.whoAmI, 1, 0f, 0f, -1); }
            }
            int tileX = (int)(npc.position.X / 16f) - 1;
            int tileCenterX = (int)((npc.Center.X) / 16f) + 2;
            int tileY = (int)(npc.position.Y / 16f) - 1;
            int tileCenterY = (int)((npc.Center.Y) / 16f) + 2;
            if (tileX < 0) { tileX = 0; }
            if (tileCenterX > Main.maxTilesX) { tileCenterX = Main.maxTilesX; }
            if (tileY < 0) { tileY = 0; }
            if (tileCenterY > Main.maxTilesY) { tileCenterY = Main.maxTilesY; }
            bool canMove = false;
            if (fly || ignoreTiles) { canMove = true; }
            if (!canMove || spawnTileDust)
            {
                for (int tX = tileX; tX < tileCenterX; tX++)
                {
                    for (int tY = tileY; tY < tileCenterY; tY++)
                    {
                        if (Main.tile[tX, tY] != null && (((Main.tileSolidTop[Main.tile[tX, tY].type] && Main.tile[tX, tY].frameY == 0)) || Main.tile[tX, tY].liquid > 64))
                        {
                            Vector2 tPos;
                            tPos.X = (float)(tX * 16);
                            tPos.Y = (float)(tY * 16);
                            if (npc.position.X + (float)npc.width > tPos.X && npc.position.X < tPos.X + 16f && npc.position.Y + (float)npc.height > tPos.Y && npc.position.Y < tPos.Y + 16f)
                            {
                                canMove = true;
                                if (spawnTileDust && Main.rand.Next(100) == 0)
                                {
                                    WorldGen.KillTile(tX, tY, true, true, false);
                                }
                            }
                        }
                    }
                }
            }
            if (!canMove && npc.type == headType)
            {
                Rectangle rectangle = new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height);
                int playerCheckDistance = 1000;
                bool canMove2 = true;
                for (int m3 = 0; m3 < 255; m3++)
                {
                    if (Main.player[m3].active)
                    {
                        Rectangle rectangle2 = new Rectangle((int)Main.player[m3].position.X - playerCheckDistance, (int)Main.player[m3].position.Y - playerCheckDistance, playerCheckDistance * 2, playerCheckDistance * 2);
                        if (rectangle.Intersects(rectangle2))
                        {
                            canMove2 = false;
                            break;
                        }
                    }
                }
                if (canMove2) { canMove = true; }
            }
            if (fly)
            {
                if (npc.velocity.X < 0f) { npc.spriteDirection = 1; }
                else
                if (npc.velocity.X > 0f) { npc.spriteDirection = -1; }

            }


            Vector2 npcCenter = npc.Center;
            float playerCenterX = Main.player[npc.target].Center.X;
            float playerCenterY = Main.player[npc.target].Center.Y;
            playerCenterX = (float)((int)(playerCenterX / 16f) * 16); playerCenterY = (float)((int)(playerCenterY / 16f) * 16);
            npcCenter.X = (float)((int)(npcCenter.X / 16f) * 16); npcCenter.Y = (float)((int)(npcCenter.Y / 16f) * 16);
            playerCenterX -= npcCenter.X; playerCenterY -= npcCenter.Y;
            float dist = (float)Math.Sqrt((double)(playerCenterX * playerCenterX + playerCenterY * playerCenterY));
            if (npc.ai[1] > 0f && npc.ai[1] < (float)Main.npc.Length)
            {
                try
                {
                    npcCenter = npc.Center;
                    playerCenterX = Main.npc[(int)npc.ai[1]].Center.X - npcCenter.X;
                    playerCenterY = Main.npc[(int)npc.ai[1]].Center.Y - npcCenter.Y;
                }
                catch
                {
                }
                npc.rotation = (float)Math.Atan2((double)playerCenterY, (double)playerCenterX) + 1.57f;
                dist = (float)Math.Sqrt((double)(playerCenterX * playerCenterX + playerCenterY * playerCenterY));
                dist = (dist - (float)npc.width - (float)partDistanceAddon) / dist;
                playerCenterX *= dist;
                playerCenterY *= dist;
                npc.velocity = default(Vector2);
                npc.position.X = npc.position.X + playerCenterX;
                npc.position.Y = npc.position.Y + playerCenterY;
                if (fly)
                {
                    if (playerCenterX < 0f) { npc.spriteDirection = 1; return; } //comment these two lines out to make dargon not flip
                    if (playerCenterX > 0f) { npc.spriteDirection = -1; return; } //
                }
            }
            else
            {
                if (!canMove)
                {
                    npc.TargetClosest(true);
                    npc.velocity.Y = npc.velocity.Y + 0.11f;
                    if (npc.velocity.Y > maxSpeed) { npc.velocity.Y = maxSpeed; }
                    if ((double)(Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y)) < (double)maxSpeed * 0.4)
                    {
                        if (npc.velocity.X < 0f) { npc.velocity.X = npc.velocity.X - gravityResist * 1.1f; } else { npc.velocity.X = npc.velocity.X + gravityResist * 1.1f; }
                    }
                    else
                    if (npc.velocity.Y == maxSpeed)
                    {
                        if (npc.velocity.X < playerCenterX) { npc.velocity.X = npc.velocity.X + gravityResist; }
                        else
                        if (npc.velocity.X > playerCenterX) { npc.velocity.X = npc.velocity.X - gravityResist; }
                    }
                    else
                    if (npc.velocity.Y > 4f)
                    {
                        if (npc.velocity.X < 0f) { npc.velocity.X = npc.velocity.X + gravityResist * 0.9f; } else { npc.velocity.X = npc.velocity.X - gravityResist * 0.9f; }
                    }
                }
                else
                {
                    if (soundEffects && npc.soundDelay == 0)
                    {
                        float distSoundDelay = dist / 40f;
                        if (distSoundDelay < 10f) { distSoundDelay = 10f; }
                        if (distSoundDelay > 20f) { distSoundDelay = 20f; }
                        npc.soundDelay = (int)distSoundDelay;
                        Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 1);
                    }
                    dist = (float)Math.Sqrt((double)(playerCenterX * playerCenterX + playerCenterY * playerCenterY));
                    float absPlayerCenterX = Math.Abs(playerCenterX);
                    float absPlayerCenterY = Math.Abs(playerCenterY);
                    float newSpeed = maxSpeed / dist;
                    playerCenterX *= newSpeed;
                    playerCenterY *= newSpeed;
                    bool dontFall = false;
                    if (fly)
                    {
                        if (((npc.velocity.X > 0f && playerCenterX < 0f) || (npc.velocity.X < 0f && playerCenterX > 0f) || (npc.velocity.Y > 0f && playerCenterY < 0f) || (npc.velocity.Y < 0f && playerCenterY > 0f)) && Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) > gravityResist / 2f && dist < 300f)
                        {
                            dontFall = true;
                            if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < maxSpeed) { npc.velocity *= 1.1f; }
                        }
                        //if (npc.position.Y > Main.player[npc.target].position.Y || (double)(Main.player[npc.target].position.Y / 16f) > Main.worldSurface || Main.player[npc.target].dead) //part jungle wyvern needs 
                        if (Main.player[npc.target].dead) //part jungle wyvern needs 
                        {
                            dontFall = true;
                            if (Math.Abs(npc.velocity.X) < maxSpeed / 2f)
                            {
                                if (npc.velocity.X == 0f) { npc.velocity.X = npc.velocity.X - (float)npc.direction; }
                                npc.velocity.X = npc.velocity.X * 1.1f;
                            }
                            else
                            if (npc.velocity.Y > -maxSpeed) { npc.velocity.Y = npc.velocity.Y - gravityResist; }
                        }
                    }
                    if (!dontFall)
                    {
                        if ((npc.velocity.X > 0f && playerCenterX > 0f) || (npc.velocity.X < 0f && playerCenterX < 0f) || (npc.velocity.Y > 0f && playerCenterY > 0f) || (npc.velocity.Y < 0f && playerCenterY < 0f))
                        {
                            if (npc.velocity.X < playerCenterX) { npc.velocity.X = npc.velocity.X + gravityResist; }
                            else
                            if (npc.velocity.X > playerCenterX) { npc.velocity.X = npc.velocity.X - gravityResist; }
                            if (npc.velocity.Y < playerCenterY) { npc.velocity.Y = npc.velocity.Y + gravityResist; }
                            else
                            if (npc.velocity.Y > playerCenterY) { npc.velocity.Y = npc.velocity.Y - gravityResist; }
                            if ((double)Math.Abs(playerCenterY) < (double)maxSpeed * 0.2 && ((npc.velocity.X > 0f && playerCenterX < 0f) || (npc.velocity.X < 0f && playerCenterX > 0f)))
                            {
                                if (npc.velocity.Y > 0f) { npc.velocity.Y = npc.velocity.Y + gravityResist * 2f; } else { npc.velocity.Y = npc.velocity.Y - gravityResist * 2f; }
                            }
                            if ((double)Math.Abs(playerCenterX) < (double)maxSpeed * 0.2 && ((npc.velocity.Y > 0f && playerCenterY < 0f) || (npc.velocity.Y < 0f && playerCenterY > 0f)))
                            {
                                if (npc.velocity.X > 0f) { npc.velocity.X = npc.velocity.X + gravityResist * 2f; } else { npc.velocity.X = npc.velocity.X - gravityResist * 2f; }
                            }
                        }
                        else
                        if (absPlayerCenterX > absPlayerCenterY)
                        {
                            if (npc.velocity.X < playerCenterX) { npc.velocity.X = npc.velocity.X + gravityResist * 1.1f; }
                            else
                            if (npc.velocity.X > playerCenterX) { npc.velocity.X = npc.velocity.X - gravityResist * 1.1f; }

                            if ((double)(Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y)) < (double)maxSpeed * 0.5)
                            {
                                if (npc.velocity.Y > 0f) { npc.velocity.Y = npc.velocity.Y + gravityResist; } else { npc.velocity.Y = npc.velocity.Y - gravityResist; }
                            }
                        }
                        else
                        {
                            if (npc.velocity.Y < playerCenterY) { npc.velocity.Y = npc.velocity.Y + gravityResist * 1.1f; }
                            else
                            if (npc.velocity.Y > playerCenterY) { npc.velocity.Y = npc.velocity.Y - gravityResist * 1.1f; }
                            if ((double)(Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y)) < (double)maxSpeed * 0.5)
                            {
                                if (npc.velocity.X > 0f) { npc.velocity.X = npc.velocity.X + gravityResist; } else { npc.velocity.X = npc.velocity.X - gravityResist; }
                            }
                        }
                    }
                }
                npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) + 1.57f;
                if (npc.type == headType)
                {
                    if (canMove)
                    {
                        if (npc.localAI[0] != 1f) { npc.netUpdate = true; }
                        npc.localAI[0] = 1f;
                    }
                    else
                    {
                        if (npc.localAI[0] != 0f) { npc.netUpdate = true; }
                        npc.localAI[0] = 0f;
                    }
                    if (((npc.velocity.X > 0f && npc.oldVelocity.X < 0f) || (npc.velocity.X < 0f && npc.oldVelocity.X > 0f) || (npc.velocity.Y > 0f && npc.oldVelocity.Y < 0f) || (npc.velocity.Y < 0f && npc.oldVelocity.Y > 0f)) && !npc.justHit)
                    {
                        npc.netUpdate = true;
                        return;
                    }
                }
            }
        }












        public DarkSouls()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }
    }
}
