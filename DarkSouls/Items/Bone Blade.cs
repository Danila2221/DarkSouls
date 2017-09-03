using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DarkSouls.Items
{
    public class BoneBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bone Blade");
            Tooltip.SetDefault("A blade of sharpened bone.");
        }
        public override void SetDefaults()
        {
            item.width = 61;
            item.height = 74;
            item.useStyle = 1;
            item.autoReuse = true;
            item.useAnimation = 25;
            item.useTime = 25;
            item.maxStack = 1;
            item.damage = 30;
            item.knockBack = 7;
            item.scale = .9f;
            item.UseSound = SoundID.Item1;
            item.rare = 3;
            item.value = 27000;
            item.melee = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 35);
            recipe.AddIngredient(null, "DarkSoul", 1000);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
        }
    }
}
