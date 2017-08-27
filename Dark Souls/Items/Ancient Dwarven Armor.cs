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
	[AutoloadEquip(EquipType.Body)]
	public class AncientDwarvenArmor : ModItem
	{
		public override void SetStaticDefaults()
		{

			DisplayName.SetDefault("Ancient Dwarven Armor Set");
				
		}


		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 12000;
		
			item.defense = 4;
			item.maxStack = 1;
		}

		public override void UpdateEquip(Player player)
		{
			
			
				
    
				
			
		
			
				if(player.statLife <= 80) {
				player.lifeRegen += 6;

				int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 21, (player.velocity.X) + (player.direction * 1), player.velocity.Y, 245, Color.Violet, 1.0f);
				 Main.dust[dust].noGravity = true;

				}
				else { player.lifeRegen += 3;
					}
    
				
			
		
		}
		



		

		


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SilverChainmail, 1);
            recipe.AddIngredient(null, "DarkSoul", 1000);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
		}
	}
}