using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Items
{
	
	public class AbysmalStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Summons the Abysmal Oolacile Sorcerer.");
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
			return !NPC.AnyNPCs(mod.NPCType("AbysmalOolacileSorcerer"));
		}

		public override bool UseItem(Player player)
		{
			if (Main.dayTime){
				Main.NewText("Nothing happens...", 175, 75, 255);
			}
			else
			{
			if (Main.netMode != 1)
			{
				NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("AbysmalOolacileSorcerer"));
			}
			Main.NewText("Thy death will only fuel my immortality, Red...", 175, 75, 255);
			Main.PlaySound(SoundID.Roar, player.position, 0);
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