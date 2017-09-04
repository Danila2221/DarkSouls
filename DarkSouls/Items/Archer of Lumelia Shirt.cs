using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DarkSouls.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class ArcherofLumeliaShirt : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Archer of Lumelia Set");
            Tooltip.SetDefault("Gifted with lethal archery abilities"
                + "\n25% chance not to consume ammo.");
		}


		public override void SetDefaults()
		{
            item.rare = 3;
            item.width = 18;
			item.height = 18;
			item.value = 5000;
			item.defense = 20;
			item.maxStack = 1;
		}

		public override void UpdateEquip(Player player)
		{
            player.ammoCost75 = true;
        }	

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AdamantiteBreastplate, 1);
            recipe.AddIngredient(null, "DarkSoul", 4000);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
		}
	}
}