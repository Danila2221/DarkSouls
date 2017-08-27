using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Projectiles
{
	public class AncientDragonLanceP : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lance");
		}

		public override void SetDefaults()
		{
			projectile.aiStyle = 19; 
			projectile.width = 66;
			projectile.height = 66;
			projectile.aiStyle = 19;
			projectile.friendly = true;
			projectile.penetrate = 3;
			projectile.tileCollide = false;
			projectile.scale = 1f;
			projectile.hide = true;
			projectile.ownerHitCheck = false;
			projectile.melee = true;
			projectile.alpha = 0;
			projectile.tileCollide = false;
		}

		


		public override void AI()
        {
            Main.player[projectile.owner].direction = projectile.direction;
            Main.player[projectile.owner].heldProj = projectile.whoAmI;
            Main.player[projectile.owner].itemTime = Main.player[projectile.owner].itemAnimation;
            projectile.position.X = Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2) - (float)(projectile.width / 2);
            projectile.position.Y = Main.player[projectile.owner].position.Y + (float)(Main.player[projectile.owner].height / 2) - (float)(projectile.height / 2);
            projectile.position += projectile.velocity * projectile.ai[0]; if (projectile.ai[0] == 0f)
            {
                projectile.ai[0] = 3f;
                projectile.netUpdate = true;
            }
            if (Main.player[projectile.owner].itemAnimation < Main.player[projectile.owner].itemAnimationMax / 3)
            {
                projectile.ai[0] -= 1.1f;
            }
            else
            {
                projectile.ai[0] += 0.95f;
            }

            if (Main.player[projectile.owner].itemAnimation == 0)
            {
                projectile.Kill();
            }

            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 2.355f;
            if (projectile.spriteDirection == -1)
            {
                projectile.rotation -= 1.57f;
            }
        }
        
		// It appears that for this AI, only the ai0 field is used!

		
		}
	}

