using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace DarkSouls.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class AncientDemonGreaves : ModItem
	{
		public override void SetStaticDefaults()
		{
			
			Tooltip.SetDefault("+20% movement, can walk on heated grounds.");
			
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 40000;
			item.rare = 3;
			item.defense = 9;
		}

		
		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.20f;
			player.fireWalk = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MoltenGreaves, 1);
            recipe.AddIngredient(null, "DarkSoul", 3000);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
		}
	}
}