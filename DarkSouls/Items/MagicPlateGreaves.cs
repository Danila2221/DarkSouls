using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DarkSouls.Items
{
    [AutoloadEquip(EquipType.Legs)]
    public class MagicPlateGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Magic Plate Greaves");
            Tooltip.SetDefault("The long forgotten greaves."
                                + "\n+20% movement.");
        }

        public override void SetDefaults()
        {
            
            item.width = 20;
            item.height = 20;
            
            
            item.value = 5000000;
            item.rare = 1;
            item.defense = 14;
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.2f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltLeggings, 1);
            recipe.AddIngredient(null, "DarkSoul", 3000);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
        }

    }
}