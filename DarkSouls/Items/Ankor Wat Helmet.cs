using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
namespace DarkSouls.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class AnkorWatHelmet : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 12;
            item.maxStack = 1;
            item.value = 1000;
            item.rare = 8;
            item.defense = 14;
            
		}

		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Ankor Wat Helmet");
            Tooltip.SetDefault("30% Less Mana Usage."
                + "\n+15 Defense when health is less than 120");
		}


		public override void UpdateEquip(Player player)
		{
            player.manaCost -= 0.30f;


            if (player.statLife <= 120)
            {
                player.statDefense += 15;
            }
            else
            {
                player.statDefense += 0;
            }
        }

		

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("AnkorWatArmor") && legs.type == mod.ItemType("AnkorWatGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = "+160 max mana + Rapid Mana Regen";
            player.manaRegenBuff = true;
            player.statManaMax2 += 160;
            player.manaRegen += 8;
            

        }


        public void PlayerFrame(Player player, Item head, Item body, Item legs)
        {
            if (body.type == mod.ItemType("AnkorWatArmor") && legs.type == mod.ItemType("AnkorWatGreaves")) ;
                


                    int dust = Dust.NewDust(new Vector2((float)player.position.X, (float)player.position.Y), player.width, player.height, 60, (player.velocity.X) + (player.direction * 1), player.velocity.Y, 100, Color.Red, 1.0f);
                    Main.dust[dust].noGravity = true;
                
            
        }


        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedHeadgear, 1);
            recipe.AddIngredient(null, "DarkSoul", 10000);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
		}
	}
}
