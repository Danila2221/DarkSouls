using DarkSouls.Projectiles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Items
{
    public class ClaiomhSolais : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Seize the day");
        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 40;
            item.useStyle = 1;
            item.useAnimation = 25;
            item.useTime = 23;
            item.maxStack = 1;
            item.damage = 62;
            item.knockBack = 6;
            item.autoReuse = true;
            item.scale = 1.15f;
            item.UseSound = SoundID.Item1;
            item.rare = 5;
            item.value = 300000;
            item.melee = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBar, 5);
            recipe.AddIngredient(ItemID.MythrilBar, 5);
            recipe.AddIngredient(ItemID.AdamantiteBar, 5);
            recipe.AddIngredient(null, "DarkSoul", 20000);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
