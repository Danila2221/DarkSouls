using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.NPCs.Enemies
{

	public class Blight : ModNPC
	{
		public int basicsoul;
		static int count;
 		int chargeDamage = 0;
bool chargeDamageFlag = false;



static float j = 0;
static float m = 0;
static float n = 0;

bool haspanicked = false;


int phase = 700;
int attackindex = 0;
float spazzlevel;
float targetspazzlevel;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blight");
			Main.npcFrameCount[npc.type] = 3;
		}


		


		public override void SetDefaults()
		{
			npc.aiStyle = -1;
			animationType = -1;
			npc.noTileCollide = true ;
			npc.noGravity = true;
			npc.lifeMax = 300000;
			npc.damage = 105;
			npc.defense = 90;
			npc.knockBackResist = 0.3f;
			npc.width = 58;
			npc.height = 121;
			npc.npcSlots = 10;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.boss = true;
			npc.value = 500000;

		}





		public override void AI()
		{
	int num54;


















this.npc.TargetClosest(true);
if (Main.player[this.npc.target].position.Y-100 > this.npc.position.Y) {

Color color = new Color();
    int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 15, npc.velocity.X, npc.velocity.Y, 250, color, 5f);
    Main.dust[dust].noGravity = true;


this.npc.directionY = 1;
}
else {

Color color = new Color();
    int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 15, npc.velocity.X, npc.velocity.Y, 250, color, 4f);
    Main.dust[dust].noGravity = false;


this.npc.directionY = -1;
}		
			
if (Main.player[this.npc.target].position.X-250 > this.npc.position.X) {

Color color = new Color();
    int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 15, npc.velocity.X, npc.velocity.Y, 250, color, 2f);
    Main.dust[dust].noGravity = false;


this.npc.direction = 1;
}
else {

Color color = new Color();
    int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 15, npc.velocity.X, npc.velocity.Y, 250, color, 5f);
    Main.dust[dust].noGravity = false;


this.npc.direction = -1;
}	

this.npc.spriteDirection = 1;

this.npc.frame.Width = 40;





if (attackindex == 0) {
this.npc.frame.Y = 58;
}





bool flag25 = false;
    npc.ai[1] += (Main.rand.Next(2, 5) * 0.1f) * npc.scale;
    if (npc.ai[1] >= 8f)
    {
       npc.TargetClosest(true);
		if (Main.rand.Next(450)==1) 
        {
            chargeDamageFlag = true;
            Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
            float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
            npc.velocity.X = (float) (Math.Cos(rotation) * 12)*-1;
            npc.velocity.Y = (float) (Math.Sin(rotation) * 12)*-1;
			npc.ai[1] = 1f;
            npc.netUpdate=true;
        }
        if (chargeDamageFlag == true)
        {
            npc.damage= 130;
            chargeDamage ++;
        }
        if (chargeDamage >= 50)
        {
            chargeDamageFlag = false;
            npc.damage= 80;
            chargeDamage = 0;
        }
}









					if (this.npc.direction == -1 && this.npc.velocity.X > -2f)
					{
						this.npc.velocity.X = this.npc.velocity.X - 0.1f;
						if (this.npc.velocity.X > 2f)
						{
							this.npc.velocity.X = this.npc.velocity.X - 0.1f;
						}
						else
						{
							if (this.npc.velocity.X > 0f)
							{
								this.npc.velocity.X = this.npc.velocity.X + 0.05f;
							}
						}
						if (this.npc.velocity.X < -2f)
						{
							this.npc.velocity.X = -2f;
						}
					}
					else
					{
						if (this.npc.direction == 1 && this.npc.velocity.X < 2f)
						{
							this.npc.velocity.X = this.npc.velocity.X + 0.1f;
							if (this.npc.velocity.X < -2f)
							{
								this.npc.velocity.X = this.npc.velocity.X + 0.1f;
							}
							else
							{
								if (this.npc.velocity.X < 0f)
								{
									this.npc.velocity.X = this.npc.velocity.X - 0.05f;
								}
							}
							if (this.npc.velocity.X > 2f)
							{
								this.npc.velocity.X = 2f;
							}
						}
					}
					if (this.npc.directionY == -1 && (double)this.npc.velocity.Y > -1.5)
					{
						this.npc.velocity.Y = this.npc.velocity.Y - 0.05f;

						if ((double)this.npc.velocity.Y < -1.5)
						{
							this.npc.velocity.Y = -1.5f;
						}
					}
					else
					{
						if (this.npc.directionY == 1 && (double)this.npc.velocity.Y < 1.5)
						{
							this.npc.velocity.Y = this.npc.velocity.Y + 0.05f;
							if ((double)this.npc.velocity.Y > 1.5)
							{
								this.npc.velocity.Y = 1.5f;
							}
						}
					}

			


//Deal with dat crazy spazzin' out;
spazzlevel+= (targetspazzlevel-spazzlevel)/60f;
			
//Cycle through all attacks linearly		
if (phase > 1000) {
phase = 0;
attackindex = Main.rand.Next(1,5);
}		


phase++;

// If we're almost dead, activate the Cataclysm
if (this.npc.life < 2000) {
attackindex = 5;
}


//Actual attacks

//Condemnation - Phantom Seeker
	if (attackindex == 1) {
targetspazzlevel = 0;


if (((int)Main.time % 60) < 1)  {
for (int i = 0; i < 2; i++) {
num54 = Projectile.NewProjectile(this.npc.position.X+20,this.npc.position.Y+50,Main.rand.Next(-5,5),Main.rand.Next(-5,5),mod.ProjectileType("PhantomSeeker"),115,0f,Main.myPlayer);
Main.projectile[num54].timeLeft = 400;
Main.projectile[num54].rotation = Main.rand.Next(700)/100f;
Main.projectile[num54].ai[0] = this.npc.target;
}}
	}  


//Antimatter - Black Comet
	else if (attackindex == 3) {
targetspazzlevel = 10;


if (((int)Main.time % 20) < 1)  {
num54 = Projectile.NewProjectile(this.npc.position.X+Main.rand.Next(-50,600),this.npc.position.Y-450,0,5,mod.ProjectileType("Comet"),100,0f,Main.myPlayer);
Main.projectile[num54].timeLeft = 500;
}
	}  


//Dark Astronomy - Black Spiral
	else if (attackindex == 2) {
targetspazzlevel = 25;

if (((int)Main.time % 60) < 1)  {
for (int i = 0; i < 6; i++) {
j += (float)1;
num54 = Projectile.NewProjectile(this.npc.position.X+20,this.npc.position.Y+50,0,0,mod.ProjectileType("PhantomSpiral"),60,0f,Main.myPlayer);
Main.projectile[num54].timeLeft = 350;
Main.projectile[num54].rotation = Main.rand.Next(700)/100f;
Main.projectile[num54].ai[0] = this.npc.whoAmI;
Main.projectile[num54].ai[1] = Main.rand.Next(200, 600);
}}
	}  

//Annihilation - Antimatter Cannon
	else if (attackindex == 4) {
float j = (float)Math.Atan2((double)(this.npc.position.X-Main.player[this.npc.target].position.X), (double)(this.npc.position.Y-Main.player[this.npc.target].position.Y+48));

targetspazzlevel = 50;
this.npc.velocity.Y = 0;
this.npc.velocity.X = 0;
if (((int)Main.time % 5) < 1 && phase > 100)  {
phase+=10;
for (int i = 0; i < 6; i++) {
int s=Main.rand.Next(2,10);
float m=(float)Math.Sin(j)*-s;
float n=(float)Math.Cos(j)*-s;
num54 = Projectile.NewProjectile(this.npc.position.X+Main.rand.Next(-25,25),this.npc.position.Y+Main.rand.Next(50,150),m,n,mod.ProjectileType("AntimatterCannon"),140,0f,Main.myPlayer);
Main.projectile[num54].scale = (Main.rand.Next(50,100))/75f;
Main.projectile[num54].timeLeft = 300;
}
}
	}  


	else {
targetspazzlevel = 0;
}
			
}



//public bool PreDraw(SpriteBatch sp) -- is old
public void PreDraw(Player P,SpriteBatch SP,ref bool LetDraw)  
{


Texture2D Noise_Texture=Main.npcTexture[this.npc.type];
Random rand1 = new Random((int)Main.time);
int height = this.npc.frame.Height;
int width = this.npc.frame.Width;
int offsetx = this.npc.frame.X;
int offsety = this.npc.frame.Y;
float targetscale = 1f;
Rectangle fromrect = new Rectangle(offsetx, offsety,width,height);
Vector2 PC = this.npc.position;
SpriteEffects mydirection;
if (this.npc.spriteDirection >= 0) mydirection = SpriteEffects.FlipHorizontally;
else mydirection = SpriteEffects.None;
for (int i = 0; i <5; i++) {

PC = this.npc.position;
PC.Y += this.npc.height*2.5f;

PC.X += rand1.Next((int)-spazzlevel,(int)spazzlevel);
PC.Y += rand1.Next((int)-spazzlevel,(int)spazzlevel);
Color targetColor = new Color(0,0,0,0);
SP.Draw(
            Noise_Texture, 
            PC-Main.screenPosition,
            fromrect,
            targetColor, 
            this.npc.rotation,//Main.rand.Next(600)/100, 
            new Vector2(0,0),
            targetscale*1.04f,
            mydirection, 
            0f);
}

rand1 = new Random((int)Main.time);
for (int i = 0; i <5; i++) {
PC = this.npc.position;

PC.Y += this.npc.height*0.1f;

PC.X += rand1.Next((int)-spazzlevel,(int)spazzlevel);
PC.Y += rand1.Next((int)-spazzlevel,(int)spazzlevel);
Color targetColor = new Color(0,0,0,0);
SP.Draw(
            Noise_Texture, 
            PC-Main.screenPosition,
            fromrect,
            targetColor, 
            this.npc.rotation,//Main.rand.Next(600)/100, 
            new Vector2(0,0),
            targetscale,
            mydirection, 
            0f);
}

return;
}
	
		


		public override void HitEffect(int hitDirection, double damage)
		{
			
		}

		
		
		public override void NPCLoot()
		{
			

		}

	}
}