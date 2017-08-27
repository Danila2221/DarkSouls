using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DarkSouls.Items
{
    [AutoloadEquip(EquipType.Body)]
    public class AncientGoldenArmor : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golden Armor");
			Tooltip.SetDefault("A lost prince's armor."
				+ "\n+7% melee speed");
		}
        

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;


            item.value = 15000;
            item.rare = 8;
            item.defense = 15;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeSpeed += 0.07f;

        }
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldChainmail, 1);
            recipe.AddIngredient(null, "DarkSoul", 500);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
        }

	}
}