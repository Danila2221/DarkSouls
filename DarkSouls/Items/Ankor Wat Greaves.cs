using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace DarkSouls.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class AnkorWatGreaves : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Ankor Wat Greaves");
            Tooltip.SetDefault("+20% Move speed. +30% Magic Damage.");
        }

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 100000;
            item.maxStack = 1;
            item.defense = 10;
		}

		
		public override void UpdateEquip(Player player)
		{
            player.moveSpeed += 0.2f;
            player.magicDamage += 0.30f;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedGreaves, 1);
            recipe.AddIngredient(null, "DarkSoul", 100);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
		}
	}
}