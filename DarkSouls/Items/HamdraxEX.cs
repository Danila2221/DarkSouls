using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Items
{
	
	public class HamdraxEX : ModItem
	{
		int playerID;
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Congratulations on beating the final secret boss of the game!"
				+ "\nYou are truly a hero of the ages!"
				+ "\nThis game was over 10 months in development."
				+ "\nIf you really enjoyed the game and want to say thanks"
				+ "\nyou can donate to the non-profit I work for:"
				+ "\nwww.filmsforaction.org/donate"
				+ "\nAs always, I'd love to hear your comments and feedback, too."
				+ "\ntimhjersted@gmail.com");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.maxStack = 1;
			item.rare = 9;
			item.useAnimation = 2;
			item.useTime = 1;
			item.useStyle = 5;
			item.UseSound = SoundID.Item44;
			item.value = 1000;
			item.consumable = false;
			item.damage = 500;
			item.autoReuse = true;
			//idk why but all the guns in the vanilla source have this
			item.shootSpeed = 100f;
		}

		// We use the CanUseItem hook to prevent a player from using this item while the boss is present in the world.
		

		public override bool UseItem(Player player)
		{
			if (Main.mouseX + Main.screenPosition.X-player.position.X > 0) player.direction = 1;
else player.direction = -1;


float targetrotation = (float)Math.Atan2(((Main.mouseY + Main.screenPosition.Y)-player.position.Y),((Main.mouseX + Main.screenPosition.X)-player.position.X));
player.itemRotation = (float)Math.Atan2(((Main.mouseY + Main.screenPosition.Y)-player.position.Y)*player.direction,((Main.mouseX + Main.screenPosition.X)-player.position.X)*player.direction);

int num54 = Projectile.NewProjectile(player.itemLocation.X+(float)Math.Cos(targetrotation)*60+25,player.itemLocation.Y+(float)Math.Sin(targetrotation)*60+18,0,0,mod.ProjectileType("MegaDrill"),500,1f,playerID);
Main.projectile[num54].timeLeft = 100;
Main.projectile[num54].scale = 5f;
Main.projectile[num54].position.X += Main.rand.Next(-16,16);
Main.projectile[num54].position.Y += Main.rand.Next(-16,16);
Main.projectile[num54].rotation = targetrotation;
			return true;
		}

		
	}
}