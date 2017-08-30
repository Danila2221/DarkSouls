using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Items
{
	
	public class BlightStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Summons the Blight.");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 28;
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
			return !NPC.AnyNPCs(mod.NPCType("Blight"));
		}

		public override bool UseItem(Player player)
		{
            if (Main.bloodMoon == true)
            {
                Main.NewText("The Blight cannot be summoned or fought while in the Abyss...", 175, 75, 255);
            }
            if (Main.bloodMoon == false)
            {
                if (Main.netMode != 1)
                {
                NPC.NewNPC((int)player.position.X - 700, (int)player.position.Y - 500, mod.NPCType("Blight"), 1);
                }
                    Main.NewText("You will be destroyed");
            }
           

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