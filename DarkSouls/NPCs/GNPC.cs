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
        // this is fucking long
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
        static int meteor; // up ok!
        static int angrybones;
        static int angrybones2; //50 - 100 s
        static int anoruma;
        static int anoruma2; //200 - 250 s
        static int antilion;
        static int antilion2;//30-45
        static int antilionCHARGE;
        static int antilionCHARGE2; //40-80
        static int antilionSWARM;
        static int antilionSWARM2;//30-40
        static int babyslime;
        static int babyslime2;//20-25
        static int blackslime;
        static int blackslime2;//30-40
        static int bee;//1
        static int crimsoncravler;
        static int crimsoncravler2;//35-45
        static int jellyfish;
        static int jellyfish2;//40-50
        static int boneserhead;
        static int boneserhead2;//25-30
        static int cavebat;
        static int cavebat2;//10-15
        static int beetle;
        static int beetle2;//30-40
        static int crab;
        static int crab2;//30-40
        static int crawdad;
        static int crawdad2;//40-50
        static int crimera;
        static int crimera2;//40-50
        static int duegonG;
        static int duegonG2;//300000 message well done
        static int demon;
        static int demon2;//200-350
        static int darkcaster;
        static int darkcaster2;//60-80
        static int cursedscull;
        static int cursedscull2;//40-50
        static int cyanbeetle;
        static int cyanbeetle2;//40-50
        static int doctorbones;
        static int doctorbones2;//400-1000
        static int duegonslime;
        static int duegonslime2;//200-350
        static int groom;
        static int groom2;//300-600
        static int facemo;
        static int facemo2;//70-80
        static int fireimp;
        static int fireimp2;//60-70
        static int scout;
        static int scout2;//50-70
        static int harpy;
        static int harpy2;//80-90
        static int hardmode;
        static int hardmode2;




















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

            if (Main.hardMode);
            {
                hardmode = basicsoul * 500;
                hardmode2 = basicsoul * 1500;
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkSoul"), Main.rand.Next(hardmode, hardmode2));
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