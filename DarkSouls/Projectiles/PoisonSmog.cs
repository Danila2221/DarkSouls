using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
	public class PoisonSmog : ModProjectile
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Flame");

        }
        public override void SetDefaults()
		{

			projectile.width = 16;
			projectile.height = 16;


			projectile.timeLeft = 1500;

			projectile.friendly = false;
			projectile.hostile = true;
			projectile.magic = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;

		}
        public override void AI()
        {
            projectile.rotation += 0.1f;
    if (Main.rand.Next(4)==0)
    {
    int dust = Dust.NewDust(new Vector2((float) projectile.position.X, (float) projectile.position.Y), projectile.width, projectile.height, 6, 0, 0, 50, Color.Green, 3.0f);
    Main.dust[dust].noGravity = false;
    }
    

    if (projectile.velocity.X <= 4 && projectile.velocity.Y <= 4 && projectile.velocity.X >= -4 && projectile.velocity.Y >= -4)
    {
    float accel = 1f+(Main.rand.Next(10,30)*0.001f);
    projectile.velocity.X *= accel;
    projectile.velocity.Y *= accel;
    }



Rectangle projrec = new Rectangle((int)projectile.position.X+(int)projectile.velocity.X, (int)projectile.position.Y+(int)projectile.velocity.Y, projectile.width, projectile.height);
Rectangle prec = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, (int)Main.player[Main.myPlayer].width,(int)Main.player[Main.myPlayer].height);


        }
        public override void OnHitPlayer(Player player, int damage, bool crit)
        {
                if (Main.rand.Next(6) == 0)
            {
                player.AddBuff(BuffID.Poisoned, 600, false);
               }
               if (Main.rand.Next(6) == 0)
            {
                player.AddBuff(BuffID.Tipsy, 1800, false);
            }
        }

        public override void Kill(int timeLeft)
        {
            if (!projectile.active)
            {
                return;
            }
            projectile.timeLeft = 0;
            {
                int proType = mod.ProjectileType("SuddenDeathStrike");
                int proDamage = 0;
                int proj = Projectile.NewProjectile(projectile.position.X + (float)(projectile.width / 2), projectile.position.Y + (float)(projectile.height - 16), 0, 0, proType, proDamage, 20, projectile.owner);
                Main.projectile[proj].friendly = projectile.friendly;
                Main.projectile[proj].hostile = projectile.hostile;
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
            }
            projectile.active = false;
        }
    }
}