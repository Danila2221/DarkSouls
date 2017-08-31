using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
	public class FBoltBall : ModProjectile
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bolt Ball");
           
        }
		public override void SetDefaults()
		{
            projectile.aiStyle = 0;
			projectile.width = 16;
			projectile.height = 16;
			//projectile.aiStyle = 9;
			projectile.penetrate = 1;
			projectile.tileCollide = true;
			projectile.magic = true;
		}
         /* hostility : The hostility of the projectile.
         *             0 -> use default projectile hostility
         *             1 -> hurt NPCS but not Players/Townies
         *            -1 -> hurt Players/Townies but not NPCs
         *             2 -> hurt BOTH Players/Townies and NPCs
         *             3 -> hurt NEITHER Players/Townies and NPCs (inert projectile)
         */
		bool once = true;
        Vector2[] lastpos = new Vector2[20];
        int lastposindex = 0;
		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			Lighting.AddLight(projectile.Center, 1f, 1f, 1f);
            if (projectile.ai[0] != 0 && once)
            {
				projectile.friendly = (projectile.ai[0] == 1 || projectile.ai[0] == 2);
				projectile.hostile = (projectile.ai[0] == -1 || projectile.ai[0] == 2);
				projectile.ai[0] = 0;
				once = false;
			}
			
            if (projectile.soundDelay == 0 && Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y) > 2f)
            {
                projectile.soundDelay = 10;
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 9);
            }
			int dust = Dust.NewDust(projectile.Center, projectile.width, projectile.height, 15, 0, 0, 100, default(Color), 2f);
			Dust d = Main.dust[dust];
			d.velocity *= 0.3f;
			d.position.X = projectile.Center.X + 4f + (float)Main.rand.Next(-4, 5);
			d.position.Y = projectile.Center.Y + (float)Main.rand.Next(-4, 5);
			d.noGravity = true;
            if (Main.myPlayer == projectile.owner && projectile.friendly && projectile.ai[0] == 0f)
            {
				float vX = (float)Main.mouseX + Main.screenPosition.X - projectile.Center.X;
				float vY = (float)Main.mouseY + Main.screenPosition.Y - projectile.Center.Y;
				float num51 = (float)Math.Sqrt((double)(vX * vX + vY * vY));
                if (player.channel)
				{
					num51 = 12 / num51;
					vX *= num51;
					vY *= num51;
					int num52 = (int)(vX * 1000f);
					int num53 = (int)(projectile.velocity.X * 1000f);
					int num54 = (int)(vY * 1000f);
					int num55 = (int)(projectile.velocity.Y * 1000f);
					if (num52 != num53 || num54 != num55)
					{
						projectile.netUpdate = true;
					}
					projectile.velocity.X = vX;
					projectile.velocity.Y = vY;
                }
                else projectile.ai[0] = 1f;
            }
            if (projectile.velocity.X != 0f || projectile.velocity.Y != 0f)
            {
                projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) - 2.355f;
            }
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
                return true;
            }
			return true;
		}
		public override bool PreKill(int timeLeft)
		{
            if (Main.netMode != 2)
            {
				int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, (int)projectile.ai[1], projectile.damage, 3f, projectile.owner);
				Main.projectile[proj].friendly = projectile.friendly;
				Main.projectile[proj].hostile = projectile.hostile;
            }
            return true; 
		}
		public override void Kill(int timeLeft)
		{
            projectile.active = false;
		}
	}
}