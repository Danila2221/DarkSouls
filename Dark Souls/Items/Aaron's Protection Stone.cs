using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Items
{
	
	public class AaronProtectionStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("The volcanic stoned etched in Aaron's image."
				+ "\nSaid to protect the one who carries it in times of despair"
				+ "\nUse this at the top of The Temple Shrine of The Wall in case your first effort"
				+ "\ndoes not succeed. (Use it don't drop it in lava.)"
				+ "\nBut first: save, quit and reload before each time you resummon him.");
		}

		public override void SetDefaults()
		{
			item.width = 14;
			item.height = 26;
			item.maxStack = 1;
			item.rare = 9;
			item.useAnimation = 45;
			item.useTime = 55;
			item.useStyle = 4;
			item.UseSound = SoundID.Item44;
			item.value = 1000;
			item.consumable = false;
		}

		// We use the CanUseItem hook to prevent a player from using this item while the boss is present in the world.
		public override bool CanUseItem(Player player)
		{
			// "player.ZoneUnderworldHeight" could also be written as "player.position.Y / 16f > Main.maxTilesY - 200"
			return !NPC.AnyNPCs(NPCID.WallofFlesh);
		}

		public override bool UseItem(Player player)
		{
			if(player.ZoneUnderworldHeight == false){
				Main.NewText("Nothing happens...", 175, 75, 255);
			}
			else
			{
			if (Main.netMode != 1)
			{
				NPC.NewNPC((int)Main.player[Main.myPlayer].position.X-(1070), (int)player.Center.Y - 240, NPCID.WallofFlesh);
			}
			Main.NewText("A Gate has been opened. The Wall of Flesh has passed into this dimension!... ", 175, 75, 255);
			Main.PlaySound(SoundID.Roar, player.position, 0);
			}
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GuideVoodooDoll, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}