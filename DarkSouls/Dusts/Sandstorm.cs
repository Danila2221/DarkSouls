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

namespace DarkSouls.Dusts
{
	public class Sandstorm : ModDust
	{
        public override void AI()
        {
            if (projectile.timeLeft > 60)
            {
                projectile.timeLeft = 60;
            }
            if (projectile.ai[0] > 7f)
            {
                float num152 = 1f;
                if (projectile.ai[0] == 8f)
                {
                    num152 = 0.25f;
                }
                else
                {
                    if (projectile.ai[0] == 9f)
                    {
                        num152 = 0.5f;
                    }
                    else
                    {
                        if (projectile.ai[0] == 10f)
                        {
                            num152 = 0.75f;
                        }
                    }
                }
                int spread = 10;
                //float num48 = 12f;
                //float speedX = ((Main.mouseX + Main.screenPosition.X) - (Main.player[projectile.owner].position.X + Main.player[projectile.owner].width * 0.5f))+Main.rand.Next(-spread, spread);
                //float speedY = ((Main.mouseY + Main.screenPosition.Y) - (Main.player[projectile.owner].position.Y + Main.player[projectile.owner].height * 0.5f))+Main.rand.Next(-spread, spread);
                //float num51 = (float) Math.Sqrt((double) ((speedX * speedX) + (speedY * speedY)));
                //num51 = num48 / num51;
                //speedX *= num51;
                //speedY *= num51;
                //if (Main.rand.Next(5) == 0)
                //{
                //	int projectileMini = Projectile.NewProjectile(
                //		(float)projectile.position.X, 
                //		(float)projectile.position.Y, 
                //		(float)speedX, 
                //		(float)speedY, 
                //		"Sand", 
                //		(int)(Main.player[projectile.owner].inventory[Main.player[projectile.owner].selectedItem].damage * Main.player[projectile.owner].magicDamage), Main.player[projectile.owner].inventory[Main.player[projectile.owner].selectedItem].knockBack, Main.player[projectile.owner].whoAmi);
                //	Main.projectile[projectileMini].timeLeft = 60;
                //	Main.projectile[projectileMini].scale = 0.5f;
                //}
                projectile.ai[0] += 1f;
                int num153 = 6;
                if (projectile.type == mod.ProjectileType("Sandstorm").type)
                {
                    num153 = 10;
                }
                if (num153 == 6 || Main.rand.Next(2) == 0)
                {
                    for (int num154 = 0; num154 < 1; num154++)
                    {
                        int num155 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, num153, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1f);
                        int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y - 10), projectile.width, projectile.height, num153, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1f);
                        int dust3 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 10), projectile.width, projectile.height, num153, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1f);
                        if (Main.rand.Next(3) != 0 || (num153 == 75 && Main.rand.Next(2) == 0))
                        {
                            Main.dust[num155].noGravity = true;
                            Main.dust[num155].scale *= 3f;
                            Dust dustnum155 = Main.dust[num155];
                            dustnum155.velocity.X = dustnum155.velocity.X * 2f;
                            Dust dustnum155_2 = Main.dust[num155];
                            dustnum155_2.velocity.Y = dustnum155_2.velocity.Y * 2f;
                            Main.dust[dust2].noGravity = true;
                            Main.dust[dust2].scale *= 3f;
                            Dust dustDust2 = Main.dust[dust2];
                            dustDust2.velocity.X = dustDust2.velocity.X * 2f;
                            Dust dustDust2_2 = Main.dust[dust2];
                            dustDust2_2.velocity.Y = dustDust2_2.velocity.Y * 2f;
                            Main.dust[dust3].noGravity = true;
                            Main.dust[dust3].scale *= 3f;
                            Dust dustDust3 = Main.dust[dust2];
                            dustDust3.velocity.X = dustDust3.velocity.X * 2f;
                            Dust dustDust3_2 = Main.dust[dust3];
                            dustDust3_2.velocity.Y = dustDust3_2.velocity.Y * 2f;
                            if (Main.rand.Next(5) == 0)
                            {
                                int projectileMini2 = Projectile.NewProjectile(
                                    (float)dustnum155.position.X,
                                    (float)dustnum155.position.Y,
                                    (float)dustnum155.velocity.X,
                                    (float)dustnum155.velocity.Y,
                                    "Sand",
                                    (int)(Main.player[projectile.owner].inventory[Main.player[projectile.owner].selectedItem].damage * Main.player[projectile.owner].magicDamage), Main.player[projectile.owner].inventory[Main.player[projectile.owner].selectedItem].knockBack, Main.player[projectile.owner].whoAmi);
                                Main.projectile[projectileMini2].timeLeft = 60;
                                Main.projectile[projectileMini2].scale = 0.5f;
                            }
                            if (Main.rand.Next(5) == 0)
                            {
                                int projectileMini3 = Projectile.NewProjectile(
                                    (float)dustDust2.position.X,
                                    (float)dustDust2.position.Y,
                                    (float)dustDust2.velocity.X,
                                    (float)dustDust2.velocity.Y,
                                    "Sand",
                                    (int)(Main.player[projectile.owner].inventory[Main.player[projectile.owner].selectedItem].damage * Main.player[projectile.owner].magicDamage), Main.player[projectile.owner].inventory[Main.player[projectile.owner].selectedItem].knockBack, Main.player[projectile.owner].whoAmi);
                                Main.projectile[projectileMini3].timeLeft = 60;
                                Main.projectile[projectileMini3].scale = 0.5f;
                            }
                            if (Main.rand.Next(5) == 0)
                            {
                                int projectileMini4 = Projectile.NewProjectile(
                                    (float)dustDust3.position.X,
                                    (float)dustDust3.position.Y,
                                    (float)dustDust3.velocity.X,
                                    (float)dustDust3.velocity.Y,
                                    "Sand",
                                    (int)(Main.player[projectile.owner].inventory[Main.player[projectile.owner].selectedItem].damage * Main.player[projectile.owner].magicDamage), Main.player[projectile.owner].inventory[Main.player[projectile.owner].selectedItem].knockBack, Main.player[projectile.owner].whoAmi);
                                Main.projectile[projectileMini4].timeLeft = 60;
                                Main.projectile[projectileMini4].scale = 0.5f;
                            }
                        }
                        Main.dust[num155].scale *= 1.5f;
                        Dust dust155 = Main.dust[num155];
                        dust155.velocity.X = dust155.velocity.X * 1.2f;
                        Dust dust155_2 = Main.dust[num155];
                        dust155_2.velocity.Y = dust155_2.velocity.Y * 1.2f;
                        Main.dust[num155].scale *= num152;
                        Main.dust[dust2].scale *= 1.5f;
                        Dust dustDust2_3 = Main.dust[dust2];
                        dustDust2_3.velocity.X = dustDust2_3.velocity.X * 1.2f;
                        Dust dustDust2_4 = Main.dust[dust2];
                        dustDust2_4.velocity.Y = dustDust2_4.velocity.Y * 1.2f;
                        Main.dust[dust2].scale *= num152;
                        Main.dust[dust3].scale *= 1.5f;
                        Dust dustDust3_3 = Main.dust[dust3];
                        dustDust3_3.velocity.X = dustDust3_3.velocity.X * 1.2f;
                        Dust dustDust3_4 = Main.dust[dust3];
                        dustDust3_4.velocity.Y = dustDust3_4.velocity.Y * 1.2f;
                        Main.dust[dust3].scale *= num152;
                        if (Main.rand.Next(5) == 0)
                        {
                            int projectileMini5 = Projectile.NewProjectile(
                                (float)dust155.position.X,
                                (float)dust155.position.Y,
                                (float)dust155.velocity.X,
                                (float)dust155.velocity.Y,
                                "Sand",
                                (int)(Main.player[projectile.owner].inventory[Main.player[projectile.owner].selectedItem].damage * Main.player[projectile.owner].magicDamage), Main.player[projectile.owner].inventory[Main.player[projectile.owner].selectedItem].knockBack, Main.player[projectile.owner].whoAmi);
                            Main.projectile[projectileMini5].timeLeft = 60;
                            Main.projectile[projectileMini5].scale = 0.5f;
                        }
                        if (Main.rand.Next(5) == 0)
                        {
                            int projectileMini6 = Projectile.NewProjectile(
                                (float)dustDust2_3.position.X,
                                (float)dustDust2_3.position.Y,
                                (float)dustDust2_3.velocity.X,
                                (float)dustDust2_3.velocity.Y,
                                "Sand",
                                (int)(Main.player[projectile.owner].inventory[Main.player[projectile.owner].selectedItem].damage * Main.player[projectile.owner].magicDamage), Main.player[projectile.owner].inventory[Main.player[projectile.owner].selectedItem].knockBack, Main.player[projectile.owner].whoAmi);
                            Main.projectile[projectileMini6].timeLeft = 60;
                            Main.projectile[projectileMini6].scale = 0.5f;
                        }
                        if (Main.rand.Next(5) == 0)
                        {
                            int projectileMini7 = Projectile.NewProjectile(
                                (float)dustDust3_3.position.X,
                                (float)dustDust3_3.position.Y,
                                (float)dustDust3_3.velocity.X,
                                (float)dustDust3_3.velocity.Y,
                                "Sand",
                                (int)(Main.player[projectile.owner].inventory[Main.player[projectile.owner].selectedItem].damage * Main.player[projectile.owner].magicDamage), Main.player[projectile.owner].inventory[Main.player[projectile.owner].selectedItem].knockBack, Main.player[projectile.owner].whoAmi);
                            Main.projectile[projectileMini7].timeLeft = 60;
                            Main.projectile[projectileMini7].scale = 0.5f;
                        }
                        if (num153 == 75)
                        {
                            Main.dust[num155].velocity += projectile.velocity;
                            if (!Main.dust[num155].noGravity)
                            {
                                Main.dust[num155].velocity *= 0.5f;
                            }
                        }
                    }
                }
            }
            else
            {
                projectile.ai[0] += 1f;
            }
            projectile.rotation += 0.3f * (float)projectile.direction;
            return;
        }
    }
}