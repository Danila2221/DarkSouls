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
    public class Vulnerable : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Vulnerable");
			Description.SetDefault("You feel defenseless...");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = false;
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			player.statDefense-=3000;
		}
		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.defense -= 3000;
			if (npc.defense < 0) npc.defense =0;
		}
	}
}

		
