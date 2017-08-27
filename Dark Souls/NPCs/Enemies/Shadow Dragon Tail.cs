using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.NPCs.Enemies
{
	public class ShadowDragonTail : ModNPC
	{
		int Timer = -Main.rand.Next(800);



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
			npc.width = 24;
			npc.height = 44;
			npc.noTileCollide = true ;
			animationType = 87;
			
			npc.aiStyle = 6;
			npc.npcSlots = 0.2f;
			npc.HitSound = SoundID.NPCHit7;
			npc.noGravity = true;
			npc.DeathSound = SoundID.NPCDeath8;
			npc.netAlways = true;
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
		if (Timer >= 500)
		{
			//if (Main.netMode != 2)
			//{
				float num48 = 1f;
				Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
				float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
				rotation += Main.rand.Next(-50,50)/100;
				int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * num48)*-1),(float)((Math.Sin(rotation) * num48)*-1), mod.ProjectileType("ShadowOrb"), 55, 0f, 0);
				Timer = -300-Main.rand.Next(300);
			//}
		}

	if (Main.rand.Next(2)==0)
	{
		int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 62, 0, 0, 100, Color.White, 2.0f);
		Main.dust[dust].noGravity = true;
	}


	if (!Main.npc[(int)npc.ai[1]].active)
	{
		npc.life = 0;
		npc.HitEffect(0, 10.0);
		NPCLoot();
		npc.active = false;
	}
	
}

		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			return false;
		}

	}
}
