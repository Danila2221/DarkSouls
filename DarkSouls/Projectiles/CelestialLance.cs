using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace DarkSouls.Projectiles
{
    public class CelestialLanceP : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.aiStyle = 19;
            projectile.width = 34;
            projectile.height = 34;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.tileCollide = false;
            projectile.scale = 1f;
            projectile.hide = true;
            projectile.ownerHitCheck = false;
            projectile.melee = true;
            projectile.alpha = 0;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            Projectile.NewProjectile(target.position.X - 0, target.position.Y - 100, 0, 5, ProjectileID.FallingStar, 500, 1f, Main.myPlayer);
        }
        public float movementFactor // Change this value to alter how fast the spear moves
        {
            get { return projectile.ai[0]; }
            set { projectile.ai[0] = value; }
        }

        public override void AI()
        {
            Lighting.AddLight((int)((projectile.position.X + (float)projectile.width) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f), 0.8f, 0.7f, 0.1f);
            Player projOwner = Main.player[projectile.owner];
            // Here we set some of the projectile's owner properties, such as held item and itemtime, along with projectile direction and position based on the player
            Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
            projectile.direction = projOwner.direction;
            projOwner.heldProj = projectile.whoAmI;
            projOwner.itemTime = projOwner.itemAnimation;
            projectile.position.X = ownerMountedCenter.X - (float)(projectile.width / 2);
            projectile.position.Y = ownerMountedCenter.Y - (float)(projectile.height / 2);
            // As long as the player isn't frozen, the spear can move
            if (!projOwner.frozen)
            {
                if (movementFactor == 0f) // When initially thrown out, the ai0 will be 0f
                {
                    movementFactor = 3f; // Make sure the spear moves forward when initially thrown out
                    projectile.netUpdate = true; // Make sure to netUpdate this spear
                }
                if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3) // Somewhere along the item animation, make sure the spear moves back
                {
                    movementFactor -= 2.4f;
                }
                else // Otherwise, increase the movement factor
                {
                    movementFactor += 2.1f;
                }
            }
            // Change the spear position based off of the velocity and the movementFactor
            projectile.position += projectile.velocity * movementFactor;
            // When we reach the end of the animation, we can kill the spear projectile
            if (projOwner.itemAnimation == 0)
            {
                projectile.Kill();
            }
            // Apply proper rotation, with an offset of 135 degrees due to the sprite's rotation, notice the usage of MathHelper, use this class!
            // MathHelper.ToRadians(xx degrees here)
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + MathHelper.ToRadians(135f);
            // Offset by 90 degrees here
            if (projectile.spriteDirection == -1)
            {
                projectile.rotation -= MathHelper.ToRadians(90f);
            }

            // These dusts are added later, for the 'ExampleMod' effect
            if (Main.rand.Next(3) == 0)
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, ProjectileID.Sunfury, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, Color.LightYellow, 1.2f);
                Main.dust[dustIndex].velocity += projectile.velocity * 0.3f;
                Main.dust[dustIndex].velocity *= 0.2f;
                Main.dust[dustIndex].noGravity = true;
            }
            if (Main.rand.Next(4) == 0)
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, ProjectileID.Sunfury, 0f, 0f, 100, Color.LightYellow, 0.3f);
                Main.dust[dustIndex].velocity += projectile.velocity * 0.5f;
                Main.dust[dustIndex].velocity *= 0.5f;
                Main.dust[dustIndex].noGravity = true;
                return;
            }
        }
    }
}