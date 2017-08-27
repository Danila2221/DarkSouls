using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.NPCs.Enemies
{

	public class Artorias : ModNPC
	{
		public int basicsoul;
		static int count;



		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Artorias Of The Abyss");
			Main.npcFrameCount[npc.type] = 16;
		}


		


		public override void SetDefaults()
		{
			npc.aiStyle = 3;
			animationType = 28;
			npc.lifeMax = 76000;
			npc.damage = 200;
			npc.defense = 3050;
			npc.knockBackResist = 0f;
			npc.width = 30;
			npc.height = 40;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = 700000; 
			npc.boss = true;
			npc.buffImmune[20] = true;
			npc.buffImmune[31] = true;
			npc.buffImmune[39] = true;
			npc.buffImmune[24] = true;



		}



		float customAi1;

float customspawn2;

		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if  (Main.rand.Next(4) == 0)
			{
				player.AddBuff(24, 180, false);
			}
		}







		public override void AI()
		{

int num58;
int num59;


int dust = Dust.NewDust(new Vector2((float) npc.position.X, (float) npc.position.Y), npc.width, npc.height, 32, npc.velocity.X-3f, npc.velocity.Y, 150, Color.Yellow, 1f);
                Main.dust[dust].noGravity = true;


    int num3 = 60;
    bool flag2 = false;
	int num5 = 60;
	bool flag3 = true;
	if (npc.velocity.Y == 0f && (npc.velocity.X == 0f && npc.direction < 0))
    {
        npc.velocity.Y -= 2f;
        npc.velocity.X -= 4f; 
    }
    else if (npc.velocity.Y == 0f && (npc.velocity.X == 0f && npc.direction > 0))
    {
        npc.velocity.Y -= 8f;
        npc.velocity.X += 4f; 
    }
	if (npc.velocity.Y == 0f && ((npc.velocity.X > 0f && npc.direction < 0) || (npc.velocity.X < 0f && npc.direction > 0)))
	{
		flag2 = true;
	}
	if (npc.position.X == npc.oldPosition.X || npc.ai[3] >= (float)num5 || flag2)
	{
		npc.ai[3] += 1f;
	}
	else
	{
		if ((double)Math.Abs(npc.velocity.X) > 0.9 && npc.ai[3] > 0f)
		{
			npc.ai[3] -= 1f;
		}
	}
	if (npc.ai[3] > (float)(num5 * 10))
	{
		npc.ai[3] = 0f;
	}
	if (npc.justHit)
	{
		npc.ai[3] = 0f;
	}
	if (npc.ai[3] == (float)num5)
	{
		npc.netUpdate = true;
	}
	if ((!Main.dayTime || (double)npc.position.Y > Main.worldSurface * 16.0 || npc.type == 26 || npc.type == 27 || npc.type == 28 || npc.type == 31 || npc.type == 47 || npc.type == 67 || npc.type == 73 || npc.type == 77 || npc.type == 78 || npc.type == 79 || npc.type == 80 || npc.type == 110 || npc.type == 111 || npc.type == 120) && npc.ai[3] < (float)num5)
	{
		if ((npc.type == 3 || npc.type == 21 || npc.type == 31 || npc.type == 77 || npc.type == 110 || npc.type == 132) && Main.rand.Next(1000) == 0)
		{
			Main.PlaySound(14, (int)npc.position.X, (int)npc.position.Y, 1);
		}
		if ((npc.type == 78 || npc.type == 79 || npc.type == 80) && Main.rand.Next(500) == 0)
		{
			Main.PlaySound(26, (int)npc.position.X, (int)npc.position.Y, 1);
		}
		npc.TargetClosest(true);
	}
	else
	{
		if (npc.velocity.X == 0f)
		{
			if (npc.velocity.Y == 0f)
			{
				npc.ai[0] += 1f;
				if (npc.ai[0] >= 2f)
				{
					npc.direction *= -1;
					npc.spriteDirection = npc.direction;
					npc.ai[0] = 0f;
				}
			}
		}
		else
		{
			npc.ai[0] = 0f;
		}
		if (npc.direction == 0)
		{
			npc.direction = 1;
		}
	}
	if (npc.velocity.X < -1.5f || npc.velocity.X > 1.5f)
	{
		if (npc.velocity.Y == 0f)
		{
			npc.velocity *= 0.8f;
		}
	}
	else
	{
		if (npc.velocity.X < 1.5f && npc.direction == 1)
		{
			npc.velocity.X = npc.velocity.X + 0.07f;
			if (npc.velocity.X > 1.5f)
			{
				npc.velocity.X = 1.5f;
			}
		}
		else
		{
			if (npc.velocity.X > -1.5f && npc.direction == -1)
			{
				npc.velocity.X = npc.velocity.X - 0.07f;
				if (npc.velocity.X < -1.5f)
				{
					npc.velocity.X = -1.5f;
				}
			}
		}
	}
	bool flag4 = false;
	if (npc.velocity.Y == 0f)
	{
		int num29 = (int)(npc.position.Y + (float)npc.height + 8f) / 16;
		int num30 = (int)npc.position.X / 16;
		int num31 = (int)(npc.position.X + (float)npc.width) / 16;
		for (int l = num30; l <= num31; l++)
		{
			if (Main.tile[l, num29] == null)
			{
				return;
			}
			if (Main.tileSolid[(int)Main.tile[l, num29].type])
			{
				flag4 = true;
				break;
			}
		}
	}
	if (flag4)
	{
		int num32 = (int)((npc.position.X + (float)(npc.width / 2) + (float)(15 * npc.direction)) / 16f);
		int num33 = (int)((npc.position.Y + (float)npc.height - 15f) / 16f);
		if (npc.type == 109)
		{
			num32 = (int)((npc.position.X + (float)(npc.width / 2) + (float)((npc.width / 2 + 16) * npc.direction)) / 16f);
		}
		if (Main.tile[num32, num33] == null)
		{
			Main.tile[num32, num33] = new Tile();
		}
		if (Main.tile[num32, num33 - 1] == null)
		{
			Main.tile[num32, num33 - 1] = new Tile();
		}
		if (Main.tile[num32, num33 - 2] == null)
		{
			Main.tile[num32, num33 - 2] = new Tile();
		}
		if (Main.tile[num32, num33 - 3] == null)
		{
			Main.tile[num32, num33 - 3] = new Tile();
		}
		if (Main.tile[num32, num33 + 1] == null)
		{
			Main.tile[num32, num33 + 1] = new Tile();
		}
		if (Main.tile[num32 + npc.direction, num33 - 1] == null)
		{
			Main.tile[num32 + npc.direction, num33 - 1] = new Tile();
		}
		if (Main.tile[num32 + npc.direction, num33 + 1] == null)
		{
			Main.tile[num32 + npc.direction, num33 + 1] = new Tile();
		}
		if (Main.tile[num32, num33 - 1].type == 10 && flag3)
		{
			npc.ai[2] += 1f;
			npc.ai[3] = 0f;
			if (npc.ai[2] >= 60f)
			{
				npc.velocity.X = 0.5f * (float)(-(float)npc.direction);
				npc.ai[1] += 1f;
				npc.ai[2] = 0f;
				bool flag5 = false;
				if (npc.ai[1] >= 10f)
				{
					flag5 = true;
					npc.ai[1] = 10f;
				}
				WorldGen.KillTile(num32, num33 - 1, true, false, false);
				if ((Main.netMode != 1 || !flag5) && flag5 && Main.netMode != 1)
				{
					if (npc.type == 26)
					{
						WorldGen.KillTile(num32, num33 - 1, false, false, false);
						if (Main.netMode == 2)
						{
							NetMessage.SendData(17, -1, -1, null, 0, (float)num32, (float)(num33 - 1), 0f, 0);
						}
					}
					else
					{
						bool flag6 = WorldGen.OpenDoor(num32, num33, npc.direction);
						if (!flag6)
						{
							npc.ai[3] = (float)num5;
							npc.netUpdate = true;
						}
						if (Main.netMode == 2 && flag6)
						{
							NetMessage.SendData(19, -1, -1, null, 0, (float)num32, (float)num33, (float)npc.direction, 0);
						}
					}
				}
			}
		}
		else
		{
			if ((npc.velocity.X < 0f && npc.spriteDirection == -1) || (npc.velocity.X > 0f && npc.spriteDirection == 1))
			{
				if (Main.tileSolid[(int)Main.tile[num32, num33 - 2].type])
				{
					if (Main.tileSolid[(int)Main.tile[num32, num33 - 3].type])
					{
						npc.velocity.Y = -8f;
						npc.netUpdate = true;
					}
					else
					{
						npc.velocity.Y = -7f;
						npc.netUpdate = true;
					}
				}
				else
				{
					if (Main.tileSolid[(int)Main.tile[num32, num33 - 1].type])
					{
						npc.velocity.Y = -6f;
						npc.netUpdate = true;
					}
					else
					{
						if (Main.tileSolid[(int)Main.tile[num32, num33].type])
						{
							npc.velocity.Y = -5f;
							npc.netUpdate = true;
						}
						else
						{
							if (npc.directionY < 0 && npc.type != 67)
							{
								npc.velocity.Y = -8f;
								npc.velocity.X = npc.velocity.X * 1.5f;
								npc.netUpdate = true;
							}
							else
							{
								if (flag3)
								{
									npc.ai[1] = 0f;
									npc.ai[2] = 0f;
								}
							}
						}
					}
				}
			}
		}
	}
	else
	{
		if (flag3)
		{
			npc.ai[1] = 0f;
			npc.ai[2] = 0f;
		}
	}

    if(Main.netMode != 1)
    {
        customAi1 += (Main.rand.Next(2, 5) * 0.1f) * npc.scale;
        if (customAi1 >= 10f)
        {
            npc.TargetClosest(true);
            
            if ((customspawn2 < 1) && Main.rand.Next(950)==1)
	        {
		        int Spawned = NPC.NewNPC((int) npc.position.X+(npc.width/2), (int) npc.position.Y+(npc.height/2), mod.NPCType("Witchking"), 0);
		        Main.npc[Spawned].velocity.Y = -8;
		        Main.npc[Spawned].velocity.X = Main.rand.Next(-10,10)/10;
		        npc.ai[0] = 20-Main.rand.Next(80);
                customspawn2 += 1f;
		        if (Main.netMode == 2)
		        {
		            NetMessage.SendData(23, -1, -1, null, Spawned, 0f, 0f, 0f, 0);
		        }
	        }
		    if (Main.rand.Next(220)==1) 
            {
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
                float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
                npc.velocity.X = (float) (Math.Cos(rotation) * 14)*-1;
                npc.velocity.Y = (float) (Math.Sin(rotation) * 14)*-1;
			    npc.ai[1] = 1f;
                npc.netUpdate=true;
            }
		    if (Main.rand.Next(200)==1)
            {
			    float num48 = 10f;
			    Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y-100 + (npc.height / 2));
			    float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-20, 0x15);
			    float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-20, 0x15);
			    if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
			    {
				    float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
				    num51 = num48 / num51;
				    speedX *= num51;
				    speedY *= num51;
				    int damage = 40;//(int) (14f * npc.scale);
				    int type = mod.ProjectileType("AntiMatterBlast");//44;//0x37; //14;
				    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				    Main.projectile[num54].timeLeft = 105;
				    Main.projectile[num54].aiStyle=1;
                        Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				    npc.ai[1] = 1f;





		        }
	            npc.netUpdate=true;
            }
		    if (Main.rand.Next(100)==1)
            {
			    float num48 = 13f;
			    Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
			    float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-10, 20);
			    float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-10, 30);
			    if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
			    {
				    float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
				    num51 = num48 / num51;
				    speedX *= num51;
				    speedY *= num51;
				    int damage = 60;
				    int type = mod.ProjectileType("GreatEnergyBall");//44;//0x37; //14;
				    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				    Main.projectile[num54].timeLeft = 100;
				    Main.projectile[num54].aiStyle=1;
                        Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				    customAi1 = 1f;
                }
                npc.netUpdate=true;
            }
		    if (Main.rand.Next(40)==1)
            {
			   float num48 = 8f;
			    Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
			    float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-20, 0x15);
			    float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-20, 0x15);
			    if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
			    {
				    float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
				    num51 = num48 / num51;
				    speedX *= 0;
				    speedY *= 0;
				    int damage = 0;
				    int type = mod.ProjectileType("LightPillarBall");//44;//0x37; //14;
				    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				    Main.projectile[num54].timeLeft = 300;
				    Main.projectile[num54].aiStyle=1;
                        Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				    customAi1 = 1f;
                }
                npc.netUpdate=true;
            }
		    if (Main.rand.Next(200)==1)
            {
			    float num48 = 8f;
			    Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
			    float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-20, 0x15);
			    float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-20, 0x15);
			    if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
			    {
				    float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
				    num51 = num48 / num51;
				    speedX *= num51;
				    speedY *= num51;
				    int damage = 70;//(int) (14f * npc.scale);
				    int type = mod.ProjectileType("BlackBreath");//44;//0x37; //14;
				    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				    Main.projectile[num54].timeLeft = 10;
				    Main.projectile[num54].aiStyle=1;
                        Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				    customAi1 = 1f;
                }
                npc.netUpdate=true;
            }
		    if (Main.rand.Next(150)==1)
            {
			    float num48 = 9f;
			    Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
			    float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-20, 0x15);
			    float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-20, 0x15);
			    if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
			    {
				    float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
				    num51 = num48 / num51;
				    speedX *= num51;
				    speedY *= num51;
				    int damage = 50;//(int) (14f * npc.scale);
				    int type = mod.ProjectileType("Lightning3Ball");//44;//0x37; //14;
				    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				    Main.projectile[num54].timeLeft = 300;
				    Main.projectile[num54].aiStyle=1;
                        Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				    customAi1 = 1f;
                }
                npc.netUpdate=true;
            }
		    if (Main.rand.Next(120)==1)
            {
			    float num48 = 8f;
			    Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y-650 + (npc.height / 2));
			    float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-20, 0x15);
			    float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-20, 0x15);
			    if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
			    {
				    float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
				    num51 = num48 / num51;
				    speedX *= num51;
				    speedY *= num51;
				    int damage = 50;//(int) (14f * npc.scale);
				    int type = mod.ProjectileType("Ice3Ball");//44;//0x37; //14;
				    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				    Main.projectile[num54].timeLeft = 40;
				    Main.projectile[num54].aiStyle=1;
                        Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				    customAi1 = 1f;
                }
                npc.netUpdate=true;
            }
		    if (Main.rand.Next(200)==1)
            {
			   num58 = Projectile.NewProjectile(this.npc.position.X+20,this.npc.position.Y+50,Main.rand.Next(-5,5),Main.rand.Next(-5,5),mod.ProjectileType("PhantomSeeker"),80,0f,Main.myPlayer);
Main.projectile[num58].timeLeft = 400;
Main.projectile[num58].rotation = Main.rand.Next(700)/100f;
Main.projectile[num58].ai[0] = this.npc.target;


                        Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				    customAi1 = 1f;
                
                npc.netUpdate=true;
            }
		    if (Main.rand.Next(650)==1)
            {
			    float num48 = 8f;
			    Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y-400 + (npc.height / 2));
			    float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-20, 0x15);
			    float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-20, 0x15);
			    if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
			    {
				    float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
				    num51 = num48 / num51;
				    speedX *= num51;
				    speedY *= num51;
				    int damage = 80;//(int) (14f * npc.scale);
				    int type = mod.ProjectileType("Lightning4Ball");//44;//0x37; //14;
				    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				    Main.projectile[num54].timeLeft = 300;
				    Main.projectile[num54].aiStyle=1;
                        Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				    customAi1 = 1f;
                }
                npc.netUpdate=true;
            }
		   


		 if (Main.rand.Next(350)==1)
            {
                   float num48 = 8f;
                   Vector2 vector9 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y-520 + (npc.height / 2));
                   float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector9.X) + Main.rand.Next(-20, 0x15);
                   float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector9.Y) + Main.rand.Next(-20, 0x15);
                   if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
                   {
                           float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
                           num51 = num48 / num51;
                           speedX *= num51;
                           speedY *= num51;
                           int damage = 40;//(int) (14f * npc.scale);
                           int type = mod.ProjectileType("Ice4Ball");//44;//0x37; //14;
                           int num54 = Projectile.NewProjectile(vector9.X, vector9.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
                           Main.projectile[num54].timeLeft = 100;
                           Main.projectile[num54].aiStyle=4;
                           Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 25);
                           npc.ai[3] = 0;;
                   }
		npc.netUpdate=true;
                }


		    if (Main.rand.Next(250)==1)
            {
			       num59 = Projectile.NewProjectile(this.npc.position.X+20,this.npc.position.Y+50,Main.rand.Next(-5,5),Main.rand.Next(-5,5),mod.ProjectileType("PhantomSeeker"),80,0f,Main.myPlayer);
Main.projectile[num59].timeLeft = 500;
Main.projectile[num59].rotation = Main.rand.Next(700)/100f;
Main.projectile[num59].ai[0] = this.npc.target;


                        Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				    customAi1 = 1f;
                
                npc.netUpdate=true;
               
            }
        }
        




 if (Main.rand.Next(350)==1)
            {
			    float num48 = 8f;
			    Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
			    float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-20, 0x15);
			    float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-20, 0x15);
			    if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
			    {
				    float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
				    num51 = num48 / num51;
				    speedX *= num51;
				    speedY *= num51;
				    int damage = 60;
				    int type = mod.ProjectileType("IcestormBall");//44;//0x37; //14;
				    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
				    Main.projectile[num54].timeLeft = 0;//was 70
				    Main.projectile[num54].aiStyle=1;
                        Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
				    npc.ai[1] = 1f;
                }
                npc.netUpdate=true;
            }



        if (Main.rand.Next(205)==1)
        {
		    float num48 = 9f;
		    Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
		    float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-20, 0x15);
		    float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-20, 0x15);
		    if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
		    {
			    float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
			    num51 = num48 / num51;
			    speedX *= num51;
			    speedY *= num51;
			    int damage = 60;//(int) (14f * npc.scale);
			    int type = mod.ProjectileType("GreatEnergyBall");//44;//0x37; //14;
			    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
			    Main.projectile[num54].timeLeft = 300;
			    Main.projectile[num54].aiStyle=1;
                    Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
			    customAi1 = 1f;
            }
            npc.netUpdate=true;
        }
	    if (Main.rand.Next(1000)==1)
        {
		    float num48 = 11f;
		    Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
		    float speedX = ((Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)) - vector8.X) + Main.rand.Next(-20, 0x15);
		    float speedY = ((Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)) - vector8.Y) + Main.rand.Next(-20, 0x15);
		    if (((speedX < 0f) && (npc.velocity.X < 0f)) || ((speedX > 0f) && (npc.velocity.X > 0f)))
		    {
			    float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
			    num51 = num48 / num51;
			    speedX *= num51;
			    speedY *= num51;
			    int damage = 0;//(int) (14f * npc.scale);
			    int type = mod.ProjectileType("Gravity4Ball");//44;//0x37; //14;
			    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, speedX, speedY, type, damage, 0f, Main.myPlayer);
			    Main.projectile[num54].timeLeft = 60;
			    Main.projectile[num54].aiStyle=1;
                    Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 0x11);
			    customAi1 = 1f;
            }
            npc.netUpdate=true;
        }
    }

	if ((Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height)))
	{
        npc.noTileCollide = false;
        npc.noGravity = false;
    }
	if ((!Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height)))
	{
        npc.noTileCollide = true;
        npc.noGravity = true;
        npc.velocity.Y = 0f;
        if (npc.position.Y > Main.player[npc.target].position.Y)
        {
            npc.velocity.Y -= 3f;
        }
        if (npc.position.Y < Main.player[npc.target].position.Y)
        {
            npc.velocity.Y += 8f;
        }
    }

    if (Main.player[npc.target].dead)
	{
	    if (npc.timeLeft > 10)
	    {
		    npc.timeLeft = 10;
		    return;
	    }
    }
}     
	



		public override void HitEffect(int hitDirection, double damage)
		{
			
		}

		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = Main.tile[x, y].type;
			return DarkSoulsWorld.downedAttraidies && DarkSouls.NoZoneAllowWater(spawnInfo) && Main.hardMode && !Main.dayTime && !spawnInfo.player.ZoneDungeon && y < Main.rockLayer ? 0.001f : 0f;
			
		
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

				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkSoul"), count);
				
			}
		if (npc.life <= 0)
    {
        Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/EasterlingGore1"), 1f);
		Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/EasterlingGore2"), 1f);
		Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/EasterlingGore3"), 1f);
		Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/EasterlingGore2"), 1f);
		Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/EasterlingGore3"), 1f);
        
    }
	
		}
		

	}
}
		

	
