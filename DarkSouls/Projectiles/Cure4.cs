using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OmnirsNosPak.Projectiles.Enemy
{
	public class Cure4 : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cure 4");
            Main.projFrames[projectile.type] = 5;
        }
        public override void SetDefaults()
		{
			
			projectile.width = 92;
			projectile.height = 92;
			projectile.penetrate = 50;
			//projectile.knockBack = 9;
			//projectile.timeLeft = 100;
			projectile.light = 1f;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.magic = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
            projectile.scale = 2;
			Main.projFrames[projectile.type] = 5;
		}
        #region AI
        public override void AI()
        {
            Lighting.AddLight(projectile.Center, 1f, 1f, 1f);
            projectile.frameCounter++;

            if (projectile.frameCounter > 3)
            {
                //Main.NewText("Testframe.", 175, 75, 255);
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 5)
            {
                projectile.Kill();
                projectile.frame = 0;
                return;
            }
        }
    }
    #endregion
}