using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
	public class Ice3Icicle : ModProjectile
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice 3");

        }
		public override void SetDefaults()
		{

			projectile.width = 32;
			projectile.height = 88;
			projectile.penetrate = 4;
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
	}
}