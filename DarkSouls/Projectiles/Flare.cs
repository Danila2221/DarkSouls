using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSols.Projectiles
{
	public class Flare : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flare");

            Main.npcFrameCount[projectile.type] = 10;
        }
        public override void SetDefaults()
		{
			projectile.width = 160;
			projectile.height = 160;
			projectile.penetrate = 50;
			projectile.knockBack = 9;
			projectile.timeLeft = 200;
			projectile.alpha = 100;
			projectile.light = 1f;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.magic = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
		}
		public override void AI() 
		{
			projectile.frameCounter++;
			if (projectile.frameCounter > 3)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
			}
			if (projectile.frame >= 10)
			{
				projectile.Kill();
				return;
			}
		}
	}
}