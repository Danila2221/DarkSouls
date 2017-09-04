using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Items
{
    public class DeadChicken : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Can be cooked at a cooking pot to make 1 Cooked Chicken"
                + "\nCooked chicken heals 125 HP and has no potion cool-down. Wow! Tasty!");
        }
        public override void SetDefaults()
        {
            item.stack = 1;
            item.consumable = true;
            item.healLife = 25;
            item.useAnimation = 17;
            item.UseSound = SoundID.Item2;
            item.useStyle = 2;
            item.useTime = 17;
            item.height = 16;
            item.maxStack = 100;
            item.scale = 1;
            item.value = 2;
            item.width = 20;
        }
        
    }
}
