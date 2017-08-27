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
    public class AntiMaterialRound : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Anti Material Bullet");     //The English name of the projectile
            
        }

        public override void SetDefaults()
        {
            projectile.width = 8;               //The width of projectile hitbox
            projectile.height = 8;              //The height of projectile hitbox
            projectile.aiStyle = 1;             //The ai style of the projectile, please reference the source code of Terraria
            projectile.friendly = true;         //Can the projectile deal damage to enemies?
            projectile.hostile = false;         //Can the projectile deal damage to the player?
            projectile.ranged = true;           //Is the projectile shoot by a ranged weapon?
            projectile.penetrate = 5;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            projectile.timeLeft = 600;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            projectile.alpha = 255;             //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in)
            projectile.light = 0.5f;            //How much light emit around the projectile
            projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
            projectile.tileCollide = true;          //Can the projectile collide with tiles?
            projectile.extraUpdates = 1;            //Set to above 0 if you want the projectile to update multiple time in a frame
            aiType = ProjectileID.Bullet;           //Act exactly like default Bullet
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            damage = target.defense + projectile.damage;
            if (projectile.penetrate <= 0)
            {
                projectile.Kill();
            }
        }
        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            damage = target.statDefense + projectile.damage;
            if (projectile.penetrate <= 0)
            {
                projectile.Kill();
            }
        }
        bool reposition = true;
        float sinwaveCounter = -1.4f;
        public override void AI()
        {
            if (reposition)
            {
                projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

                projectile.velocity.X *= 0.45f;
                projectile.velocity.Y *= 0.45f;

                reposition = false;
                projectile.alpha = 255;
            }
            projectile.alpha -= 51;

            for (int i = 0; i < 10; i++)
            {
                bool bulletHit = false;
                Rectangle myBox = new Rectangle((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height);
                foreach (NPC targetNPC in Main.npc)
                {
                    if (targetNPC.townNPC || bulletHit) { continue; }
                    Rectangle npcBox = new Rectangle((int)targetNPC.position.X, (int)targetNPC.position.Y, targetNPC.width, targetNPC.height);

                    if (myBox.Intersects(npcBox) && !bulletHit && targetNPC.life > 0 && !targetNPC.dontTakeDamage)
                    {//on collide
                        bulletHit = true;
                        npcBox = Rectangle.Empty;
                        break;
                    }
                    npcBox = Rectangle.Empty;
                }

                //dust fx
                if (i % 2 == 0)
                {
                    if (sinwaveCounter > 0)
                    {//tracer
                        Vector2 DustPos = projectile.position;

                        int DustIndex = Dust.NewDust(DustPos, 0, 0, 6, 0, 0, 100, default(Color), 1.7f);
                        Main.dust[DustIndex].noGravity = true;
                        Main.dust[DustIndex].velocity = new Vector2(0, 0);
                    }
                    else
                    {//fire effect
                        Vector2 DustPos = projectile.position;
                        int DustWidth = projectile.width;
                        int DustHeight = projectile.height;

                        Dust.NewDust(DustPos, DustWidth, DustHeight, 6, 0, 0, 100, default(Color), 1.1f);
                        int DustIndex = Dust.NewDust(DustPos, DustWidth, DustHeight, 31, 0, 0, 100, default(Color), 3f);
                        Main.dust[DustIndex].noGravity = true;
                    }
                }
                if (sinwaveCounter > 0)
                {
                    //sine wave top
                    Vector2 DustTopPos = projectile.position +
                        new Vector2((float)(15 * Math.Cos(sinwaveCounter) * Math.Cos(projectile.rotation)),
                        (float)(15 * Math.Sin(sinwaveCounter) * Math.Sin(projectile.rotation)));

                    int sineTop = Dust.NewDust(DustTopPos, 0, 0, 60, 0, 0, 100, default(Color), 1f);
                    Main.dust[sineTop].noGravity = true;
                    Main.dust[sineTop].velocity = new Vector2(0, 0);
                    //sine wave bottom
                    Vector2 DustBotPos = projectile.position +
                        new Vector2((float)(-15 * Math.Cos(sinwaveCounter) * Math.Cos(projectile.rotation)),
                        (float)(-15 * Math.Sin(sinwaveCounter) * Math.Sin(projectile.rotation)));

                    int sineBot = Dust.NewDust(DustBotPos, 0, 0, 60, 0, 0, 100, default(Color), 1f);
                    Main.dust[sineBot].noGravity = true;
                    Main.dust[sineBot].velocity = new Vector2(0, 0);
                }
                sinwaveCounter += 0.2f;

                if (bulletHit)
                {
                    break;
                }

                Vector2 velo2 = Collision.TileCollision(projectile.position, projectile.velocity, projectile.width, projectile.height, false, false);
                if (projectile.velocity != velo2)
                {
                    projectile.position += velo2;
                    projectile.velocity *= new Vector2(0.1f, 0.1f);

                    Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
                    projectile.Kill();
                }

                projectile.position += projectile.velocity;
            }

            Lighting.AddLight((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), 0.9f, 0.2f, 0.1f);
        }

        public void PreKill()
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
        }


    }
}
