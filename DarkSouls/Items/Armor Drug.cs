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
using DarkSouls;

namespace DarkSouls.Items
{
    public class ArmorDrug : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Armor Drug");
            Tooltip.SetDefault("Increases Defense by 13 for 3 minutes.");
        }

        public override void SetDefaults()
        {

            item.width = 14;
            item.height = 24;
            item.useStyle = 2;
            item.useAnimation = 17;
            item.useTime = 17;
            item.maxStack = 30;
            item.consumable = true;
            item.useTurn = true;
            item.buffTime = 10800;

            item.value = 300000;
            item.rare = 1;
            item.maxStack = 1;

        }
        public override bool UseItem(Player player)
        {
            player.AddBuff(mod.BuffType("ArmorDrug"), 10800, false);
            return true;
        }
            
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddIngredient(ItemID.Sapphire, 5);
            recipe.AddIngredient(ItemID.SoulofNight, 4);
            recipe.SetResult(this);
            recipe.AddTile(13);
            recipe.AddRecipe();
        }
    }
}
