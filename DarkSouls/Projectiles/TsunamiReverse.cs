using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
	public class TsunamiReverse : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tsunami");
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
		{
			projectile.width = 150;
			projectile.height = 120;
			projectile.penetrate = 50;
			projectile.knockBack = 9;
			projectile.timeLeft = 360;
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
			if (projectile.frame >= 4)
			{
				projectile.Kill();
				return;
			}
		}
	}
}