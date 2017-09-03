using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
	public class OmnirsEnemySpellPoisonStorm : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Poison Storm");
        }

        public override void SetDefaults()
		{
			projectile.width = 190;
			projectile.height = 190;
			projectile.penetrate = 50;
			projectile.knockBack = 9;
			projectile.timeLeft = 360;
			projectile.alpha = 100;
			projectile.light = 0.8f;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.magic = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			Main.projFrames[projectile.type] = 7;
		}
		public override void AI() 
		{
			projectile.frameCounter++;
			if (projectile.frameCounter > 3)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
			}
			if (projectile.frame >= 7)
			{
				projectile.Kill();
				return;
			}
		}
	}
}