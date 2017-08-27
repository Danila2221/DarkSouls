using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DarkSouls.Items
{
    [AutoloadEquip(EquipType.Head)]
    public class HornedHelmet : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Horned Helmet");
            Tooltip.SetDefault("It is the famous Helmet of the Stars."
                + "\nA treasure from ancient Plains of Havoc."
                + "\n+5% critical chance ");
        }

		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 26;
            item.maxStack = 1;

            item.value = 8000000;
			item.rare = 1;
			item.defense = 11;
            
		}

        public override void UpdateEquip(Player player)
        {
            player.rangedCrit += 5;
            player.meleeCrit += 5;
            player.magicCrit += 5;
        }

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
            return body.type == mod.ItemType("MagicPlateArmor") && legs.type == mod.ItemType("MagicPlateGreaves");
		}

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "+6% damage all types, +40 mana";
            player.meleeDamage += 0.06f;
            player.magicDamage += 0.06f;
            player.rangedDamage += 0.06f;
            player.statManaMax2 += 40;
        }
	   public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBreastplate, 1);
            recipe.AddIngredient(null, "DarkSoul", 3000);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
        }

    }
}