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
	public class BloomShards : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloom Shards");
			Tooltip.SetDefault("Evokes blooming shards of radient light"
				+ "\nClose range");
		}
		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 28;

			item.useTime = 5;
			item.useAnimation = 15;
			item.useStyle = 5;
            item.UseSound = SoundID.Item21;
			item.mana = 3;
			item.damage = 88;
			item.noMelee = true;
			item.magic = true;
			item.autoReuse = true;
			item.channel = true;
			item.value = 20000;
			item.rare = 4;
			item.shootSpeed = 11;
			item.shoot = 10;
		}
         /* ai[0] : The hostility of the projectile.
         *             0 -> use default projectile hostility
         *             1 -> hurt NPCS but not Players/Townies
         *            -1 -> hurt Players/Townies but not NPCs
         *             2 -> hurt BOTH Players/Townies and NPCs
         *             3 -> hurt NEITHER Players/Townies and NPCs (inert projectile)
         */
		
		

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			MPlayer p = (MPlayer)player.GetModPlayer(mod, "MPlayer");
			if(p.dualCast)
			item.useTime = 5/20;

			if(!p.dualCast)
			item.useTime = 5;

			return true;
		}


	}
}