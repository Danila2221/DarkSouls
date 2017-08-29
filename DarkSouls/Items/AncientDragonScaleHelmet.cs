using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
namespace DarkSouls.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class AncientDragonScaleHelmet : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 24;
            item.maxStack = 1;
            item.value = 1000;
			item.rare = 2;
			item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Dragon Scale Helmet");
			Tooltip.SetDefault("It is made of razor sharp dragon scales."
								+ "\nThorns Effect");

		}


		public override void UpdateEquip(Player player)
		{
			player.AddBuff(BuffID.Thorns, 2);
		}



        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            
        
			return body.type == mod.ItemType("AncientDragonScaleMail") && legs.type == mod.ItemType("AncientDragonScaleGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "+20% magic crit, +30% magic damage, +60 mana, -17% mana cost + Mana Cloak skill" + "\nMana Cloak activates rapid mana regen, Star Cloak & Doubles magic crit and damage when life falls below 100";

if(player.statLife <= 100) {
				player.manaCost -= 0.17f;
				player.manaRegenBuff = true;
				player.starCloak = true;
				player.magicCrit += 40;
				player.magicDamage += .60f;
				player.statManaMax2 += 60;

int dust = Dust.NewDust(new Vector2((float) player.position.X, (float) player.position.Y), player.width, player.height, 65, (player.velocity.X) + (player.direction * 1), player.velocity.Y, 100, Color.Blue, 2.0f);
 Main.dust[dust].noGravity = true;

				}
				else { 
					
					player.manaCost -= 0.17f;
					player.magicCrit += 20;
					player.magicDamage += .30f;
					player.statManaMax2 += 60;
					
					
					}

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
