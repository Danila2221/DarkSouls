using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
	public class EffectBuff : ModProjectile
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spell Effect");
            Main.projFrames[projectile.type] = 5;
        }
        public override void SetDefaults()
		{

			projectile.width = 52;
			projectile.height = 44;
			projectile.penetrate = 50;
			//projectile.knockBack = 9;
			//projectile.timeLeft = 100;
			projectile.light = 1f;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.magic = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
            projectile.scale = 1.2f;
			
		}
        #region AI
        public override void AI()
        {
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