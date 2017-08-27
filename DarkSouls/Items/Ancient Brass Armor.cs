using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DarkSouls.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class AncientBrassArmor : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Ancient Brass Set");
			
		}


		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 27000;
			item.defense = 3;
			item.maxStack = 1;
		}

		public override void UpdateEquip(Player player)
		{
			
		}	

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronChainmail, 1);
            recipe.AddIngredient(null, "DarkSoul", 200);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
		}
	}
}