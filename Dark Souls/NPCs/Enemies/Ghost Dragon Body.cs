using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.NPCs.Enemies
{
	public class GhostDragonBody : ModNPC
	{
		int Timer = -Main.rand.Next(800);



		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ghost Wyvern");
			Main.npcFrameCount[npc.type] = 1;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 10000;
			npc.damage = 115;
			npc.defense = 120;
			npc.knockBackResist = 0f;
			npc.width = 24;
			npc.height = 44;
			npc.noTileCollide = true ;
			animationType = NPCID.WyvernHead;﻿
			npc.scale = 1f;
			npc.boss = true;
			npc.aiStyle = 6;
			npc.npcSlots = 1f;
			npc.HitSound = SoundID.NPCHit4;
			npc.noGravity = true;
			npc.DeathSound = SoundID.NPCDeath10;
			npc.netAlways = true;
			npc.active = true;
			npc.npcSlots = 1;
    		npc.behindTiles = true;
		}

		public int basicsoul;
		static int count;

		

		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			
		}
		
		public override void AI()
		{
			

			npc.noTileCollide = true;
    npc.noGravity = true;
    npc.behindTiles = true;
Timer++;



	//if (npc.position.X > Main.npc[(int)npc.ai[1]].position.X)
	//{
	//	npc.spriteDirection = 1;
	//}
	//if (npc.position.X < Main.npc[(int)npc.ai[1]].position.X)
	//{
	//	npc.spriteDirection = -1;
	//}

		if (Timer >= 600)
		{
			if (Main.netMode != 2)
			{
				float num48 = 2f;
				Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
				float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
				rotation += Main.rand.Next(-50,50)/100;
				int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * num48)*-1),(float)((Math.Sin(rotation) * num48)*-1), mod.ProjectileType("PoisonCrystalFire"), 100, 0f, 0);
				Timer = -600-Main.rand.Next(700);
			}
		}


	if (!Main.npc[(int)npc.ai[1]].active)
	{
		npc.life = 0;
		NPCLoot();
		npc.HitEffect(0, 10.0);
		npc.active = false;
	}
	
}

		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			return false;
		}

	}
}
