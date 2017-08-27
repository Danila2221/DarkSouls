using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DarkSouls.Items
{
   	[AutoloadEquip(EquipType.Head)]
    public class AncientGoldenHelmet : ModItem
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golden Hemlet");
			Tooltip.SetDefault("It is the famous Helmet of the Stars."
				+ "\nCan be upgraded with 4000 Dark Souls and 8 Stinger."
				+ "\n+7% Melee speed");
		}
        

		public override void SetDefaults()
		{
           
			item.width = 20;
			item.height = 26;
            item.maxStack = 1;

            item.value = 15000;
			item.rare = 8;
			item.defense = 12;
            
		}

        public override void UpdateEquip(Player player)
        {
            player.meleeSpeed += 0.07f;
        }

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
            return body.type == mod.ItemType("AncientGoldenArmor") && legs.type == mod.ItemType("AncientGoldenGreaves");
		}

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Boosts all critical hits by 6%, +5% melee and ranged damage, +40 mana";
    player.meleeDamage += 0.05f;
	player.rangedDamage += 0.05f;
	player.statManaMax2 += 40;
	player.rangedCrit += 6;
    player.meleeCrit += 6;
    player.magicCrit += 6;
        }
	}
}
