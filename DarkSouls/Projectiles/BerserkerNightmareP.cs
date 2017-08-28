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
    public class BerserkerNightmareP : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BOOM BITCH");
        }

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

        public void DamageNPC(NPC N, ref int damage, ref float knockback)
        {
            if (Main.rand.Next(4) == 0)
            {
                Projectile.NewProjectile(N.position.X + (N.width * 0.5f), N.position.Y - 200, 0f, 4f, mod.ProjectileType("Lightning Bolt"), 35, 6, Main.myPlayer);
                Main.PlaySound(2, (int)N.position.X, (int)N.position.Y, SoundID.Duck);
            }
        }

        
    }
}
