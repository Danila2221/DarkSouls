using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.NPCs.Enemies
{

	public class MindflayerIllusion : ModNPC
	{
		public int basicsoul;
		static int count;
float customAi1;
float customAi5;
int OptionId = 0;
float customspawn1;


		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mindflayer Illusion");
			Main.npcFrameCount[npc.type] = 3;
		}


		


		public override void SetDefaults()
		{
			animationType = 29;
			npc.noTileCollide = false ;
			npc.noGravity = false;
			npc.lifeMax = 16000;
			npc.damage = 70;
			npc.defense = 40;
			npc.knockBackResist = 0.3f;
			npc.width = 58;
			npc.height = 121;
			npc.npcSlots = 10;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 350000; 
			npc.boss = true;
			npc.value = 500000;

		}


		//npc.ai[2] FRAMES
int lookMode = 0; //0 = Stand, 1 = Player's Direction, 2 = Movement Direction.
bool ShieldBroken = false;
int attackPhase = -1;
int subPhase = 0;
int genericTimer = 0;
int genericTimer2 = 0;
int phaseTime = 90;
bool phaseStarted = false;
	public void Teleport(float X, float Y)
{
int dustDeath = 0;
for (int num36 = 0; num36 < 20; num36++)
{
	dustDeath = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 54, Main.rand.Next(-10,10), Main.rand.Next(-10,10), 200, Color.White, 4f);
	Main.dust[dustDeath].noGravity = true;
}
npc.position.X = X;
npc.position.Y = Y;
npc.velocity.X = 0;
npc.velocity.Y = 0;
for (int num36 = 0; num36 < 20; num36++)
{
	dustDeath = Dust.NewDust(new Vector2(X, Y), npc.width, npc.height, 54, npc.velocity.X+Main.rand.Next(-10,10), npc.velocity.Y+Main.rand.Next(-10,10), 200, Color.White, 4f);
	Main.dust[dustDeath].noGravity = true;
}
}





		public override void AI()
		{
npc.TargetClosest(true);
	
	if (Main.player[npc.target].dead || !Main.player[npc.target].active)
	{
		Teleport(-1000,-1000);
		npc.timeLeft = 0;
	}
	
	for(int num36 = 0; num36 < 10; num36++)
	{
		if (Main.player[npc.target].buffType[num36] == 18)
		{
		Main.player[npc.target].buffType[num36] = 0;
		Main.player[npc.target].buffTime[num36] = 0;
		if (Main.netMode != 2 && Main.myPlayer == npc.target)
		{
		Main.NewText("You've done well, Red. But it's not over yet.", 150, 150, 150);
		}
		break;
		}
	}
	
	Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
	genericTimer++;
	if (attackPhase == -1)
	{
	lookMode = 1;
	phaseTime = 120;
	}
	
	if (attackPhase == 0) // PHASE 0
	{
	if (!phaseStarted)
	{
	lookMode = 1;
	phaseTime = 90;
	if (Main.rand.Next(2)==0) Teleport(Main.player[npc.target].position.X-500, Main.player[npc.target].position.Y+400);
	else Teleport(Main.player[npc.target].position.X+500, Main.player[npc.target].position.Y+400);
	phaseStarted = true;
	}
	bool left = false;
	if (npc.position.X < Main.player[npc.target].position.X) left = false;
	if (npc.position.X > Main.player[npc.target].position.X) left = true;
	genericTimer2++;
	npc.velocity.Y = -10;
	if (genericTimer2 == 15)
	{
	int num54 = 0;
	if (left)
	{
	num54 = Projectile.NewProjectile(vector8.X, vector8.Y,-6+Main.rand.Next(-1,1), Main.rand.Next(-10,10)/5,  mod.ProjectileType("CrazyOrb"), 65, 0f, 0);
	}
	else
	{
	num54 = Projectile.NewProjectile(vector8.X, vector8.Y,6+Main.rand.Next(-1,1), Main.rand.Next(-10,10)/5,  mod.ProjectileType("CrazyOrb"), 65, 0f, 0);
	}
	genericTimer2 = 0;
	}
	}
	
	if (attackPhase == 1) // PHASE 1
	{
	if (!phaseStarted)
	{
	subPhase = Main.rand.Next(2);
	for (int lol = 0; lol < Main.projectile.Length; lol++)
	{
		if (Main.projectile[lol].active && Main.projectile[lol].type == mod.ProjectileType("CrazyOrb"))
		{
		subPhase = 0;
		break;
		}
	}
	lookMode = 0;
	phaseTime = 90;
	Teleport(Main.player[npc.target].position.X+Main.rand.Next(-50,50), Main.player[npc.target].position.Y+Main.rand.Next(-50,50)-300);
	phaseStarted = true;
	}
	genericTimer2++;
	if (genericTimer2 >= 50)
	{
	int randomrot = Main.rand.Next(-20,20)/2;
	if (subPhase == 0) // SUB PHASE 0
	{
	for (int num36 = 0; num36 < 9; num36++)
	{
	int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float) Math.Sin(randomrot+((360/13)*(1+num36))*3),(float) Math.Cos(randomrot+((360/13)*(1+num36))*3),  mod.ProjectileType("ObscureSaw"), 75, 0f, 0);
	}
	genericTimer2 = 0;
	}
	if (subPhase == 1) // SUB PHASE 1
	{
	for (int num36 = 0; num36 < 6; num36++)
	{
	int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float) Math.Sin(randomrot+((360/10)*(1+num36)))*6,(float) Math.Cos(randomrot+((360/10)*(1+num36)))*6,  mod.ProjectileType("CrazyOrb"), 65, 0f, 0);
	Main.projectile[num54].ai[0] = npc.target;
	}
	genericTimer2 = -200;
	}
	}
	}
	
	if (attackPhase == 2) // PHASE 2
	{
	if (!phaseStarted)
	{
	lookMode = 2;
	phaseTime = 90;
	npc.position.X = Main.player[npc.target].position.X + (float) ((600* Math.Cos((float) (Main.rand.Next(360)*(Math.PI/180))))*-1);
    npc.position.Y = Main.player[npc.target].position.Y + (float) ((600* Math.Sin((float) (Main.rand.Next(360)*(Math.PI/180))))*-1);
    Vector2 vector7 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
    float rotation = (float) Math.Atan2(vector7.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector7.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
    npc.velocity.X = (float) (Math.Cos(rotation) * 14)*-1;
    npc.velocity.Y = (float) (Math.Sin(rotation) * 14)*-1;
	phaseStarted = true;
	}
	genericTimer2++;
	npc.velocity.X *= 0.99f;
	npc.velocity.Y *= 0.99f;
	if (genericTimer2 >= 20)
	{
		float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
		rotation += Main.rand.Next(-50,50)/100;
		int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * 0.5)*-1),(float)((Math.Sin(rotation) * 0.5)*-1),  mod.ProjectileType("ObscureSaw"), 65, 0f, 0);
		genericTimer2 = 0;
	}
	}
	
	if (attackPhase == 3) // PHASE 3
	{
	if (!phaseStarted)
	{
	lookMode = 2;
	phaseTime = 180;
	npc.position.X = Main.player[npc.target].position.X + (float) ((600* Math.Cos((float) (Main.rand.Next(360)*(Math.PI/180))))*-1);
    npc.position.Y = Main.player[npc.target].position.Y + (float) ((600* Math.Sin((float) (Main.rand.Next(360)*(Math.PI/180))))*-1);
	phaseStarted = true;
	}
	Vector2 vector7 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
	float rotation = (float) Math.Atan2(vector7.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector7.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
	npc.velocity.X = (float) (Math.Cos(rotation) * 4)*-1;
    npc.velocity.Y = (float) (Math.Sin(rotation) * 4)*-1;
	genericTimer2++;
	if (genericTimer2 >= 12)
	{
		rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
		rotation += Main.rand.Next(-50,50)/100;
		int num54 = Projectile.NewProjectile(vector8.X+Main.rand.Next(-100,100), vector8.Y+Main.rand.Next(-100,100),(float)((Math.Cos(rotation) * (0.5f+(Main.rand.Next(-3,3)/10)))*-1),(float)((Math.Sin(rotation) * (0.5f+(Main.rand.Next(-3,3)/10)))*-1), mod.ProjectileType("PoisonSmog"), 18, 0f, 0);
		genericTimer2 = 0;
	}
	}
	
	if (genericTimer >= phaseTime)
	{
	attackPhase = Main.rand.Next(4);
	genericTimer = 0;
	genericTimer2 = 0;
	phaseStarted = false;
	}

	if (npc.life <= npc.lifeMax/2)
	{
	int NewOkiku = NPC.NewNPC((int) vector8.X, (int) vector8.Y, mod.NPCType("BrokenOkiku"), 0);
	Main.npc[NewOkiku].life = npc.life;
	npc.active = false;
	}
}

public void FindFrame(int currentFrame)
{
	int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 54, npc.velocity.X, npc.velocity.Y, 100, Color.White, 1f);
    Main.dust[dust].noGravity = true;
	
	int num = 1;
	if (!Main.dedServ)
	{
		num = Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type];
	}

	if (lookMode == 0)
if ((npc.velocity.X > -2 && npc.velocity.X < 2) && (npc.velocity.Y > -2 && npc.velocity.Y < 2))
{
    npc.frameCounter = 0;
    npc.frame.Y = 0;
    if (npc.position.X > Main.player[npc.target].position.X)
    {
        npc.spriteDirection = -1;
    }
    else
    {
        npc.spriteDirection = 1;
    }
}	



	if (lookMode == 1)
if ((npc.velocity.X > -2 && npc.velocity.X < 2) && (npc.velocity.Y > -2 && npc.velocity.Y < 2))
{
    npc.frameCounter = 0;
    npc.frame.Y = 0;
    if (npc.position.X > Main.player[npc.target].position.X)
    {
        npc.spriteDirection = -1;
    }
    else
    {
        npc.spriteDirection = 1;
    }
}	



	if (lookMode == 2)
	if ((npc.velocity.X > -2 && npc.velocity.X < 2) && (npc.velocity.Y > -2 && npc.velocity.Y < 2))
{
    npc.frameCounter = 0;
    npc.frame.Y = 0;
    if (npc.position.X > Main.player[npc.target].position.X)
    {
        npc.spriteDirection = -1;
    }
    else
    {
        npc.spriteDirection = 1;
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