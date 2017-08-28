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
    [AutoloadEquip(EquipType.Shield)]
    public class BeholderShield : ModItem
	{

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Beholder Shield");
            Tooltip.SetDefault("For melee warriors only \n Grants immunity to knockback, plus 40 defense & +6% melee damage. \n Reduces ranged and magic damage by 150%. \n +70% mana cost -15% move speed.")
        }

        public override void SetDefaults()
		{
			
			item.width = 28;
			item.height = 38;
		
			item.value = 30000;
			item.rare = 3;
			item.accessory = true;
			item.defense = 40;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.noKnockback = true;
			player.fireWalk=true;
			player.moveSpeed -= 0.15f;
			player.manaCost += 0.70f;
			player.magicDamage -= 1.5f;
			player.rangedDamage -= 1.5f;
			player.meleeDamage += 0.06f;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GazingShield", 1);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(null, "DarkSoul", 25000);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
        }
    }

}
}