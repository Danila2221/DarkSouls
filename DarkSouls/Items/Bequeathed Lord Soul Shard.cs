using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

 
namespace DarkSouls.Items
{
    public class BequeathedLordSoulShard : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Soul of the albino Seath the Scaleless."
                + "\nA fragment of a Lord Soul discovered at the dawn of the Age of Fire."
                + "\nSeath allied with Lord Gwyn and turned upon the dragons, and for this he was awarded Dukedom, "
                + "\nembraced by the royalty, and given a fragment of a great soul.");
        }
        public override void SetDefaults()
        {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.SoulofSight);
            item.width = 22;
            item.height = 22;
            item.value = 1000000;
            item.rare = 5;
            item.maxStack = 200;
            ItemID.Sets.ItemNoGravity[item.type] = true;  //this make that the item will float in air
        }
 
        
 
        
    }
}