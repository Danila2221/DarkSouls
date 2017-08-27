using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
namespace DarkSouls.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class AncientDwarvenHelmet2 : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 24;

			item.value = 15000;
		
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Dwarven Helmet 2");
			Tooltip.SetDefault("+6 life regen when health falls below 80");
		}


		public override void UpdateEquip(Player player)
		{
			
		}

		

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("AncientDwarvenArmor") && legs.type == mod.ItemType("AncientDwarvenGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "+8 Defense, +9 Melee Damage, +9 Melee Speed";
				player.statDefense += 8;
				player.meleeDamage += 0.09f;
				player.meleeSpeed += 0.09f;

}
		

			

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AncientDwarvenHelmet", 1);
            recipe.AddIngredient(null, "DarkSoul", 2000);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
		}
	}
}
