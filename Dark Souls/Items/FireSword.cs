using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
namespace DarkSouls.Items
{
	public class FireSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Fire Sword");
			DisplayName.AddTranslation(GameCulture.Russian, "Древний огненный меч");
			Tooltip.SetDefault("The blade is a magic flame, slicing quickly.\nWill set enemies ablaze and do damage over time.");
			Tooltip.AddTranslation(GameCulture.Russian, "Меч это как магическое пламя, быстро режет.\nЗаставит врагов пылать, нанося урон с течением времени.");
		}
		public override void SetDefaults()
		{

			item.width = 32;
			item.height = 32;
			item.damage = 22;
			item.knockBack = 5.5f;
			item.rare = 2;
			item.value = 100000;
      		item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.useStyle = 1;
			item.useTime = 15;
			item.useAnimation = 21;
			item.melee = true;
            item.scale = 1.05f;
		}
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (Main.rand.Next(2) == 0)
            {
                target.AddBuff(24, 360, false);
            }
        }
    	public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldBroadsword, 1);
            recipe.AddIngredient(null, "DarkSoul", 3000);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
		}

    }
}