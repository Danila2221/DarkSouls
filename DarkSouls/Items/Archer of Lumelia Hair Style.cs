using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
namespace DarkSouls.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class ArcherofLumeliaHairStyle : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 12;
            item.maxStack = 1;
            item.value = 10000;
			item.rare = 3;
			item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
            Tooltip.SetDefault("Gifted with bows, repeaters, and other long range weapons");

		}


		public override void UpdateEquip(Player player)
		{
			
		}



        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            
        
			return body.type == mod.ItemType("ArcherofLumeliaShirt") && legs.type == mod.ItemType("ArcherofLumeliaPants");
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = "+23% Ranged Crit, +15% Ranged Damage, Archery Skill";
            player.rangedCrit += 23;
            player.rangedDamage += 0.15f;
            player.archery = true;

        }
		

			

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AdamantiteMask, 1);
            recipe.AddIngredient(null, "DarkSoul", 4000);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
		}
	}
}
