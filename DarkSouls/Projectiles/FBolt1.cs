using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
    class FBolt1 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bolt ");
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            projectile.width = 60;
			projectile.height = 110;
            projectile.scale = 1;
            projectile.magic = true;
            projectile.penetrate = 4;
			projectile.timeLeft = 25;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.friendly = true;
			drawOffsetX = 15;
			drawOriginOffsetY = 10;
        }
        public override void AI()
        {
            Lighting.AddLight(projectile.Center, 1f, 1f, 1f);
            projectile.frameCounter++;

            if (projectile.frameCounter > 4)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 4)
            {
                projectile.Kill();
                projectile.frame = 0;
            }
        }
    }
}
