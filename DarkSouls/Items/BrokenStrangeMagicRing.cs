using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DarkSouls.Items
{
    public class BrokenStrangeMagicRing : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Broken Strange Magic Ring");
            Tooltip.SetDefault("A strange magic ring, broken into two pieces..."
                + "\nMiakoda: To reforge this ring and restore its magical abilitiy,"
                + "\nyou'll need 7 White Titanite, 20 Cursed Soul and 1000 Dark Souls."
                + "\nTo find what we need, we should seek out the corruption and the undergound.");
        }
        public override void SetDefaults()
        {

            item.width = 12;
            item.height = 12;
            item.useStyle = 4;
            item.useAnimation = 5;
            item.useTime = 5;
            item.maxStack = 1;
            item.scale = 1;
        }

    }
}
