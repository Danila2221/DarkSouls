using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Items
{
    public class BowofEarendil : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Always aim for the heart"
                + "\nLegendary");
        }
        public override void SetDefaults()
        {
            item.damage = 90;
            item.height = 48;
            item.knockBack = 15;
            item.maxStack = 1;
            item.noMelee = true;
            item.ranged = true;
            item.rare = 5;
            item.scale = 0.9f;
            item.autoReuse = true;
            item.shoot = 1;
            item.shootSpeed = 18;
            item.useAmmo = AmmoID.Arrow;
            item.useAnimation = 16;
            item.UseSound = SoundID.Item5;
            item.useStyle = 5;
            item.useTime = 16;
            item.value = 50000;
            item.width = 26;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofSight, 1);
            recipe.AddIngredient(ItemID.MoltenFury, 1);
            recipe.AddIngredient(null, "DarkSoul", 80000);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
        }
    }
}
