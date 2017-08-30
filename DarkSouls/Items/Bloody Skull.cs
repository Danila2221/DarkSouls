using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Items
{
	
	public class BloodySkull : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("BloodySkull");
            Tooltip.SetDefault("A powerful weapon which destroys all enemies when used.");
		}

		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 12;
			item.maxStack = 1;
			item.rare = 9;
			item.useAnimation = 45;
			item.useTime = 55;
			item.useStyle = 4;
			item.UseSound = SoundID.Item44;
			item.value = 700000;
			item.consumable = false;
		}

		// We use the CanUseItem hook to prevent a player from using this item while the boss is present in the world.
		public override bool CanUseItem(Player player)
		{
			// "player.ZoneUnderworldHeight" could also be written as "player.position.Y / 16f > Main.maxTilesY - 200"
			return !NPC.AnyNPCs(mod.NPCType("Death"));
		}

		public override bool UseItem(Player player)
		{
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Death"));
            return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RedTitanite", 10);
			recipe.AddIngredient(null, "WhiteTitanite", 5);
			recipe.AddIngredient(null, "DarkSoul", 1000);
			recipe.SetResult(this);
			recipe.AddTile(26);
			recipe.AddRecipe();
		}
	}
}