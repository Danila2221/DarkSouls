using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace DarkSouls.Items
{
    public class MagicPlateArmor : ModItem
	{

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magic Plate Armor");
            Tooltip.SetDefault("Fueled by a magical gem in the chest."
                + "+20 % melee speed, -20 % mana cost, 20 % not to consume ammo");

        }

        public override void SetDefaults()
        {
            
            item.width = 20;
            item.height = 20;
            
            item.value = 4000000;
            item.rare = 9;
            item.defense = 15;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeSpeed += 0.20f;
            player.manaCost -= 0.20f;
            player.ammoCost80 = true;
        }
	}
}