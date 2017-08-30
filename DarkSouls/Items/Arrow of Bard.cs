using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using DarkSouls.Projectiles;
namespace DarkSouls.Items
{
    public class ArrowofBard : ModItem
    {
        
        public override void SetDefaults()
        {
            item.stack = 1;
            item.consumable = true;
            item.ammo = 1;
            item.damage = 500;
            item.height = 28;
            item.knockBack = 4;
            item.maxStack = 2000;
            item.ranged = true;
            item.scale = 1;
            item.shootSpeed = 3.5f;
            item.type = -1;
            item.useAnimation = 100;
            item.useTime = 100;
            item.value = 500000;
            item.width = 10;
            item.rare = 3;
            item.shoot = mod.ProjectileType<ArrowofBardP>();
        }
    }
}
