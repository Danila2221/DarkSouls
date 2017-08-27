using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
	public class DragonBreath : ModProjectile
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon Breath");
            
        }
        public override void SetDefaults()
		{
            projectile.aiStyle = 23;
            projectile.penetrate = 3;
            projectile.timeLeft = 3600;
			projectile.width = 6;
			projectile.height = 6;
			projectile.damage = 60;
			//projectile.knockBack = 9;
			//projectile.timeLeft = 100;
			projectile.light = 1f;
			projectile.friendly = false;
			projectile.hostile = true;
		
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
            projectile.scale = 1.2f;
			
		}
        
        
    }
   
}