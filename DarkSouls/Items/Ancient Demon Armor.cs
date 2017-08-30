using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DarkSouls.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class AncientDemonArmor : ModItem
	{
		public override void SetStaticDefaults()
		{
			
			DisplayName.SetDefault("Ancient Demon Armor Set");
			Tooltip.SetDefault("Forged by those who brave Annihilation."
				+ "\nMana Regen Skill activates when health falls below 160");
				
		}


		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 40000;
			item.rare = 3;
			item.defense = 13;
			item.maxStack = 1;
		}

		public override void UpdateEquip(Player player)
		{
			if(player.statLife <= 160) {
				player.manaRegenBuff = true;

int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 6, (player.velocity.X) + (player.direction * 1), player.velocity.Y, 100, Color.Green, 1.0f);
 Main.dust[dust].noGravity = true;

				}
				if (Main.rand.Next(3)==0)
	{
	
	int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 6, Main.rand.Next(-5,5), Main.rand.Next(-5,5), 200, Color.Yellow, 1.0f);
	Main.dust[dust].noGravity = true;
	Main.dust[dust].noLight = false;
	}
		



		}	

		


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MoltenBreastplate, 1);
            recipe.AddIngredient(null, "DarkSoul", 3000);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
		}
	}
}