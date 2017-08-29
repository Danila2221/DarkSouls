using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Items
{
    [AutoloadEquip(EquipType.Legs)]
    public class BlackBeltGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Black Belt Gi Pants");
            Tooltip.SetDefault("+30% Move Speed");
        }

        public override void SetDefaults()
        {
            
            item.width = 18;
            item.height = 18;

            item.maxStack = 1;
            item.value = 5000;
            item.rare = 3;
            item.defense = 2;
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.30f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltLeggings, 1);
            recipe.AddIngredient(null, "DarkSoul", 3000);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
        }

    }
}