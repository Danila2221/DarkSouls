using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Items
{
    public class BerserkerNightmare : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Berserker Nightmare");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 32;
            item.channel = true;
            item.useAnimation = 44;
            item.useTime = 44;
            item.maxStack = 1;
            item.damage = 100;
            item.knockBack = 12;
            item.scale = 1.1f;
            item.UseSound = SoundID.Item1;
            item.rare = 5;
            item.shootSpeed = 12;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.value = 505000;
            item.melee = true;
            item.shoot = mod.ProjectileType<BerserkerNightmareP>();

        }


    }
}
