
using Terraria.ID;

using Terraria.ModLoader;

using DarkSouls.Projectiles;
namespace DarkSouls.Items
{
    public class ChaosTome : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Casts a purple flame that can pass through solid objects");
        }
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 30;
            item.useStyle = 5;
            item.useTurn = true;
            item.useAnimation = 25;
            item.useTime = 25;
            item.maxStack = 1;
            item.damage = 60;
            item.autoReuse = true;
            item.knockBack = 4;
            item.scale = 1;
            item.shoot = mod.ProjectileType<ChaosBall2>();
            item.rare = 2;
            item.shootSpeed = 8;
            item.crit = 0;
            item.mana = 8;
            item.noMelee = true;
            item.value = 18400;
            item.magic = true;
            item.UseSound = SoundID.Item8;
           
        }
    }
}
