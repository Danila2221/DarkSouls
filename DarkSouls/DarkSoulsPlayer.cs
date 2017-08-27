using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls
{
    class DarkSoulsPlayer : ModPlayer
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
        
        
        
    
    
   
      
          

            

        
        
    }
}
