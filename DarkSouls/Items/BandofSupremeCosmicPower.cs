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
    public class BandofSupremeCosmicPower : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Band of Supreme Cosmic Power");
            Tooltip.SetDefault("+4 Life Regen and increases max mana by 80");
        }

        public override void SetDefaults()
        {

            item.width = 22;
            item.height = 22;
            item.accessory = true;

            item.value = 15000;
            item.rare = 4;
            item.maxStack = 1;

        }
        public override void UpdateEquip(Player player)
        {
            player.lifeRegen += 3;
            player.statManaMax2 += 60;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BandofGreatCosmicPower", 1);

            recipe.AddIngredient(null, "DarkSoul", 15000);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
        }
    }
}





