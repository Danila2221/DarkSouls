using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{

    public class Blaze : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blaze");

            Main.npcFrameCount[projectile.type] = 5;
        }

        public override void SetDefaults()
		{

			projectile.width = 86;
			projectile.height = 66;
			projectile.penetrate = 50;
			projectile.knockBack = 9;
			projectile.timeLeft = 100;
			projectile.light = 1f;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.magic = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;

		}
        #region AI
        public override void AI()
        {
            Lighting.AddLight(projectile.Center, 1f, 1f, 1f);
            projectile.frameCounter++;

            if (projectile.frameCounter > 4)
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
            if (projectile.timeLeft > 60)
            {
                projectile.timeLeft = 60;
            }
            projectile.rotation += 0.3f * (float)projectile.direction;
            return;
        }
    }
    #endregion
}