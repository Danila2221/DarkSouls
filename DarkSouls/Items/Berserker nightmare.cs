using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using DarkSouls.Projectiles;

namespace DarkSouls.Items
{
    public class BerserkerNightmare : ModItem
    {
        
        public override void SetDefaults()
        {
            item.maxStack = 1;
            item.damage = 100;
            item.useStyle = 5;
            item.useAnimation = 44;
            item.useTime = 44;
            item.shootSpeed = 8f;
            item.knockBack = 9.5f;
            item.width = 32;
            item.height = 32;
            item.scale = 1f;
            item.rare = 5;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType<BerserkerNightmareP>();
            item.value = 27000;
            item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
            item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
            item.melee = true;
            item.autoReuse = true; // Most spears don't autoReuse, but it's possible
        }


    }
}
