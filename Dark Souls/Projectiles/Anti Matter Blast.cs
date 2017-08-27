using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
	public class AntiMatterBlast : ModProjectile
	{
		public override void SetStaticDefaults()
		{
   //The recording mode
		}

		public override void SetDefaults()
		{
			projectile.width = 55;               //The width of projectile hitbox
			projectile.height = 55;              //The height of projectile hitbox
			
			projectile.aiStyle = 9;             //The ai style of the projectile, please reference the source code of Terraria

        //Can the projectile deal damage to enemies?
			projectile.hostile = true;         //Can the projectile deal damage to the player?
          //Is the projectile shoot by a ranged weapon?
			projectile.ranged = true;
			projectile.penetrate = 2;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			projectile.timeLeft = 600;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)          //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in)          //How much light emit around the projectile
			projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
			projectile.tileCollide = false;
			          //Can the projectile collide with tiles?

		}

public override void AI()
{
	projectile.rotation++;
	int dust = Dust.NewDust(new Vector2((float) projectile.position.X+10, (float) projectile.position.Y), projectile.width, projectile.height, 6, 0, 0, 200, Color.Red, 1f);
	Main.dust[dust].noGravity = true;

if (projectile.velocity.X <= 10 && projectile.velocity.Y <= 10 && projectile.velocity.X >= -10 && projectile.velocity.Y >= -10)
	{
	projectile.velocity.X *= 1.01f;
	projectile.velocity.Y *= 1.01f;
	}






Rectangle projrec = new Rectangle((int)projectile.position.X+(int)projectile.velocity.X, (int)projectile.position.Y+(int)projectile.velocity.Y, projectile.width, projectile.height);
Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player[Main.myPlayer].width,(int)Main.player[Main.myPlayer].height);



}
public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Main.rand.Next(6) == 0)
			{
				player.AddBuff(BuffID.Confused, 300, true);
			}
			if (Main.rand.Next(6) == 0)
			{
				player.AddBuff(BuffID.Slow, 300, true);
			}
			if (Main.rand.Next(6) == 0)
			{
				player.AddBuff(BuffID.Gravitation, 300, true);
			}
		}





}





		

		
	}

