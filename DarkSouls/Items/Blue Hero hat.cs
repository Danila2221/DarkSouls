using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DarkSouls.Items
{
    [AutoloadEquip(EquipType.Head)]
    public class BlueHeroHat : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blue Hero's Hat");
            Tooltip.SetDefault("Worn by the hero himself!"
                + "\n+40 Mana"
                + "\nCan be upgraded eventually with 5 Soul of Sight and 40,000 Dark Souls");
        }

		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;
            item.maxStack = 1;

            item.value = 8000;
			item.rare = 2;
			item.defense = 10;
            
		}

        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 40;
        }

        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            
            return body.type == mod.ItemType("BlueHeroShirt") && legs.type == mod.ItemType("BlueHeroPants");
		}

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Grants extended breath & swimming plus 9% all stats Boost. Also gives +3 life regen, +200% movement and hunter vision while in water";
            player.accFlipper = true;
            player.accDivingHelm = true;
            player.meleeDamage += 0.09f;
            player.magicDamage += 0.09f;
            player.rangedDamage += 0.09f;
            player.rangedCrit += 9;
            player.meleeCrit += 9;
            player.magicCrit += 9;
            player.meleeSpeed += 0.09f;
            player.moveSpeed += 0.09f;
            player.manaCost -= 0.09f;
            player.ammoCost80 = true;

            if (player.wet)
            {
                player.lifeRegen += 3;
                player.detectCreature = true;
                player.moveSpeed *= 5f;
            }
        }
	   public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HerosHat, 1);
            recipe.AddIngredient(ItemID.MythrilBar, 1);
            recipe.AddIngredient(null, "DarkSoul", 3000);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
        }

    }
}