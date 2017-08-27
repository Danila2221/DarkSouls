using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.NPCs.Enemies
{
	public class GhostDragonTail : ModNPC
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
		
		

		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			return false;
		}

	}
}
