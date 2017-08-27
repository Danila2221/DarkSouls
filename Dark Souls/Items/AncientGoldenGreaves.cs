using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DarkSouls.Items
{
    [AutoloadEquip(EquipType.Legs)]
    public class AncientGoldenGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Golden Leggings");
            Tooltip.SetDefault("A lost prince's greaves."
                + "\n+10% movement.");
        }
        

        public override void SetDefaults()
        {

            item.width = 20;
            item.height = 20;


            item.value = 15000;
            item.rare = 8;
            item.defense = 4;
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += .10f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldGreaves, 1);
            recipe.AddIngredient(null, "DarkSoul", 500);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
        }

    }
}