using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Items
{
    [AutoloadEquip(EquipType.Body)]
    public class BlackBeltArmor : ModItem
	{

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Black Belt Set");
            Tooltip.SetDefault("Adds Double Jump & Jump Boost Skills"
                + "\nYou are a master of the zen arts, at one with the Tao");

        }

        public override void SetDefaults()
        {
            
            item.width = 18;
            item.height = 18;
            item.maxStack = 1;
            item.value = 4000;
            item.rare = 3;
            item.defense = 3;
        }

        public override void UpdateEquip(Player player)
        {
            player.dJumpEffectCloud = true;
            player.jumpBoost = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBreastplate, 1);
            recipe.AddIngredient(null, "DarkSoul", 3000);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
        }
    }
}