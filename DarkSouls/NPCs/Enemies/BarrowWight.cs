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
    public class BarrowWight : ModNPC
    {

        float customAi1;
        float customspawn1;
        int OTimeLeft = 2000;
        bool flag25 = true;
        bool walkAndShoot = true;

        bool canDrown = false;
        int drownTimerMax = 200;
        int drownTimer = 200;
        int drowningRisk = 200;

        float npcAcSPD = 0.09f; //How fast they accelerate.
        float npcSPD = 2f; //Max speed

        float npcEnrAcSPD = 0.95f; //How fast they accelerate.
        float npcEnrSPD = 2.0f; //Max speed

        bool tooBig = false;
        bool lavaJumping = false;
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Barrow Wight");
            Main.npcFrameCount[npc.type] = 4;
        }
        public override void SetDefaults()
		{

			npc.lifeMax = 120;
			npc.damage = 25;
			npc.defense = 35;
			npc.knockBackResist = 0.1f;
			npc.width = 58;
			npc.height = 48;
			npc.aiStyle = -1;
			npc.noGravity = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
			npc.value = 1500f;
			animationType = -1;
			//banner = npc.type;
			//bannerItem = mod.ItemType("");
		}
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
            int y = spawnInfo.spawnTileY;
            int tile = Main.tile[x, y].type;
            return (DarkSouls.NoZoneAllowWater(spawnInfo)) && Main.hardMode && y >= Main.rockLayer ? 0.1f : 0f;
        }

        public override void AI()
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
            npc.noGravity = true;
            npc.noTileCollide = true;

            npc.ai[1] += (Main.rand.Next(2, 5) * 0.1f) * npc.scale;
            if (npc.ai[1] >= 10f)
            {
                npc.TargetClosest(true);
            }
            if (npc.justHit)
            {
                npc.ai[2] = 0f;
            }
            if (npc.ai[2] >= 0f)
            {
                int num258 = 16;
                bool flag26 = false;
                bool flag27 = false;
                if (npc.position.X > npc.ai[0] - (float)num258 && npc.position.X < npc.ai[0] + (float)num258)
                {
                    flag26 = true;
                }
                else
                {
                    if ((npc.velocity.X < 0f && npc.direction > 0) || (npc.velocity.X > 0f && npc.direction < 0))
                    {
                        flag26 = true;
                    }
                }
                num258 += 24;
                if (npc.position.Y > npc.ai[1] - (float)num258 && npc.position.Y < npc.ai[1] + (float)num258)
                {
                    flag27 = true;
                }
                if (flag26 && flag27)
                {
                    npc.ai[2] += 1f;
                    if (npc.ai[2] >= 30f && num258 == 16)
                    {
                        flag25 = true;
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
            int num259 = (int)((npc.position.X + (float)(npc.width / 2)) / 16f) + npc.direction * 2;
            int num260 = (int)((npc.position.Y + (float)npc.height) / 16f);
            if (npc.position.Y > Main.player[npc.target].position.Y)
            {
                npc.velocity.Y -= .05f;
            }
            if (npc.position.Y < Main.player[npc.target].position.Y)
            {
                npc.velocity.Y += .05f;
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
            float num270 = .5f;
            if (npc.direction == -1 && npc.velocity.X > -num270)
            {
                npc.velocity.X = npc.velocity.X - 0.1f;
                if (npc.velocity.X > num270)
                {
                    npc.velocity.X = npc.velocity.X - 0.1f;
                }
                else
                {
                    if (npc.velocity.X > 0f)
                    {
                        npc.velocity.X = npc.velocity.X + 0.05f;
                    }
                }
                if (npc.velocity.X < -num270)
                {
                    npc.velocity.X = -num270;
                }
            }
            else
            {
                if (npc.direction == 1 && npc.velocity.X < num270)
                {
                    npc.velocity.X = npc.velocity.X + 0.1f;
                    if (npc.velocity.X < -num270)
                    {
                        npc.velocity.X = npc.velocity.X + 0.1f;
                    }
                    else
                    {
                        if (npc.velocity.X < 0f)
                        {
                            npc.velocity.X = npc.velocity.X - 0.05f;
                        }
                    }
                    if (npc.velocity.X > num270)
                    {
                        npc.velocity.X = num270;
                    }
                }
            }
            if (npc.directionY == -1 && (double)npc.velocity.Y > -2.5)
            {
                npc.velocity.Y = npc.velocity.Y - 0.04f;
                if ((double)npc.velocity.Y > 2.5)
                {
                    npc.velocity.Y = npc.velocity.Y - 0.05f;
                }
                else
                {
                    if (npc.velocity.Y > 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y + 0.03f;
                    }
                }
                if ((double)npc.velocity.Y < -2.5)
                {
                    npc.velocity.Y = -2.5f;
                }
            }
            else
            {
                if (npc.directionY == 1 && (double)npc.velocity.Y < 2.5)
                {
                    npc.velocity.Y = npc.velocity.Y + 0.04f;
                    if ((double)npc.velocity.Y < -2.5)
                    {
                        npc.velocity.Y = npc.velocity.Y + 0.05f;
                    }
                    else
                    {
                        if (npc.velocity.Y < 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y - 0.03f;
                        }
                    }
                    if ((double)npc.velocity.Y > 2.5)
                    {
                        npc.velocity.Y = 2.5f;
                    }
                }
            }
        }

        public override void NPCLoot()
        {
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BarrowWightGore1"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BarrowWightGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BarrowWightGore2"), 1f);
            if (Main.netMode != 1)
            {
            if (Main.rand.Next(5) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BarrowBlade"));
            }
            if (Main.rand.Next(10) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GreaterHealingPotion);
            }
            if (Main.rand.Next(20) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ManaPotion);
            }
            if (Main.rand.Next(20) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RegenerationPotion);
            }
            if (Main.rand.Next(10) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ShinePotion);
            }
            if (Main.rand.Next(20) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SpelunkerPotion);
            }



            }

        }
    }
}