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
	public class BootsofHaste : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Boots of Haste");
            Tooltip.SetDefault("Adds 20% speed.");
			
		}
		public override void SetDefaults()
		{
			
			item.width = 32;
			item.height = 26;
            item.maxStack = 1;
            item.value = 30000;
			item.rare = 3;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.moveSpeed += 0.2f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HermesBoots, 1);
            recipe.AddIngredient(null, "DarkSoul", 2000);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
        }


    }
}