using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Items
{
    public class CookedChicken : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            item.stack = 1;
            item.consumable = true;
            item.healLife = 125;
            item.useAnimation = 17;
            item.UseSound = SoundID.Item2;
            item.useStyle = 2;
            item.useTime = 17;
            item.height = 16;
            item.maxStack = 100;
            item.scale = 1;
            item.value = 2;
            item.width = 20;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DarkSoul", 1);
            recipe.SetResult(this);
            recipe.AddTile(96);
            recipe.AddRecipe();
        }
    }
}
