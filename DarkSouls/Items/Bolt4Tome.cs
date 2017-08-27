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
	public class Bolt4Tome : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bolt 4 Tome");
			Tooltip.SetDefault("A lost legendary tome. You command the forces of the sky."
				+ "\nOnly the most powerful mages will be able to cast this spell.");
		}
		public override void SetDefaults()
		{
			
			item.width = 28;
			item.height = 30;
            item.maxStack = 1;
            item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 5;
            item.UseSound = SoundID.Item21;
            item.mana = 40;
			item.damage = 100;
			item.noMelee = true;
			item.magic = true;
			item.autoReuse = false;
			item.channel = true;
			item.value = 100000;
			item.rare = 4;
			item.shoot = mod.ProjectileType("FBoltBall");
			item.shootSpeed = 6;
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
				Projectile.NewProjectile(position.X,position.Y-20,speedX*.9f,speedY*.9f,type,damage,knockBack,Main.myPlayer,1,mod.ProjectileType("FBolt4"));
			Projectile.NewProjectile(position.X,position.Y,speedX,speedY,type,damage,knockBack,Main.myPlayer,1,mod.ProjectileType("FBolt4"));
			return false;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Bolt3Tome", 1);
			recipe.AddIngredient(null, "DarkSoul", 85000);
			recipe.SetResult(this);
			recipe.AddTile(26);
			recipe.AddRecipe();
		}

	}
}