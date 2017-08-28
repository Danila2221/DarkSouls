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
	public class BarrierTome : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Barrier Tome");
            Tooltip.SetDefault("A lost tome for artisans."
                + "\nCasts Barrier on the wearer, which adds 20 defense for 20 seconds."
                + "\nDoes not stack with other Barrier spells.");
        }
        public override void SetDefaults()
		{
			
			item.width = 34;
			item.height = 10;

			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 5;
            item.UseSound = SoundID.Item21;
            item.mana = 20;
			item.noMelee = true;
			item.magic = true;
			item.value = 42000;
			item.rare = 4;
			item.buffTime = 1200;
			item.buffType = mod.BuffType("Barrier");
		}
		//public override bool CanUseItem(Player player)
		//{
		//	MPlayer p = (MPlayer)player.GetModPlayer(mod, "MPlayer");
		//	for(int i = 0; i < 22; i++)
		//	{
		//		if (player.buffType[i] == mod.BuffType("OmnirsBarrier") && p.protect > 8) return false;
		//	}
		//	p.protect = 8;
		//	return true;
		//}
	}
}