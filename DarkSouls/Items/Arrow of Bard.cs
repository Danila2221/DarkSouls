﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using DarkSouls.Projectiles;
namespace DarkSouls.Items
{
    public class ArrowofBard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arrow of Bard");
        }
        public override void SetDefaults()
        {

            item.consumable = true;
            item.ammo = AmmoID.Arrow;
            item.damage = 500;
            item.height = 28;
            item.knockBack = 4;
            item.maxStack = 2000;
            item.ranged = true;
            item.scale = 1;
            item.shootSpeed = 3.5f;
            item.useAnimation = 100;
            item.useTime = 100;
            item.value = 500000;
            item.width = 10;
            item.rare = 3;
            item.shoot = mod.ProjectileType<ArrowofBardP>();
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MythrilBar, 1);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
            recipe.AddIngredient(null, "DarkSoul", 2000);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
        }


    }
}
