using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Items
{
    [AutoloadEquip(EquipType.Body)]
    public class BlueHeroShirt : ModItem
	{

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blue Hero's Outfit");
            Tooltip.SetDefault("Set bonus grants extended breath & swimming skills plus 6% all stats boost"
                + "\n+Also, +3 life regen speed, faster movement & hunter vision while in water");

        }

        public override void SetDefaults()
        {
            
            item.width = 18;
            item.height = 18;
            item.maxStack = 1;
            item.value = 4000;
            item.rare = 2;
            item.defense = 16;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HerosShirt, 1);
            recipe.AddIngredient(ItemID.Flipper, 1);
            recipe.AddIngredient(ItemID.DivingHelmet, 1);
            recipe.AddIngredient(ItemID.MythrilBar, 3);
            recipe.AddIngredient(null, "DarkSoul", 3000);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
        }
    }
}