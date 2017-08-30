using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Items
{
    public class FlameoftheAbyss : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flame of the Abyss");
            Tooltip.SetDefault("Dropped from a fallen soul that has traveled through the abyss.");
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.rare = 3;
            item.maxStack = 250;
            item.scale = 1;
            item.value = 50000;
        }
    }
}
