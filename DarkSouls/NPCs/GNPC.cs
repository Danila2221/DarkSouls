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
        static int devouHead;
        static int devouHead2;
        static int worm;
        static int worm2;
        static int worldeater;
        static int worldeaterH;
        static int eaterHead;
        static int eaterBody;
        static int soule;
        static int goblinmag;
        static int goblinmag2;
        static int goblinmagS;
        static int goblinmagS2;
        static int meteor;














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
                Main.NewText("The souls of Eye of Cthulhu have been released");
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkSoul"), eyeofc);
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HerosHat, 1);
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HerosShirt, 1);
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HerosPants, 1);
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HermesBoots, 1);
            }
            if (npc.type == NPCID.ServantofCthulhu)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkSoul"), 1);
            }
            if (npc.type == NPCID.DevourerHead)
            {
                devouHead = basicsoul * 14;
                devouHead2 = basicsoul * 18;
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkSoul"), Main.rand.Next(devouHead, devouHead2));
            }
            if (npc.type == NPCID.EaterofWorldsBody)
            {
                worldeater = basicsoul * 100;
                
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkSoul"), worldeater);
            }
            if (npc.type == NPCID.EaterofWorldsHead)
            {
                worldeaterH = basicsoul * 200;

                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkSoul"), worldeaterH);
            }
            if (npc.type == NPCID.GiantWormHead)
            {
                worm = basicsoul * 9;
                worm2 = basicsoul * 12;
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkSoul"), Main.rand.Next(worm, worm2));
            }
            if (npc.type == NPCID.EaterofSouls)
            {
                soule = basicsoul * 50;
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkSoul"), soule);
            }
            if (npc.type == NPCID.GoblinSorcerer)
            {
                goblinmag = basicsoul * 40;
                goblinmag2 = basicsoul * 60;
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkSoul"), Main.rand.Next(goblinmag, goblinmag2));
            }
            if (npc.type == NPCID.GoblinArcher)
            {
                goblinmag = basicsoul * 40;
                goblinmag2 = basicsoul * 60;
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkSoul"), Main.rand.Next(goblinmag, goblinmag2));
            }
            if (npc.type == NPCID.GoblinWarrior)
            {
                goblinmag = basicsoul * 40;
                goblinmag2 = basicsoul * 60;
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkSoul"), Main.rand.Next(goblinmag, goblinmag2));
            }
            if (npc.type == NPCID.GoblinPeon)
            {
                goblinmag = basicsoul * 40;
                goblinmag2 = basicsoul * 60;
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkSoul"), Main.rand.Next(goblinmag, goblinmag2));
            }
            if (npc.type == NPCID.GoblinScout)
            {
                goblinmag = basicsoul * 40;
                goblinmag2 = basicsoul * 60;
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkSoul"), Main.rand.Next(goblinmag, goblinmag2));
            }
            if (npc.type == NPCID.GoblinSummoner)
            {
                goblinmagS = basicsoul * 1000;
                goblinmagS2 = basicsoul * 2000;
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkSoul"), Main.rand.Next(goblinmag, goblinmag2));
            }
            if (npc.type == NPCID.GoblinThief)
            {
                goblinmag = basicsoul * 40;
                goblinmag2 = basicsoul * 60;
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkSoul"), Main.rand.Next(goblinmag, goblinmag2));
            }
            if (npc.type == NPCID.GoblinTinkerer)
            {
                goblinmag = basicsoul * 40;
                goblinmag2 = basicsoul * 60;
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkSoul"), Main.rand.Next(goblinmag, goblinmag2));
            }
            if (npc.type == NPCID.MeteorHead)
            {
                meteor = basicsoul * 20;
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkSoul"), meteor);
            }



        }
    }
}