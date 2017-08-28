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
    public class BarrierRing : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Barrier Ring");
            Tooltip.SetDefault("Casts Barrier when wearer is critically wounded."
                + "\nBarrier increases defense by 20. ");
        }

        public override void SetDefaults()
        {

            item.width = 32;
            item.height = 26;
            item.accessory = true;

            item.value = 7000;
            item.rare = 3;
            item.maxStack = 1;

        }
        public override void UpdateEquip(Player player)
        {
            
        
            if (player.statLife <= (player.statLifeMax * 0.25f))
            {
                player.AddBuff(mod.BuffType("Barrier"), 10800, false);
            }
        

    }
    public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBar, 3);
            recipe.AddIngredient(ItemID.AdamantiteBar, 1);
            recipe.AddIngredient(ItemID.SoulofLight, 20);
            recipe.AddIngredient(null, "DarkSoul", 20000);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
        }
    }
}





