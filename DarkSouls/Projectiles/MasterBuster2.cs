using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using System;
using DarkSouls;

namespace DarkSouls.Projectiles
{
    public class MasterBuster2 : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 59;
            projectile.height = 59;
            projectile.penetrate = 99999999;
            projectile.aiStyle = -1;
            projectile.timeLeft = 2000;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;

        }
        public override void AI()
        {
            
            this.projectile.alpha = 0;


            if (Main.rand.Next(5) < 1)
            {
                
                int dust = Dust.NewDust(this.projectile.position, 64, 0, 45, Main.rand.Next(10) - 5, Main.rand.Next(10) - 5, 255, Color.Blue, 10.0f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].rotation = this.projectile.rotation;
            }



        }

    }
}
