using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
    public class BerserkerNightmareP : ModProjectile
    {
        

        public override void SetDefaults()
        {
            projectile.aiStyle = 15;
            projectile.width = 34;
            projectile.height = 34;
            projectile.scale = 0.8f;
            projectile.type = -1;
            projectile.penetrate = -1;
            projectile.timeLeft = 5400;
            projectile.friendly = true;
            projectile.tileCollide = true;
            projectile.melee = true;
            projectile.extraUpdates = 1;  
        }

        public override void AI()
        {
            if (Main.rand.Next(2) == 0)
            {
                Color color = new Color();
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 58, 0f, 0f, 80, color, 1.5f);
                int dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 36, 0f, 0f, 80, color, 1.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust2].noGravity = true;
            }

        }
        
        
    }
}
