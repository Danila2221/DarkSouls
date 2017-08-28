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
    public class BerserkerNightmareP2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BOOM BITCH");     //The English name of the projectile

        }

        public override void SetDefaults()
        {
            projectile.width = 34;               //The width of projectile hitbox
            projectile.height = 34;              //The height of projectile hitbox
            projectile.aiStyle = 19;             //The ai style of the projectile, please reference the source code of Terraria
            projectile.friendly = true;         //Can the projectile deal damage to enemies?
            projectile.hostile = false;         //Can the projectile deal damage to the player?
            projectile.melee = true;           //Is the projectile shoot by a ranged weapon?
            projectile.penetrate = 1;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            projectile.timeLeft = 5400;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
                       //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in)
                     //How much light emit around the projectile
            projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
            projectile.tileCollide = true;          //Can the projectile collide with tiles?
                      //Set to above 0 if you want the projectile to update multiple time in a frame
                       //Act exactly like default Bullet
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

        public override void OnHitNPC(NPC N, int damage, float knockBack, bool crit)
        {
            if (Main.rand.Next(4) == 0)
            {
                N.AddBuff(BuffID.Slow, 300, false);
                N.AddBuff(24, 300, false);
            }
            if (Main.rand.Next(3) == 0)
            { 
            Projectile.NewProjectile(N.position.X + (N.width * 0.5f), N.position.Y -100, 0f, 4f, mod.ProjectileType("FBolt4"), 150, 6, Main.myPlayer);
            
        }
            if (Main.rand.Next(3) == 0)
            {
                
                Projectile.NewProjectile(N.position.X + (N.width * 0.5f), N.position.Y - 100, 0f, 4f, mod.ProjectileType("FGravity4Strike"), 150, 6, Main.myPlayer);
            }
        }



    }

        


    }

