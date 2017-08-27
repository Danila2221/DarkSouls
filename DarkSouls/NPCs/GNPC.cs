using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections;
using DarkSouls;
using Terraria.Localization;
namespace DarkSouls.NPCs
{
   
    public class GNPC : GlobalNPC
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }
        
        public int basicsoul;
		static int zombie;
		static int zombie2;
        static int blueslime;
        static int blueslime2;
        public override void SetDefaults(NPC npc)
        {
            if(DarkSoulsWorld.downedAttraidies){
               
            }
        }
        
        public override void NPCLoot(NPC npc)
        {
            
            if (npc.type == NPCID.KingSlime)
            {
                Main.NewText("The souls of King Slime have been released");
                
            }
  
    
             if (Main.expertMode)
            {
                basicsoul = 2;
            }
            else
            {
                basicsoul = 1;
            }

            if (npc.type == NPCID.Zombie)
            {
            	zombie = basicsoul * 25;
            	zombie2 = basicsoul * 30;
            	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkSoul"), Main.rand.Next(zombie, zombie2));
            }
            if (npc.type == NPCID.BlueSlime)
            {
                blueslime = basicsoul * 1;
                blueslime2 = basicsoul * 3;
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkSoul"), Main.rand.Next(blueslime, blueslime2));
            }















        }
    }
}