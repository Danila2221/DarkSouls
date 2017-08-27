using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Buffs
{
    public class ArmorDrug : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Armor Drug");
            Description.SetDefault("I feel Protected!");
            Main.debuff[Type] = false;
           
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 13;
        }
        
    }
}

		