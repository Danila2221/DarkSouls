using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.NPCs.Enemies
{
	public class ArmoredWraith : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Armored Wraith");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 150;
			npc.damage = 95;
			npc.defense = 25;
			npc.knockBackResist = 0f;
			npc.width = 24;
			npc.height = 44;
			npc.noTileCollide = true ;
			animationType = 82;
			aiType = -1;
			npc.aiStyle = 22;
			npc.npcSlots = 0.2f;
			npc.HitSound = SoundID.NPCHit1;
			npc.noGravity = true;
			npc.DeathSound = SoundID.NPCDeath6;
			
		}

		public int basicsoul;
		static int count;

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = Main.tile[x, y].type;
        	return y > Main.rockLayer ? 0.025f : 0f;


		}

		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Main.rand.Next(5) == 0)
	{
		player.AddBuff(36, 10800, false);
	}
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			
		}
		public override void NPCLoot()
		{
			if (!Main.hardMode){
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
            count = basicsoul * 25;

				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkSoul"), count);
				
			}
			}
		
		
			
		}

	}
}
