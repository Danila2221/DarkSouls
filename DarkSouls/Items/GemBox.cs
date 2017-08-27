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
	public class GemBox : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gem Box");
			Tooltip.SetDefault("Dual casts a spell.");
		}

		public override void SetDefaults()
		{

			item.width = 32;
			item.height = 26;
            item.maxStack = 1;
            item.value = 800000;
			item.rare = 5;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			MPlayer p = (MPlayer)player.GetModPlayer(mod, "MPlayer");
			p.dualCast = true;
		}
	}
}