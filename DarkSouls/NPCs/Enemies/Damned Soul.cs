using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.NPCs.Enemies
{

	public class DamnedSoul : ModNPC
	{
		public int basicsoul;
		static int count;
float customAi1;
float customAi5;
int OptionId = 0;
float customspawn1;


		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Damned Soul");
			Main.npcFrameCount[npc.type] = 4;
		}


		


		public override void SetDefaults()
		{
			npc.aiStyle = 0;
			animationType = 60;
			npc.noTileCollide = true ;
			npc.noGravity = true;
			npc.lifeMax = 2000;
			npc.damage = 28;
			npc.defense = 18;
			npc.knockBackResist = 0.3f;
			npc.width = 50;
			npc.height = 50;
			npc.npcSlots = 10;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 350000; 
			npc.boss = false;
			
			
			npc.alpha = 100;
		}

		

	



		int TimerHeal = 0;
float TimerAnim = 0;

public override void AI()
{
	if (Main.netMode == 2) TimerAnim += 0.5f;
	if (Main.netMode == 0) TimerAnim++;
	if (TimerAnim > 10)
	{
	if (Main.rand.Next(2)==0) npc.spriteDirection *= -1;
	TimerAnim = 0;
	}
	
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 62, 0, 0, 100, color, 1.0f);
	Main.dust[dust].noGravity = true;

	for (int num36 = 0; num36 < 200; num36++)
	{
	if (Main.npc[num36].realLife == npc.whoAmI) Main.npc[num36].life = npc.life;
	}
	if (Main.npc[(int) npc.ai[1]].life > 1000)
	{
	npc.ai[3]++;
	npc.TargetClosest();
	if (npc.ai[3] >= 0)
	{
	if (npc.life > 1000)
	{
		if (Main.netMode != 2)
		{
			float num48 = 0.5f;
			Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
			float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
			rotation += Main.rand.Next(-50,50)/100;
			int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * num48)*-1),(float)((Math.Sin(rotation) * num48)*-1), mod.ProjectileType("ObscureShot"), 70, 0f, 0);
			npc.ai[3] = -200-Main.rand.Next(200);
		}
	}
	else
	{
		if (Main.netMode != 2)
		{
			float num48 = 0.5f;
			Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
			float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
			rotation += Main.rand.Next(-50,50)/100;
			int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * num48)*-1),(float)((Math.Sin(rotation) * num48)*-1), mod.ProjectileType("Obscure Shot"), 70, 0f, 0);
			Main.projectile[num54].scale = 3;
			npc.ai[3] = -50-Main.rand.Next(50);
		}
	}
	}
	if (npc.life <= 1000)
	{
	TimerHeal++;
	if (TimerHeal >= 600)
	{
		npc.life = 2000;
		TimerHeal = 0;
		for (int num36 = 0; num36 < 200; num36++)
		{
		if (Main.npc[num36].realLife == npc.whoAmI) Main.npc[num36].life = 2000;
		}
	}
	}
	}
}
		


		public override void HitEffect(int hitDirection, double damage)
		{
			
		}

		
		
		public override void NPCLoot()
		{
			

		}

	}
}