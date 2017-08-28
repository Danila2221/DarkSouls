using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace OmnirsNosPak.Items.Accessory
{
    [AutoloadEquip(EquipType.Shield)]
    public class GazingShield : ModItem
	{

        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gazing Shield");
            Tooltip.SetDefault("For melee warriors only \n Grants immunity to knockback, plus 20 defense & +4% melee damage. \n Reduces ranged and magic damage by 85%. \n +50% mana cost -10% move speed.");
        }
        public override void SetDefaults()
		{
			
			item.width = 28;
			item.height = 38;
			
			item.value = 30000;
			item.rare = 3;
			item.accessory = true;
			item.defense = 20;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.noKnockback = true;
			player.fireWalk=true;
			player.moveSpeed -= 0.10f;
			player.manaCost += 0.50f;
			player.magicDamage -= 0.85f;
			player.rangedDamage -= 0.85f;
			player.meleeDamage += 0.04f;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBar, 15);
            recipe.AddIngredient(ItemID.SoulofLight, 5);
            recipe.AddIngredient(null, "DarkSoul", 15000);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
        }

    }
}