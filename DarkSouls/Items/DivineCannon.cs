﻿using System.IO;
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

namespace DarkSouls.Items
{
    public class DivineSpark : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Divine Fucking Spark");
            DisplayName.AddTranslation(GameCulture.Russian,"Божественная ебаная искра");
            Tooltip.SetDefault("Freaking huge magical laser");
            Tooltip.AddTranslation(GameCulture.Russian, "Очень большой магический лазер.");
        }
        public override void SetDefaults()
        {
            item.damage = 60;
            item.magic = true;
            item.width = 24;
            item.height = 28;
            item.useTime = 1;
            item.useAnimation = 2;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.maxStack = 1;
            item.value = 10000;
            item.rare = 2;
            item.mana = 3;
            item.autoReuse = true;
            
            item.shootSpeed = 1f;
           
        }


        public override bool UseItem(Player player)
        
        {
            int playerID;
            float n = 0;
            float m = 0;


            if (Main.mouseX + Main.screenPosition.X - player.position.X > 0) player.direction = 1;
            else player.direction = -1;



            float targetrotation = (float)Math.Atan2(((Main.mouseY + Main.screenPosition.Y) - player.position.Y), ((Main.mouseX + Main.screenPosition.X) - player.position.X));

            player.itemRotation = (float)Math.Atan2(((Main.mouseY + Main.screenPosition.Y) - player.position.Y) * player.direction, ((Main.mouseX + Main.screenPosition.X) - player.position.X) * player.direction);

            int damage = 60;//(int) (14f * npc.scale);
            for (int i = 1; i < 20; i++)
            {
                n = (float)Math.Sin(targetrotation) * ((float)i + 0.1f) * 56;
                m = (float)Math.Cos(targetrotation) * ((float)i + 0.1f) * 56;
                int num54 = Projectile.NewProjectile(m + player.position.X + 7, n + player.position.Y + 21, 0, 0, mod.ProjectileType("MasterBuster"), 60, 0f, Main.myPlayer);
                Main.projectile[num54].timeLeft = 2;
                Main.projectile[num54].rotation = (float)Math.Atan2((double)n, (double)m);
            }



            player.velocity.X -= m / 2000f;
            player.velocity.Y -= n / 2000f;

            if (player.velocity.X > 32) player.velocity.X = 32;
            if (player.velocity.X < -32) player.velocity.X = -32;
            if (player.velocity.Y > 32) player.velocity.Y = 32;
            if (player.velocity.Y < -32) player.velocity.Y = -32;



            if (Main.time % 5 < 2) player.inventory[player.selectedItem].mana = 2;
            else player.inventory[player.selectedItem].mana = 0;

            Main.PlaySound(2, -1, -1, SoundID.Duck);
            return true;
        }



    }
}
