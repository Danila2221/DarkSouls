using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DarkSouls.NPCs.Enemies
{
    public class ChaosDeathAnimation : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chaos");

            Main.npcFrameCount[npc.type] = 14;
        }
        
        public override void SetDefaults()
        {
          
            npc.width = 0;
            npc.height = 0;
            npc.npcSlots = 0;
            npc.scale = 2.4f;
            npc.aiStyle = -1;//22;
            npc.knockBackResist = 0.1f;
            
            animationType = -1;
            npc.lavaImmune = true;
            npc.buffImmune[BuffID.Venom] = true;
            npc.buffImmune[BuffID.Confused] = true;
            npc.buffImmune[BuffID.CursedInferno] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.damage = 0;
            npc.defense = 0;
            npc.lifeMax = 40000;
            npc.value = 0;
        }
        public override void AI()  //  Floater ai
        {
            int chaosdacount1 = 0;
            npc.dontTakeDamage = true;
            npc.noTileCollide = true;
            npc.noGravity = true;
            #region Ogre/custom frames
            int num = 1;
            if (!Main.dedServ)
            {
                num = Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type];
            }
            if (npc.direction == 1)
            {
                npc.spriteDirection = 1;
            }
            if (npc.direction == -1)
            {
                npc.spriteDirection = -1;
            }
            npc.rotation = npc.velocity.X * 0.08f;
            npc.frameCounter += 1.0;
            if (npc.frameCounter >= 8.0)
            {
                npc.frame.Y = npc.frame.Y + num;
                npc.frameCounter = 0.0;
            }
            if (npc.frame.Y >= num * Main.npcFrameCount[npc.type])
            {
                npc.life = 0;
            }
            #endregion
        }
    }
}
