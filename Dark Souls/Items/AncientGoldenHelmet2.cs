using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace DarkSouls.Items
{
    [AutoloadEquip(EquipType.Head)]
    public class AncientGoldenHelmet2 : ModItem
	{
        
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golden Hemlet");
			Tooltip.SetDefault("It is the famous Helmet of the Stars."
								+ "\n+9% Melee speed");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 26;
			item.value = 15000;
			item.rare = 8;
			item.defense = 12;
            
		}

        public override void UpdateEquip(Player player)
        {
            player.meleeSpeed += 0.09f;
        }

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
            return body.type == mod.ItemType("AncientGoldenArmor") && legs.type == mod.ItemType("AncientGoldenGreaves");
		}

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Boosts all critical hits by 8%, +9% melee and ranged damage, +60 mana";
    player.meleeDamage += 0.09f;
	player.rangedDamage += 0.09f;
	player.statManaMax2 += 60;
	player.rangedCrit += 8;
    player.meleeCrit += 8;
    player.magicCrit += 8;
        }
	}
}
