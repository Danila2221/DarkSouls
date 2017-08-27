using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
namespace DarkSouls.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class AncientDwarvenHelmet : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 24;

			item.value = 10000;
			
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			
			Tooltip.SetDefault("+4 life regen when health falls below 80");
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
			player.setBonus = "+4 Defense, +7 Melee Damage, +7 Melee Speed";
			player.statDefense += 4;
			player.meleeDamage += 0.07f;
			player.meleeSpeed += 0.07f;

}
		

			

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SilverHelmet, 1);
            recipe.AddIngredient(null, "DarkSoul", 500);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
		}
	}
}
