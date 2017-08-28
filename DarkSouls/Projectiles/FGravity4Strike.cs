using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
	public class FGravity4Strike : ModProjectile
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Demi 4");
            Main.projFrames[projectile.type] = 7;

        }
        public override void SetDefaults()
		{

			projectile.width = 90;
			projectile.height = 90;
			projectile.penetrate = 100;
			projectile.knockBack = 9;
			projectile.timeLeft = 200;
			projectile.alpha = 100;
			projectile.light = 1f;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.magic = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
        }
		
	}
}