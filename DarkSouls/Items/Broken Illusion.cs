using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Items
{

    public class BrokenIllusion : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons an all-powerful Mindflayer Illusion"
                + "\nNot for normal use. Actually, this is for testing only. Haha.");
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 40;
            item.useStyle = 4;
            item.useAnimation = 5;
            item.useTime = 5;
            item.maxStack = 1;
            item.scale = 1;
            item.consumable = false;
        }

        // We use the CanUseItem hook to prevent a player from using this item while the boss is present in the world.
        public override bool CanUseItem(Player player)
        {
            // "player.ZoneUnderworldHeight" could also be written as "player.position.Y / 16f > Main.maxTilesY - 200"
            return !NPC.AnyNPCs(mod.NPCType("MindflayerIllusion"));
        }

        public override bool UseItem(Player player)
        {
            Main.NewText("I am impressed you've made it this far, Red. But I'm done playing games. It's time to end this...", 175, 75, 255);
            if (Main.netMode != 1)
                {
                NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("MindflayerIllusion"));
                }
                
            
            return true;
        }

        
    }
}