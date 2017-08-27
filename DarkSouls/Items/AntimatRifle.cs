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

namespace DarkSouls.Items
{
    public class AntimatRifle : ModItem
    {
        public override void SetStaticDefaults()
        {
        DisplayName.SetDefault("Antimat Rifle");
        }
        public override void SetDefaults()
        {
            item.damage = 2000;
            item.ranged = true;
            item.width = 78;
            item.height = 26;
            item.useTime = 150;
            item.useAnimation = 150;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 4;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = SoundID.Item36;
            item.autoReuse = true;
            item.shoot = 10; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 20f;
            item.useAmmo = AmmoID.Bullet;
        }
        public override void UseStyle(Player player)
        {
            float backX = 24f; // move the weapon back
            float downY = 0f; // and down
            float cosRot = (float)Math.Cos(player.itemRotation);
            float sinRot = (float)Math.Sin(player.itemRotation);
            //Align
            player.itemLocation.X = player.itemLocation.X - (backX * cosRot * player.direction) - (downY * sinRot * player.gravDir);
            player.itemLocation.Y = player.itemLocation.Y - (backX * sinRot * player.direction) + (downY * cosRot * player.gravDir);
        }

        public bool PreShoot(Player P, Vector2 Pos, Vector2 Velo, int type, int DMG, float KB, int owner)
        {//as usual, ty Yoraiz0r
            if (type == 14) { type = mod.ProjectileType("AntiMaterialRound"); }
            Projectile.NewProjectile(Pos.X, Pos.Y, Velo.X, Velo.Y, type, DMG, KB, owner);
            return false;
        }

    }
}
