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
    public class BerserkerNightmare2 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Berserker Nightmare Thunder");
            Tooltip.SetDefault("Weapon of the gods"
                + "\nNo one can resist you");
        }
        public override void SetDefaults()
        {
            
            item.maxStack = 1;
            item.damage = 250;
            item.useStyle = 5;
            item.useAnimation = 60;
            item.useTime = 60;
            item.shootSpeed = 60;
            item.knockBack = 9.5f;
            item.width = 32;
            item.height = 32;
            item.scale = 1f;
            item.rare = 11;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType<BerserkerNightmareP2>();
            item.value = 27000;
            item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
            item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
            item.melee = true;
            item.autoReuse = true; // Most spears don't autoReuse, but it's possible
        }
        

    }
}
