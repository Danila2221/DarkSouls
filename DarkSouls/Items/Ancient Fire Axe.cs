using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;

namespace DarkSouls.Items
{
	public class AncientFireAxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Fire Axe");
			DisplayName.AddTranslation(GameCulture.Russian, "Древний огненный топор");
			Tooltip.SetDefault("The blade hits with a powerful magic flame.\nKnocks back пoes with a force that also sets them ablaze, doing damage over time.");
			Tooltip.AddTranslation(GameCulture.Russian, "Топор поражает мощным магическим пламенем.\nОтбрасывает назад с силой, которая также заставляет врагов пылать, нанося урон с течением времени.");
		}

		public override void SetDefaults()
		{
			
			item.maxStack = 1;
			item.autoReuse = true;
			item.width = 40;
			item.height = 32;
			item.damage = 25;
			item.knockBack = 5;
			item.rare = 3;
			item.value = 110000;
			item.UseSound = SoundID.Item1;
			item.useStyle = 1;
			item.useTime = 25;
			item.useAnimation = 21;
			item.melee = true;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
            if (Main.rand.Next(2) == 0) { //50% chance to occur
		target.AddBuff(24, 360, false); //Light 'em on fire! 
				//24 is for onFire buff, 20 is for poisoned buff
		

		}

        }
		
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldAxe, 1);
            recipe.AddIngredient(null, "DarkSoul", 3000);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
		}


		}
	}
