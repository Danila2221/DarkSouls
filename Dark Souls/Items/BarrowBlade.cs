using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;

namespace DarkSouls.Items
{
	public class BarrowBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Barrow Blade");
			DisplayName.AddTranslation(GameCulture.Russian, "Курган");
			Tooltip.SetDefault("Wrought with spells of a fierce power.\nDispels the defensive shields of Artorias and the Witchking.");
			Tooltip.AddTranslation(GameCulture.Russian, "Наделён заклинанием жестокой власти.\nРассеивает защитные щиты Арториаса и Короля-чародея.");
		}

		public override void SetDefaults()
		{

			item.width = 32;
			item.height = 32;
			
			item.damage = 26;
			item.knockBack = 5;
			item.rare = 2;
			item.value = 140000;
			item.UseSound = SoundID.Item1;
			item.useStyle = 1;
			item.useTime = 21;
			item.useAnimation = 21;
			item.melee = true;
			item.material = true;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
            if(Main.netMode != 1)
    		{
            string key1 = "The shields of Artorias were destroyed!";
            string key2 = "The shields of Witchking were destroyed!";

            
            if (target.type == mod.NPCType("Artorias"))
            {
                
                
                    target.AddBuff(mod.BuffType("Vulnerable"), 10000, false);
         			if (Main.netMode == 0)
					{
         			Main.NewText("The shields of Artorias were destroyed!", 175, 75, 255);
         			}
                	else if (Main.netMode == 2)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(key1), new Color(175, 75, 255));
					}
                
            }
			if (target.type == mod.NPCType("Witchking"))
            {
                
                    target.AddBuff(mod.BuffType("Vulnerable"), 10000, false);
         			if (Main.netMode == 0)
					{
         			Main.NewText("The shields of Witchking were destroyed!", 175, 75, 255);
         			}
                	else if (Main.netMode == 2)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(key2), new Color(175, 75, 255));
					}
                    
                
            }
            if (target.type == mod.NPCType("Sauron"))
            {
                
                
                    target.AddBuff(mod.BuffType("Vulnerable"), 10000, false);
         			if (Main.netMode == 0)
					{
         			Main.NewText("The shields of Sauron were destroyed!", 175, 75, 255);
         			}
                	else if (Main.netMode == 2)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(key1), new Color(175, 75, 255));
					}
                
            }
            if (target.type == mod.NPCType("Nazgul"))
            {
                
                
                    target.AddBuff(mod.BuffType("Vulnerable"), 10000, false);
         			if (Main.netMode == 0)
					{
         			Main.NewText("The shields of Nazgul were destroyed!", 175, 75, 255);
         			}
                	else if (Main.netMode == 2)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(key1), new Color(175, 75, 255));
					}
                
            }
        }
		}
	}
}