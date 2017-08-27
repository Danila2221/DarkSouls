using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls
{
    public class MPlayer : ModPlayer //Shield code by Yorai
    {
        public int protect = 0;
        public int stomp = 0;
        public bool dJump = false;
        public bool dualCast = false;
        private float fall = -1;
        private float fs = -1;
        public override void ResetEffects()
        {
            stomp = 0;
            dJump = dJump = (Main.GetKeyState((int)Microsoft.Xna.Framework.Input.Keys.Z) == 1);
            dualCast = false;
        }
        public override void PostUpdate()
        {
            if (stomp > 0)
            {
                if (player.velocity.Y * player.gravDir < 0) fs = (player.position.Y / 16f);

                if (player.controlDown && player.velocity.Y != 0) player.velocity.Y += 4 * player.gravDir;

                if (fall == -1) fall = fs;
                int fallDist = 0;
                if (player.velocity.Y == 0f) // && !wings) // detect landing from a fall
                {
                    fallDist = (int)((float)((int)(player.position.Y / 16f) - fall) * player.gravDir);
                    fs = (player.position.Y / 16f);
                }
                for (int k = 0; k < Main.npc.Length; k++)
                {
                    NPC n = Main.npc[k];
                    int HitDir = -1;
                    if (n.Center.X > player.Center.X) HitDir = 1;
                    Rectangle rect = player.getRect();
                    rect.Offset(0, (int)(player.height + 10 * player.gravDir));
                    if (player.velocity.Y * player.gravDir >= 0) rect.Width = 20;
                    rect.Height = 20;
                    if (n.active && !n.dontTakeDamage && !n.friendly && n.immune[player.whoAmI] == 0 && n.lifeMax > 5)
                    {
                        Rectangle rect2 = n.getRect();
                        if ((rect.Intersects(rect2) && (n.noTileCollide || Collision.CanHit(player.position, player.width, player.height, n.position, n.width, n.height))))
                        {
                            fallDist = (int)((float)((int)(player.position.Y / 16f) - fall) * player.gravDir);
                            fs = (player.position.Y / 16f);
                            if (player.whoAmI == Main.myPlayer)
                            {
                                n.StrikeNPC((int)(fallDist * (stomp * .4f)), 5f, HitDir, true);
                                
                            }
                            n.immune[player.whoAmI] = 10;
                            player.velocity.Y = -stomp * player.gravDir;
                            player.immune = true;
                            player.immuneTime = 20;
                        }
                    }
                }
                fall = fs;
            }
        }
    }
}
