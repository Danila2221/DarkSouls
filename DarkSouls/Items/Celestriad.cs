using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DarkSouls.Items
{
    public class Celestriad : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("All Spells cost 1 mana to cast");
        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 26;
            item.accessory = true;
            item.maxStack = 1;
            item.scale = 1;
            item.rare = 5;
            item.value = 20000000;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.inventory[player.selectedItem].magic)
            {
                player.inventory[player.selectedItem].mana = 1;
            }
        }

    }
}
