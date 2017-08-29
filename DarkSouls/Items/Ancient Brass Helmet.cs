using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
namespace DarkSouls.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class AncientBrassHelmet : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 24;
            item.maxStack = 1;
            item.value = 1000;
			item.rare = 2;
			item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			

		}


		public override void UpdateEquip(Player player)
		{
			
		}



        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            
        
			return body.type == mod.ItemType("AncientBrassArmor") && legs.type == mod.ItemType("AncientBrassGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "+6 defense, +10% Move Speed, +5% ranged dmg";
	    player.statDefense += 6;
	    player.moveSpeed += 0.1f;
	    player.rangedDamage += 0.05f;

}
		

			

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronHelmet, 1);
            recipe.AddIngredient(null, "DarkSoul", 100);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
		}
	}
}
