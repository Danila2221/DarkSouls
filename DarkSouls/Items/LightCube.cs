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
    public class LightCube : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Light Cube");
            Tooltip.SetDefault("Contains the essence of fire"
                + "\nGives off a strong light!");
        }

        public override void SetDefaults()
        {

            item.width = 28;
            item.height = 28;
            item.accessory = true;
            item.value = 60000;
            item.rare = 4;
            item.maxStack = 1;

        }
        public override void UpdateEquip(Player player)
        {

            int i2 = (int)(player.position.X + (float)(player.width / 2) + (float)(8 * player.direction)) / 16;
            int j2 = (int)(player.position.Y + 2f) / 16;
            Lighting.AddLight(i2, j2, 0.92f, 0.8f, 0.65f);



        }
    public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ShadowOrb, 1);

            recipe.AddIngredient(null, "DarkSoul", 200);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
        }
    }
}





