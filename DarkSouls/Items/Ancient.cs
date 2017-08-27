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
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Dragon Scale Helmet");
            Tooltip.SetDefault("It is made of razor sharp dragon scales."
                                + "\nThorns Effect");

        }

        public override bool UseItem(Player player)
        {
            int playerID;
            int spread = 10;

            float num48 = 14f;
            float speedX = ((Main.mouseX + Main.screenPosition.X) - (player.position.X + player.width * 0.5f)) + Main.rand.Next(-spread, spread);
            float speedY = ((Main.mouseY + Main.screenPosition.Y) - (player.position.Y + player.height * 0.5f)) + Main.rand.Next(-spread, spread);
            float num51 = (float)Math.Sqrt((double)((speedX * speedX) + (speedY * speedY)));
            num51 = num48 / num51;
            speedX *= num51;
            speedY *= num51;

            if ((player.direction == -1) && ((Main.mouseX + Main.screenPosition.X) > (player.position.X + player.width * 0.5f)))
            {
                player.direction = 1;
            }
            if ((player.direction == 1) && ((Main.mouseX + Main.screenPosition.X) < (player.position.X + player.width * 0.5f)))
            {
                player.direction = -1;
            }

            if (player.direction == 1) player.itemRotation = (float)Math.Atan2((Main.mouseY + Main.screenPosition.Y) - (player.position.Y + player.height * 0.5f), (Main.mouseX + Main.screenPosition.X) - (player.position.X + player.width * 0.5f));
            else player.itemRotation = (float)Math.Atan2((player.position.Y + player.height * 0.5f) - (Main.mouseY + Main.screenPosition.Y), (player.position.X + player.width * 0.5f) - (Main.mouseX + Main.screenPosition.X));


            Projectile.NewProjectile(
            (float)player.position.X + (player.width * 0.5f),
            (float)player.position.Y + (player.height * 0.5f),
            (float)speedX,
            (float)speedY,
            mod.ProjectileType("Smoke"),
            (int)(item.damage * player.magicDamage),
            player.inventory[player.selectedItem].knockBack,
            Main.myPlayer
            );
            return true;
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
