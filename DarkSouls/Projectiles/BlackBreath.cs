using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
	public class BlackBreath : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Black Breath");
		}

		public override void SetDefaults()
		{

			projectile.width = 18;
			projectile.height = 38;
			//projectile.damage = 100;
			projectile.penetrate = 50;
			projectile.light = -1f;
			projectile.timeLeft=600;
			projectile.aiStyle = 23;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.magic = true;
			projectile.tileCollide = false;
            projectile.alpha = 150;
		}
	}
}