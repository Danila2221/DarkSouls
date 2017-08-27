using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

 
namespace DarkSouls.Items
{
    public class DarkSoul : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Soul of a fallen creature"
                + "\nCan be used at Demon Altars to forge new weapons, items and armors.");
        }
        public override void SetDefaults()
        {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.SoulofSight);
            item.width = 22;
            item.height = 22;
            item.value = 0;
            item.rare = -12;
            item.maxStack = 2000000;
            ItemID.Sets.ItemNoGravity[item.type] = true;  //this make that the item will float in air
        }
 
        
 
        
    }
}