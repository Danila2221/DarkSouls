using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Items
{
    public class CompactFrame : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Used for making advanced weaponry, from a civilization not of this world...");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 18;
            item.maxStack = 4;
            item.value = 350000;
            item.rare = 2;
        }
    }
}
