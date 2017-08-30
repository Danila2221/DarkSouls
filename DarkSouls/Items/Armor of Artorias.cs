using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DarkSouls.Items
{
    [AutoloadEquip(EquipType.Body)]
    public class ArmorOfArtorias : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Artorias Set");
            Tooltip.SetDefault("Enchanted armor of Artorias of the Abyss."
                + "\nPossesses the same power as the Titan Glove.");

        }


        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 40000;
            item.rare = 3;
            item.defense = 30;
            item.maxStack = 1;
            item.value = 40000;
        }

        public override void UpdateEquip(Player player)
        {
            player.kbGlove = true;




        }




        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MoltenBreastplate, 1);
            recipe.AddIngredient(null, "DarkSoul", 3000);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
        }
    }
}