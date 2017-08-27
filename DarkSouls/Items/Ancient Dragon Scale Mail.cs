using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DarkSouls.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class AncientDragonScaleMail : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Ancient Dragon Set");
			Tooltip.SetDefault("A powerful magic/low defense set chosen by skilled Paladins with a taste for high risk/reward combat.");
		}


		public override void SetDefaults()
		{
            item.maxStack = 1;
            item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 5;
		}

		public override void UpdateEquip(Player player)
		{
			
		}	

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}