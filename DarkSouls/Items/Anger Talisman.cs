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
	[AutoloadEquip(EquipType.HandsOn)]
	public class AngerTalisman : ModItem
	{
		public override void SetStaticDefaults()
		{
			
			
			Tooltip.SetDefault("Minus 10 Defense\n30% increased damage");
			
		}
		public override void SetDefaults()
		{
			
			item.width = 22;
			item.height = 22;

			item.value = 270000;
			item.rare = 4;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statDefense -= 10;
			player.meleeDamage += 0.3f;
			player.rangedDamage += 0.3f;
			player.magicDamage += 0.3f;
			player.rangedCrit += 50;
			player.meleeCrit += 50;
			player.magicCrit += 50;
		}
	}
}