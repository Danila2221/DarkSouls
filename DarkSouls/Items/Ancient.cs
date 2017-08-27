using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Items
{
    public class Ancient : ModItem
    {
        public override void SetDefaults()
        {
            item.crit = 2;
            item.maxStack = 1;
            item.autoReuse = true;
            item.UseSound = SoundID.Item34;
            item.mana = 14;
            item.magic = true;
            item.noMelee = true;
            item.damage = 166;
            item.useAnimation = 25;
            item.width = 28;
            item.height = 30;
            item.useStyle = 5;
            item.value = 184000;
            item.rare = 4;
            item.useTurn = true;
            item.shoot = mod.ProjectileType("Sparkle");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Dragon Scale Helmet");
            Tooltip.SetDefault("It is made of razor sharp dragon scales."
                                + "\nThorns Effect");

        }

        public static Vector2[] randomSpread(float speedX, float speedY, int angle, int num)
        {
            var posArray = new Vector2[num];
            float spread = (float)(angle * 0.0180532925);
            float baseSpeed = (float)System.Math.Sqrt(speedX * speedX + speedY * speedY);
            double baseAngle = System.Math.Atan2(speedX, speedY);
            double randomAngle;
            for (int i = 0; i < num; ++i)
            {
                randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * spread;
                posArray[i] = new Vector2(baseSpeed * (float)System.Math.Sin(randomAngle), baseSpeed * (float)System.Math.Cos(randomAngle));
            }
            return (Vector2[])posArray;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2[] speeds = randomSpread(speedX, speedY, 8, 6);
            for (int i = 0; i < 5; ++i)
            {
                Projectile.NewProjectile(position.X, position.Y, speeds[i].X, speeds[i].Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }






        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
