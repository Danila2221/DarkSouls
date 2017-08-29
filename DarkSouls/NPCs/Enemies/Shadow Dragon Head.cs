using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.NPCs.Enemies
{
	public class ShadowDragonHead : ModNPC
	{
				int breathCD = 90;
//int previous = 0;
bool breath = false;
		public bool JustSpawned
		{
			get { return npc.localAI[0] == 0f; }
			set { npc.localAI[0] = value ? 0f : 1f; }
		}


		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadow Dragon");
			Main.npcFrameCount[npc.type] = 1;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 16000;
			npc.damage = 90;
			npc.defense = 19;
			npc.knockBackResist = 0f;
			npc.width = 44;
			npc.height = 24;
			npc.noTileCollide = true ;
			animationType = 87;﻿
			npc.scale = 1f;
			npc.boss = true;
			npc.aiStyle = 6;
			npc.npcSlots = 1f;
			npc.HitSound = SoundID.NPCHit7;
			npc.noGravity = true;
			npc.DeathSound = SoundID.NPCDeath8;
			npc.netAlways = true;
			npc.active = true;
			npc.npcSlots = 1;
    		npc.behindTiles = true;
            npc.timeLeft = 22750;
        }

		public int basicsoul;
		static int count;
        private float customAi1;

        public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			
		}
		
		public override void AI()
{
            
            
            Player nT = Main.player[npc.target];
    if (Main.rand.Next(275) == 0) {
        breath = true;
        //Main.PlaySound(15, -1, -1, 0);
    }
    if (breath) {
        //while (breathCD > 0) {
        //for (int pcy = 0; pcy < 10; pcy++) {
            Projectile.NewProjectile(npc.position.X + (float)npc.width / 2f, npc.position.Y + (float)npc.height / 2f, npc.velocity.X * 3f + (float)Main.rand.Next(-2, 3), npc.velocity.Y * 3f + (float)Main.rand.Next(-2, 3), mod.ProjectileType("DragonBreath"), 65, 1.2f, 255);
        	
        //}
		npc.netUpdate = true; //new
        breathCD--;
        //}
    }
    if (breathCD <= 0) {
        breath = false;
        breathCD = 90;
        Main.PlaySound(2, -1, -1, 20);
    }
    npc.TargetClosest(true);
    
    SegmentBody();
    if (npc.velocity.X < 0f){ npc.spriteDirection = 1; } else  //both -1 is correct
	if (npc.velocity.X > 0f){ npc.spriteDirection = -1; }

									
					

if (!Main.npc[(int)npc.ai[1]].active)
	{
		npc.life = 0;
		npc.HitEffect(0, 10.0);
		NPCLoot();
		npc.active = false;
	}
            float num115 = 16f;
            float num116 = 0.4f;

            Vector2 vector14 = new Vector2(this.npc.position.X + (float)this.npc.width * 0.5f, this.npc.position.Y + (float)this.npc.height * 0.5f);
            float num118 = Main.rand.Next(-500, 500) + Main.player[this.npc.target].position.X + (float)(Main.player[this.npc.target].width / 2);
            float num119 = Main.rand.Next(-500, 500) + Main.player[this.npc.target].position.Y + (float)(Main.player[this.npc.target].height / 2);
            num118 = (float)((int)(num118 / 16f) * 16);
            num119 = (float)((int)(num119 / 16f) * 16);
            vector14.X = (float)((int)(vector14.X / 16f) * 16);
            vector14.Y = (float)((int)(vector14.Y / 16f) * 16);
            num118 -= vector14.X;
            num119 -= vector14.Y;
            float num120 = (float)Math.Sqrt((double)(num118 * num118 + num119 * num119));

            float num123 = Math.Abs(num118);
            float num124 = Math.Abs(num119);
            float num125 = num115 / num120;
            num118 *= num125;
            num119 *= num125;

            bool flag14 = false;
            if (((this.npc.velocity.X > 0f && num118 < 0f) || (this.npc.velocity.X < 0f && num118 > 0f) || (this.npc.velocity.Y > 0f && num119 < 0f) || (this.npc.velocity.Y < 0f && num119 > 0f)) && Math.Abs(this.npc.velocity.X) + Math.Abs(this.npc.velocity.Y) > num116 / 2f && num120 < 300f)
            {
                flag14 = true;
                if (Math.Abs(this.npc.velocity.X) + Math.Abs(this.npc.velocity.Y) < num115)
                {
                    this.npc.velocity *= 1.1f;
                }
            }
            if (this.npc.position.Y > Main.player[this.npc.target].position.Y || (double)(Main.player[this.npc.target].position.Y / 16f) > Main.worldSurface || Main.player[this.npc.target].dead)
            {
                flag14 = true;
                if (Math.Abs(this.npc.velocity.X) < num115 / 2f)
                {
                    if (this.npc.velocity.X == 0f)
                    {
                        this.npc.velocity.X = this.npc.velocity.X - (float)this.npc.direction;
                    }
                    this.npc.velocity.X = this.npc.velocity.X * 1.1f;
                }
                else
                {
                    if (this.npc.velocity.Y > -num115)
                    {
                        this.npc.velocity.Y = this.npc.velocity.Y - num116;
                    }
                }
            }
            if (!flag14)
            {
                if ((this.npc.velocity.X > 0f && num118 > 0f) || (this.npc.velocity.X < 0f && num118 < 0f) || (this.npc.velocity.Y > 0f && num119 > 0f) || (this.npc.velocity.Y < 0f && num119 < 0f))
                {
                    if (this.npc.velocity.X < num118)
                    {
                        this.npc.velocity.X = this.npc.velocity.X + num116;
                    }
                    else
                    {
                        if (this.npc.velocity.X > num118)
                        {
                            this.npc.velocity.X = this.npc.velocity.X - num116;
                        }
                    }
                    if (this.npc.velocity.Y < num119)
                    {
                        this.npc.velocity.Y = this.npc.velocity.Y + num116;
                    }
                    else
                    {
                        if (this.npc.velocity.Y > num119)
                        {
                            this.npc.velocity.Y = this.npc.velocity.Y - num116;
                        }
                    }
                    if ((double)Math.Abs(num119) < (double)num115 * 0.2 && ((this.npc.velocity.X > 0f && num118 < 0f) || (this.npc.velocity.X < 0f && num118 > 0f)))
                    {
                        if (this.npc.velocity.Y > 0f)
                        {
                            this.npc.velocity.Y = this.npc.velocity.Y + num116 * 2f;
                        }
                        else
                        {
                            this.npc.velocity.Y = this.npc.velocity.Y - num116 * 2f;
                        }
                    }
                    if ((double)Math.Abs(num118) < (double)num115 * 0.2 && ((this.npc.velocity.Y > 0f && num119 < 0f) || (this.npc.velocity.Y < 0f && num119 > 0f)))
                    {
                        if (this.npc.velocity.X > 0f)
                        {
                            this.npc.velocity.X = this.npc.velocity.X + num116 * 2f;
                        }
                        else
                        {
                            this.npc.velocity.X = this.npc.velocity.X - num116 * 2f;
                        }
                    }
                }
                else
                {
                    if (num123 > num124)
                    {
                        if (this.npc.velocity.X < num118)
                        {
                            this.npc.velocity.X = this.npc.velocity.X + num116 * 1.1f;
                        }
                        else
                        {
                            if (this.npc.velocity.X > num118)
                            {
                                this.npc.velocity.X = this.npc.velocity.X - num116 * 1.1f;
                            }
                        }
                        if ((double)(Math.Abs(this.npc.velocity.X) + Math.Abs(this.npc.velocity.Y)) < (double)num115 * 0.5)
                        {
                            if (this.npc.velocity.Y > 0f)
                            {
                                this.npc.velocity.Y = this.npc.velocity.Y + num116;
                            }
                            else
                            {
                                this.npc.velocity.Y = this.npc.velocity.Y - num116;
                            }
                        }
                    }
                    else
                    {
                        if (this.npc.velocity.Y < num119)
                        {
                            this.npc.velocity.Y = this.npc.velocity.Y + num116 * 1.1f;
                        }
                        else
                        {
                            if (this.npc.velocity.Y > num119)
                            {
                                this.npc.velocity.Y = this.npc.velocity.Y - num116 * 1.1f;
                            }
                        }
                        if ((double)(Math.Abs(this.npc.velocity.X) + Math.Abs(this.npc.velocity.Y)) < (double)num115 * 0.5)
                        {
                            if (this.npc.velocity.X > 0f)
                            {
                                this.npc.velocity.X = this.npc.velocity.X + num116;
                            }
                            else
                            {
                                this.npc.velocity.X = this.npc.velocity.X - num116;
                            }
                        }
                    }
                }
            }

        }

		private void SegmentBody()
		{
            
            if (JustSpawned)
			{
				int previous = npc.whoAmI;
				const int segments = 30;
                
                for (int i = 0; i < segments; i++)
				{
					int type =
						i < segments - 1
							? mod.NPCType("ShadowDragonBody")
							: mod.NPCType("ShadowDragonTail");
					// whoAmI is only set in NPC.Update...not NewNPC
					// hence this manual work
					int segmentWhoAmI = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, type, ai1: previous, ai2: npc.whoAmI);
					NPC segment = Main.npc[segmentWhoAmI];
					segment.whoAmI = segmentWhoAmI;
					segment.realLife = npc.whoAmI;
					segment.active = true;
					previous = segmentWhoAmI;
				}

				JustSpawned = false;
			}
		}

		public override void NPCLoot()
		{
			Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
if (npc.life <= 0){

int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 62, 0, 0, 100, Color.White, 5.0f);
	Main.dust[dust].noGravity = true;

				if (Main.netMode != 1)
			{
				if (Main.expertMode)
            {
                basicsoul = 2;
            }
            else
            {
                basicsoul = 1;
            }
            count = basicsoul * 500;

				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkSoul"), count);
				
			}
			
		
			}
		}	
	}

	
}
