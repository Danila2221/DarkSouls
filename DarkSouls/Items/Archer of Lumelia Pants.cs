using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace DarkSouls.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class ArcherofLumeliaPants : ModItem
	{
		public override void SetStaticDefaults()
		{
            Tooltip.SetDefault("Gifted with bows, repeaters, and other long range weapons"
                + "\n+13% movement speed");
			
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 6000;
            item.maxStack = 1;
            item.defense = 17;
            item.rare = 3;
		}

		
		public override void UpdateEquip(Player player)
		{

		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AdamantiteLeggings, 1);
            recipe.AddIngredient(null, "DarkSoul", 4000);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
		}
	}
}