using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace DarkSouls.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class AncientDwarvenGreaves : ModItem
	{
		public override void SetStaticDefaults()
		{
			
			
			
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 24000;
            item.maxStack = 1;
            item.defense = 4;
		}

		
		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.20f;
			player.fireWalk = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SilverGreaves, 1);
            recipe.AddIngredient(null, "DarkSoul", 500);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
		}
	}
}