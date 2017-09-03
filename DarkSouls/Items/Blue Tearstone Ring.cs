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
using DarkSouls;

namespace DarkSouls.Items
{
    public class BlueTearstoneRing : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blue Tearstone Ring");
            Tooltip.SetDefault("The rare gem called tearstone has the uncanny ability to sense imminent death. "
                + "\nThis blue tearstone from Catarina boosts the defence of its wearer by 50 when in danger."
                + "\nWhen the ring is active, melee damage is reduced by 200%, making it a ring ideal for mages"
                + "\nand other ranged classes. However, the ring provides 6 defense under normal circumstances. ");

        }
        public override void SetDefaults()
        {
            item.stack = 1;
            item.accessory = true;
            item.height = 28;
            item.maxStack = 1;
            item.rare = 5;
            item.scale = 1;
            item.value = 270000;
            item.width = 28;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.statLife <= 80)

            {
                player.statDefense += 50;
                player.meleeCrit -= 50;
                player.meleeDamage -= 2f;
            }

            else

            {
                player.statDefense += 6;
            }
        }
        

    }
}
