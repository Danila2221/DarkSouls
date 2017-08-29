using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Items
{
    [AutoloadEquip(EquipType.Head)]
    public class BlackBeltHelmet : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Black Belt Set");
            Tooltip.SetDefault("You are a master of the zen arts, at one with the Tao"
                + "\nA treasure from ancient Plains of Havoc."
                + "\nAdds improved vision at night");
        }

		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 12;
            item.maxStack = 1;

            item.value = 8000;
			item.rare = 3;
			item.defense = 2;
            
		}

        public override void UpdateEquip(Player player)
        {
            player.nightVision = true;
        }

        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        
            
        
		{
            return body.type == mod.ItemType("BlackBeltArmor") && legs.type == mod.ItemType("BlackBeltGreaves");
		}

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "+20% Melee damage, +20% Melee Speed, Rapid Life Regeneration, +7% Melee Crit";
            player.meleeSpeed += 0.20f;
            player.meleeDamage += 0.20f;
            player.meleeCrit += 7;
            player.lifeRegen += 13;
            
        }
	   public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltHelmet, 1);
            recipe.AddIngredient(null, "DarkSoul", 3000);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
        }

    }
}