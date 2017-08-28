using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace DarkSouls
{
    class DarkSouls : Mod
    {
        
        
        public override void PostSetupContent()
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if(bossChecklist != null)
            {
                // AddBoss, bossname, order or value in terms of vanilla bosses, inline method for retrieving downed value.
                bossChecklist.Call("AddBoss", "Abysmal Oolacile Sorcerer", 7f, (Func<bool>)(() => DarkSoulsWorld.downedSorcerer));
                bossChecklist.Call("AddBoss", "Attraidies", 5.5f, (Func<bool>)(() => DarkSoulsWorld.downedAttraidies));
                //bossChecklist.Call(....
                // To include a description:
                
            }
        }



        public int iexp = 0;
        public int ilevel = 0;
        public int itnl = 0;
        public string oritemname = "";
        public int oridamage = 0;
        public int oricrit = 0;

       



        public static bool NoZoneAllowWater(NPCSpawnInfo spawnInfo)
        {
            return !spawnInfo.sky && !spawnInfo.player.ZoneMeteor && !spawnInfo.spiderCave;
        }

        
           
        
    
    
   
      
          

            

        
        public DarkSouls()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }
    }
}
