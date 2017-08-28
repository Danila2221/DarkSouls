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
    public class BandofCosmicPower : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Band of Cosmic Power");
            Tooltip.SetDefault("+ 2 life regeneration and increases max mana by 40"
                + "\nCan be upgraded with 10,000 Dark Souls");
        }

        public override void SetDefaults()
        {

            item.width = 22;
            item.height = 22;
            item.accessory = true;

            item.value = 5000;
            item.rare = 1;
            item.maxStack = 1;

        }
        public override void UpdateEquip(Player player)
        {
            player.lifeRegen += 2;
            player.statManaMax2 += 40;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BandofRegeneration, 1);
            recipe.AddIngredient(ItemID.BandofStarpower, 1);
            recipe.AddIngredient(null, "DarkSoul", 3000);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
        }
    }
}

 
    
    

