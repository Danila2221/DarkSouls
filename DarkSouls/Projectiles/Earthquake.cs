using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
	public class Earthquake : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Earthquake");

            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
		{

			projectile.width = 160;
			projectile.height = 20;
			projectile.penetrate = 50;
			projectile.knockBack = 9;
            //projectile.timeLeft = 200;
            projectile.damage = 150;
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