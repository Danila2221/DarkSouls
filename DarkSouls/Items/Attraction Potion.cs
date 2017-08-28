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
    public class AttractionPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Attraction Potion");
            Tooltip.SetDefault("Initiates a blood moon"
                + "\n10 minute duration");
        }

        public override void SetDefaults()
        {

            item.width = 28;
            item.height = 28;
            item.useStyle = 2;
            item.useAnimation = 17;
            item.useTime = 17;
            item.maxStack = 30;
            item.consumable = true;
            item.useTurn = true;
            item.buffTime = 10800;
            item.UseSound = SoundID.Item3;
            item.value = 1000;
            item.rare = 1;


        }
        public override bool CanUseItem(Player player)
        {
            bool canuse = true;
            if (Main.dayTime == false) canuse = true;
            else
            {
                canuse = false;
            }
            return canuse;
        }
        public override bool UseItem(Player player)
        {
            player.AddBuff(mod.BuffType("BloodMoon"), 36000, false);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater, 5);
            recipe.AddIngredient(ItemID.Deathweed, 5);
            recipe.AddIngredient(ItemID.RottenChunk, 10);
            recipe.AddIngredient(ItemID.Moonglow, 5);
            recipe.AddIngredient(ItemID.DeathweedSeeds, 5);
            recipe.AddIngredient(ItemID.Lens, 1);
            recipe.SetResult(this);
            recipe.AddTile(13);
            recipe.AddRecipe();
        }
    }
}
