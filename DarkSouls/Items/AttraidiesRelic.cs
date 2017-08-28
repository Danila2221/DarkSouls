using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Items
{

    public class AttraidiesRelic : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons a mindflayer illusion from the legion army of Attraidies!"
                + "\nDrops 600 souls of utterly corrupt darkness, among other random things."
                + "\nYou feel compelled to try this...");
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 40;
            item.maxStack = 1;
            item.rare = 9;
            item.useAnimation = 45;
            item.useTime = 55;
            item.useStyle = 4;
            item.UseSound = SoundID.Item44;
            item.value = 1000;
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
            
                if (Main.netMode != 1)
                {
                NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("MindflayerIllusion"));
                }
                
            
            return true;
        }

        
    }
}