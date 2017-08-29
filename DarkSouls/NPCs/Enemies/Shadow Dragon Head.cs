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
