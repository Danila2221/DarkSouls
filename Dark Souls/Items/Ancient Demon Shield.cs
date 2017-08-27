using Terraria.Localization;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DarkSouls.Items
{
	[AutoloadEquip(EquipType.Shield)]
	public class AncientDemonShield : ModItem
	{
		
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Powerful, but slows movement by 25%"
				+ "\nGreat Shield that grants immunity to knockback and gives thorns effect");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = 10000;
			item.rare = 2;
			item.accessory = true;
			
		
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.noKnockback = true;
			player.moveSpeed -= 0.25f;
			player.AddBuff(BuffID.Thorns, 2);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(TileID.Dirt, 1);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}