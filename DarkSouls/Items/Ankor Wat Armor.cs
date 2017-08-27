using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DarkSouls.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class AnkorWatArmor : ModItem
	{
		public override void SetStaticDefaults()
		{
			
			DisplayName.SetDefault("Ankor Wat Armor Set");
            Tooltip.SetDefault("+30% Magic Critical chance.");
		}


		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 100000;
			item.defense = 14;
			
            item.rare = 8;
        }

		public override void UpdateEquip(Player player)
		{
            player.magicCrit += 30;
        }	

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronChainmail, 1);
            recipe.AddIngredient(null, "DarkSoul", 200);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
		}
	}
}