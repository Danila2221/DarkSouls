using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using DarkSouls;
namespace DarkSouls.NPCs.Enemies
{

	public class Rage : ModNPC
	{
        public int basicsoul;
        static int count;


        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Rage");
			Main.npcFrameCount[npc.type] = 7;
		}


		


		public override void SetDefaults()
		{
            animationType = -1;
            npc.lifeMax = 13000;
            npc.damage = 35;
			npc.defense = 24;
			npc.knockBackResist = 0.3f;
			npc.width = 180;
			npc.height = 126;
			npc.aiStyle = 3;
            npc.noTileCollide = true;
            npc.noGravity = true;
			npc.npcSlots = 200;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 100000; 
			npc.boss = true;
            npc.buffImmune[24] = true;
            npc.buffImmune[20] = true;
            npc.buffImmune[31] = true;
        }



		
public override void AI()
{
            npc.netUpdate = true;
            npc.ai[2]++;
            npc.ai[1]++;
            if (npc.ai[0] > 0) npc.ai[0] -= 1.2f;
            Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active || Main.player[npc.target].position.Y > (Main.maxTilesY - 250) * 16)
            {
                npc.TargetClosest(true);
            }
            Color color = new Color();
            int dust = Dust.NewDust(new Vector2((float)npc.position.X, (float)npc.position.Y), npc.width, npc.height, 6, npc.velocity.X, npc.velocity.Y, 200, color, 0.5f + npc.ai[0] / 75);
            Main.dust[dust].noGravity = true;

            if (npc.ai[3] == 0)
            {
                npc.alpha = 0;
                npc.dontTakeDamage = false;
                npc.damage = 35;
                if (npc.ai[2] < 600)
                {
                    if (Main.player[npc.target].position.X < vector8.X)
                    {
                        if (npc.velocity.X > -8) { npc.velocity.X -= 0.22f; }
                    }
                    if (Main.player[npc.target].position.X > vector8.X)
                    {
                        if (npc.velocity.X < 8) { npc.velocity.X += 0.22f; }
                    }

                    if (Main.player[npc.target].position.Y < vector8.Y + 300)
                    {
                        if (npc.velocity.Y > 0f) npc.velocity.Y -= 0.8f;
                        else npc.velocity.Y -= 0.07f;
                    }
                    if (Main.player[npc.target].position.Y > vector8.Y + 300)
                    {
                        if (npc.velocity.Y < 0f) npc.velocity.Y += 0.8f;
                        else npc.velocity.Y += 0.07f;
                    }
                    if (npc.life <= npc.lifeMax / 2)
                    { 
                        if (Main.rand.Next(20) == 1)
                    {
                        float num48 = 47f;//25 was 40
                        int damage = 28;
                        int type = mod.ProjectileType("FireTrails");
                        Main.PlaySound(2, (int)vector8.X, (int)vector8.Y, 17);
                        float rotation = (float)Math.Atan2(vector8.Y - 600 - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), vector8.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y - 600, (float)((Math.Cos(rotation) * num48) * -1), (float)((Math.Sin(rotation) * num48) * -1), type, damage, 0f, Main.myPlayer);
                        Main.projectile[num54].timeLeft = 550;
                        num54 = Projectile.NewProjectile(vector8.X, vector8.Y - 600, (float)((Math.Cos(rotation + 0.4) * num48) * -1), (float)((Math.Sin(rotation + 0.4) * num48) * -1), type, damage, 0f, Main.myPlayer);
                        Main.projectile[num54].timeLeft = 550;
                        num54 = Projectile.NewProjectile(vector8.X, vector8.Y - 600, (float)((Math.Cos(rotation - 0.4) * num48) * -1), (float)((Math.Sin(rotation - 0.4) * num48) * -1), type, damage, 0f, Main.myPlayer);
                        Main.projectile[num54].timeLeft = 550;
                        npc.ai[1] = -90;
                    }
                    }
                }
                else if (npc.ai[2] >= 600 && npc.ai[2] < 1200)
                {
                    npc.velocity.X *= 0.98f;
                    npc.velocity.Y *= 0.98f;
                    if ((npc.velocity.X < 2f) && (npc.velocity.X > -2f) && (npc.velocity.Y < 2f) && (npc.velocity.Y > -2f))
                    {
                        float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                        npc.velocity.X = (float)(Math.Cos(rotation) * 25) * -1;
                        npc.velocity.Y = (float)(Math.Sin(rotation) * 25) * -1;
                    }
                }
                else npc.ai[2] = 0;
            }
            else
            {
                npc.ai[3]++;
                npc.alpha = 200;
                npc.damage = 75;
                npc.dontTakeDamage = true;
                if (Main.player[npc.target].position.X < vector8.X)
                {
                    if (npc.velocity.X > -6) { npc.velocity.X -= 0.22f; }
                }
                if (Main.player[npc.target].position.X > vector8.X)
                {
                    if (npc.velocity.X < 6) { npc.velocity.X += 0.22f; }
                }
                if (Main.player[npc.target].position.Y < vector8.Y)
                {
                    if (npc.velocity.Y > 0f) npc.velocity.Y -= 0.8f;
                    else npc.velocity.Y -= 0.07f;
                }
                if (Main.player[npc.target].position.Y > vector8.Y)
                {
                    if (npc.velocity.Y < 0f) npc.velocity.Y += 0.8f;
                    else npc.velocity.Y += 0.07f;
                }
                if (npc.ai[3] == 100)
                {
                    npc.ai[3] = 1;
                    npc.life += 50;
                    if (npc.life > npc.lifeMax) npc.life = npc.lifeMax;
                }
                if (npc.ai[1] >= 0)
                {
                    npc.ai[3] = 0;
                    for (int num36 = 0; num36 < 40; num36++)
                    {
                        Dust.NewDust(new Vector2((float)npc.position.X, (float)npc.position.Y), npc.width, npc.height, 6, 0, 0, 0, color, 3f);
                    }
                }
            }
            if (Main.player[npc.target].dead)
            {
                npc.velocity.Y += 0.20f;
                if (npc.timeLeft > 10)
                {
                    npc.timeLeft = 0;
                    return;
                }
            }
        }

        public override void FindFrame(int currentFrame)
        {
            int num = 1;
            if (!Main.dedServ)
            {
                num = Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type];
            }
            if (npc.velocity.X < 0)
            {
                npc.spriteDirection = -1;
            }
            else
            {
                npc.spriteDirection = 1;
            }
            npc.rotation = npc.velocity.X * 0.08f;
            npc.frameCounter += 1.0;
            if (npc.frameCounter >= 4.0)
            {
                npc.frame.Y = npc.frame.Y + num;
                npc.frameCounter = 0.0;
            }
            if (npc.frame.Y >= num * Main.npcFrameCount[npc.type])
            {
                npc.frame.Y = 0;
            }
            if (npc.ai[3] == 0)
            {
                npc.alpha = 0;
            }
            else
            {
                npc.alpha = 200;
            }
        }

        public void DealtNPC(double damage, Player player)
        {
            npc.ai[0] += (float)damage;
            if (npc.ai[0] > 700)
            {
                npc.ai[3] = 1;
                Color color = new Color();
                for (int num36 = 0; num36 < 50; num36++)
                {
                    int dust = Dust.NewDust(new Vector2((float)npc.position.X, (float)npc.position.Y), npc.width, npc.height, 4, 0, 0, 100, color, 3f);
                }
                for (int num36 = 0; num36 < 20; num36++)
                {
                    int dust = Dust.NewDust(new Vector2((float)npc.position.X, (float)npc.position.Y), npc.width, npc.height, 6, 0, 0, 100, color, 3f);
                }
                npc.ai[1] = -250;
                npc.ai[0] = 0;
            }
        }


        
		public override void NPCLoot()
		{
			
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
            count = basicsoul * 5000;
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CobaltDrill, 1);
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkSoul"), count);
				
			}	
			
		}

	}
}