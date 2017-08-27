using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
namespace DarkSouls.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class AncientDemonHelmet : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 24;

			item.value = 40000;
			item.rare = 3;
			item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			
			Tooltip.SetDefault("You hear an evil whispering from inside.");
		}


		public override void UpdateEquip(Player player)
		{
			if (Main.rand.Next(3)==0)
	{
	
	int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 6, Main.rand.Next(-5,5), Main.rand.Next(-5,5), 200, Color.Yellow, 1.0f);
	Main.dust[dust].noGravity = true;
	Main.dust[dust].noLight = false;
	}
		}

		

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("AncientDemonArmor") && legs.type == mod.ItemType("AncientDemonGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "+15% Magic Critical Chance, -15% Mana Usage, +15 Magic Damage";
	player.magicCrit += 15;
	player.manaCost -= 0.15f;
	player.magicDamage += 0.15f;
}


	


		

			

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MoltenHelmet, 1);
            recipe.AddIngredient(null, "DarkSoul", 3000);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
		}
	}
}
