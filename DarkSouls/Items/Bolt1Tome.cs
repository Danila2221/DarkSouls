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
	public class Bolt1Tome : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bolt 1 Tome");
			Tooltip.SetDefault("A lost beginner's tome."
				+ "\nCan be upgraded.");
		}
		public override void SetDefaults()
		{

			item.width = 28;
			item.height = 30;
            item.maxStack = 1;
            item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 5;
            item.UseSound = SoundID.Item21;
			item.mana = 10;
			item.damage = 9;
			item.noMelee = true;
			item.magic = true;
			item.autoReuse = false;
			item.channel = true;
			item.value = 140;
			item.rare = 2;
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
				Projectile.NewProjectile(position.X,position.Y-20,speedX*.9f,speedY*.9f,type,damage,knockBack,Main.myPlayer,1,mod.ProjectileType("FBolt1"));
			Projectile.NewProjectile(position.X,position.Y,speedX,speedY,type,damage,knockBack,Main.myPlayer,1,mod.ProjectileType("FBolt1"));
			return false;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SpellTome, 1);
			recipe.AddIngredient(null, "DarkSoul", 4000);
			recipe.SetResult(this);
			recipe.AddTile(26);
			recipe.AddRecipe();
		}


	}
}