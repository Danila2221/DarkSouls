using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls
{
    public class DarkSoulsPlayer : ModPlayer
    {
        public override void SetupStartInventory(IList<Item> items)
        {
            
            //and replace with this ones
            Item item = new Item();
            item.SetDefaults(mod.ItemType("DualUseWeapon"));   //this is an example of how to add your moded item
            item.stack = 1;         //this is the stack of the item
            items.Add(item);
 
            Item item2 = new Item();
            item2.SetDefaults(mod.ItemType("ItemName"));
            item2.stack = 20;
            items.Add(item2);
 
            
        }
        public bool CanHitboxDamageNPC(Player P, Rectangle Hitbox, NPC N) // called on npcs that are in the player's weapon hitbox , return true to hit the npc , false otherwise
        {
            if (P.inventory[P.selectedItem].type == mod.ItemType("DiamondPickaxe")) return false;
            else return true;
        }
        public static bool HasItemInArmor(int type)
        {
            for (int f = 0; f < 11; f++)
            {
                if (type == Main.player[Main.myPlayer].armor[f].type)
                {
                    return true;
                }
            }
            return false;
        }
        

        public static bool HasBuff(int buffType)
        {
            for (int i = 0; i < Main.player[Main.myPlayer].buffType.Length; i++)
            {
                if (Main.player[Main.myPlayer].buffType[i] == buffType && Main.player[Main.myPlayer].buffTime[i] > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public static Dictionary<int, float> DamageDir = MakeDamDir();
        public static Dictionary<int, float> MakeDamDir()
        {
            Dictionary<int, float> DamDir = new Dictionary<int, float>();
            //tile id , then the percents to reduce 0.75f = 75% to reduce
            DamDir.Add(48, 4); //spike, 4 made defense always 0 (this works fine)
            DamDir.Add(76, 4); //hellstone
            return DamDir;
        }
        public static float CheckReduceDefense(Vector2 Position, Vector2 Velocity, int Width, int Height, bool fireWalk) // <---- added firewalk param
        {
            Vector2 Me = Position;

            int LowX = (int)(Position.X / 16f) - 1;
            int HighX = (int)((Position.X + (float)Width) / 16f) + 2;
            int LowY = (int)(Position.Y / 16f) - 1;
            int HighY = (int)((Position.Y + (float)Height) / 16f) + 2;

            #region constraints
            if (LowX < 0)
            {
                LowX = 0;
            }
            if (HighX > Main.maxTilesX)
            {
                HighX = Main.maxTilesX;
            }
            if (LowY < 0)
            {
                LowY = 0;
            }
            if (HighY > Main.maxTilesY)
            {
                HighY = Main.maxTilesY;
            }
            #endregion

            for (int i = LowX; i < HighX; i++)
            {
                for (int j = LowY; j < HighY; j++)
                {
                    if (Main.tile[i, j] != null)
                    {
                        Vector2 TilePos;
                        TilePos.X = (float)(i * 16);
                        TilePos.Y = (float)(j * 16);

                        int type = (int)Main.tile[i, j].type;

                        if (DamageDir.ContainsKey(type) && !(fireWalk && type == 76)) // <---- hacked a code into here saying that skip things if you havefirewalk and its hellstone (big thanks to Yoraizor for all his help)
                        {
                            float a = DamageDir[type];
                            float z = 0.5f;
                            if (Me.X + (float)Width > TilePos.X - z &&
                                Me.X < TilePos.X + 16f + z &&
                                Me.Y + (float)Height > TilePos.Y - z &&
                                Me.Y < TilePos.Y + 16f + z)
                            {
                                return a;
                            }
                        }
                    }
                }
            }
            return 0;
        }









    }
}
