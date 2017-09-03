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
using Terraria;
using DarkSouls;

namespace DarkSouls.Items
{
    public class BlueTearstoneRing2 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blue Tearstone Ring 2");
            Tooltip.SetDefault("The rare gem called tearstone has the uncanny ability to sense imminent death. "
                + "\nThis enchanted blue tearstone from Catarina boosts the defence of its wearer by 85 when in danger."
                + "\nOtherwise, the ring gifts the wearer a normal +30 defense boost."
                + "\nWhile worn, melee damage is reduced by 200%, making it a ring"
                + "\nonly suited to mages and other ranged classes. ");

        }
        public override void SetDefaults()
        {
            item.stack = 1;
            item.accessory = true;
            item.height = 28;
            item.maxStack = 1;
            item.rare = 5;
            item.scale = 1;
            item.value = 270000;
            item.width = 28;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.statLife <= 100)

            {
                player.statDefense += 85;
                player.meleeCrit -= 50;
                player.meleeDamage -= 2f;
            }

            else

            {
                player.statDefense += 30;
                player.meleeCrit -= 50;
                player.meleeDamage -= 2f;
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DarkSoul", 40000);
            recipe.AddIngredient(null, "BlueTearstoneRing", 1);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
        }

    }
}
