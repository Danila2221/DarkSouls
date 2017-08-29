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
        static int demoneye;
        static int demoneye2;
        static int greenslime;
        static int greenslime2;
        static int eyeofc;
        



            public override void SetDefaults(NPC npc)
        {
            if(DarkSoulsWorld.downedAttraidies){
               
            }
        }
        
        public override void NPCLoot(NPC npc)
        {
            if (Main.expertMode)
            {
                basicsoul = 2;
            }
            else
            {
                basicsoul = 1;
            }

            if (npc.type == NPCID.KingSlime)
            {
                Main.NewText("The souls of King Slime have been released");
                
            }
            if (npc.type == NPCID.GreenSlime)
            {
                greenslime = basicsoul * 1;
                greenslime2 = basicsoul * 3;
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkSoul"), Main.rand.Next(greenslime, greenslime2));
            }



            if (npc.type == NPCID.Zombie)
            {
            	zombie = basicsoul * 25;
            	zombie2 = basicsoul * 30;
            	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkSoul"), Main.rand.Next(zombie, zombie2));
            }
            if (npc.type == NPCID.BlueSlime)
            {
                blueslime = basicsoul * 10;
                blueslime2 = basicsoul * 13;
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkSoul"), Main.rand.Next(blueslime, blueslime2));
            }
            if (npc.type == NPCID.DemonEye)
            {
                demoneye = basicsoul * 7;
                demoneye2 = basicsoul * 10;
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkSoul"), Main.rand.Next(demoneye, demoneye2));
            }
            if (npc.type == NPCID.EyeofCthulhu)
            {
                eyeofc = basicsoul * 3000;
                
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkSoul"), eyeofc);
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HerosHat, 1);
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HerosShirt, 1);
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HerosPants, 1);
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HermesBoots, 1);
            }














        }
    }
}