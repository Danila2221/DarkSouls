using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace DarkSouls.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class AncientBrassGreaves : ModItem
	{
		public override void SetStaticDefaults()
		{

			
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 6000;

			item.defense = 2;
		}

		
		public override void UpdateEquip(Player player)
		{

		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronGreaves, 1);
            recipe.AddIngredient(null, "DarkSoul", 100);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
		}
	}
}