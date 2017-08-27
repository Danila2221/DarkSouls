using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
    class FBolt3 : ModProjectile
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bolt 3");
			Main.projFrames[projectile.type] = 4;
		}
        public override void SetDefaults()
        {
			
			
			projectile.width = 130;
			projectile.height = 164;
            projectile.scale = 1;
            projectile.magic = true;
            projectile.penetrate = 16;
			projectile.timeLeft = 25;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.friendly = true;
			drawOffsetX = 15;
			drawOriginOffsetY = 10;
        }
        public override void AI()
        {
            Lighting.AddLight(projectile.Center, 1f, 1f, 1f);
            projectile.frameCounter++;

            if (projectile.frameCounter > 4)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 4)
            {
                projectile.Kill();
                projectile.frame = 0;
            }
        }
		public override void Kill(int timeLeft) 
		{
            if (Main.netMode != 2 && projectile.ai[0] <= 2)
            {
				int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("FBolt3"), projectile.damage, 8f, projectile.owner,projectile.ai[0]+1);
				Main.projectile[proj].friendly = projectile.friendly;
				Main.projectile[proj].hostile = projectile.hostile;
            }
        }
		public override bool PreDraw(SpriteBatch sb, Color lc)
		{
			Projectile p = projectile;
			Texture2D tex = Main.projectileTexture[p.type];
			Texture2D Bolt2 = ModLoader.GetTexture("DarkSouls/Projectiles/FBolt3_2");
			Texture2D Bolt3 = ModLoader.GetTexture("DarkSouls/Projectiles/FBolt3_3");
			Vector2 drawPos = p.Center + Vector2.UnitY * p.gfxOffY - Main.screenPosition;

			int frameH = tex.Height / Main.projFrames[p.type];
			int frameY = frameH * p.frame;
			Vector2 origin = tex.Size() / 2f;
			origin.Y /= Main.projFrames[p.type];
			SpriteEffects fx = (p.spriteDirection == 1) ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			
			if(projectile.ai[0] == 1)
			{
				sb.Draw(Bolt2, drawPos, new Rectangle(0, frameY, tex.Width, frameH), lc, p.rotation, origin, p.scale, fx, 0f);
				return false;
			}
			if(projectile.ai[0] == 2)
			{
				sb.Draw(Bolt3, drawPos, new Rectangle(0, frameY, tex.Width, frameH), lc, p.rotation, origin, p.scale, fx, 0f);
				return false;
			}
			return true;
		}
    }
}
