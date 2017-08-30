using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DarkSouls.Items
{
    public class ArrowofBardP : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arrow of Bard");
            
        }
        public override void SetDefaults()
        {
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.height = 10;
            projectile.penetrate = 2;
            projectile.damage = 500;
            projectile.ranged = true;
            projectile.scale = 1;
            projectile.tileCollide = true;
            projectile.type = -1;
            projectile.width = 5;

        }
        public override void Kill(int timeLeft)
        {
            int num98 = -1;
            if (!projectile.active)
            {
                return;
            }
            projectile.timeLeft = 0;
            {
                Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1);
                for (int i = 0; i < 10; i++)
                {
                    Vector2 arg_92_0 = new Vector2(projectile.position.X, projectile.position.Y);
                    int arg_92_1 = projectile.width;
                    int arg_92_2 = projectile.height;
                    int arg_92_3 = 7;
                    float arg_92_4 = 0f;
                    float arg_92_5 = 0f;
                    int arg_92_6 = 0;
                    Color newColor = default(Color);
                    Dust.NewDust(arg_92_0, arg_92_1, arg_92_2, arg_92_3, arg_92_4, arg_92_5, arg_92_6, newColor, 1f);
                }
            }
            projectile.active = false;
        }
    }
}
