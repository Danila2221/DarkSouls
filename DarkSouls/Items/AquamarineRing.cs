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
    public class AquamarineRing : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aquamarine Ring");
            Tooltip.SetDefault("+5% Magic Damage"
                + "\n+40 Mana");
        }

        public override void SetDefaults()
        {

            item.width = 24;
            item.height = 24;
            item.accessory = true;

            item.value = 10000;
            item.rare = 1;
            item.maxStack = 1;

        }
        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 5;
            player.statManaMax += 40;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SilverBar, 1);
            recipe.AddIngredient(null, "DarkSoul", 2000);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
        }
    }
}
