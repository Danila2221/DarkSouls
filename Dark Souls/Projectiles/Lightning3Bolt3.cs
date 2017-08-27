using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
	
	public class Lightning3Bolt3 : ModProjectile
	{
		
public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lightning 3");
			Main.projFrames[projectile.type] = 4;
		}
		public override void SetDefaults()
		{
			projectile.width = 130;
			projectile.height = 164;
			projectile.penetrate = 16;
			projectile.knockBack = 9;
			projectile.timeLeft = 50;
			projectile.alpha = 100;
			projectile.light = 1f;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.magic = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
		}
		public override void AI() 
		{
			projectile.frameCounter++;
			if (projectile.frameCounter > 4)
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