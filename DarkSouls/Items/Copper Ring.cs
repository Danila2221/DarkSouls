using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DarkSouls.Items
{
    public class CopperRing : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Copper Ring");
            Tooltip.SetDefault("Grants +2 Defense");
        }
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 22;
            item.accessory = true;
            item.useAnimation = 100;
            item.useTime = 100;
            item.maxStack = 1;
            item.scale = 1;
            item.rare = 1;
            item.value = 100;

        }
        public override void UpdateEquip(Player player)
        {
            player.statDefense += 2;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CopperBar, 2);
            recipe.AddIngredient(null, "DarkSoul", 200);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
        }
    }
}
