using DarkSouls.Projectiles;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Items
{
    public class CelestialLance : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Celestial Lance");
            Tooltip.SetDefault("Celestial lance fabled to hold sway over the world."
                + "\nIncreases attack damage by 50% when falling.");
        }

        public override void SetDefaults()
        {
            item.width = 44;
            item.height = 44;
            item.maxStack = 1;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.damage = 500;
            item.knockBack = 10;
            item.scale = 1.1f;
            item.shoot = 46;
            item.shootSpeed = 8;
            item.rare = 10;
            item.useStyle = 5;
            item.useAnimation = 11;
            item.useTime = 1;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType<CelestialLanceP>();
            item.value = 57000000;
            item.melee = true;
            item.autoReuse = true; // Most spears don't autoReuse, but it's possible
        }
        public override void GetWeaponDamage(Player player, ref int damage)
        {
            int num21 = (int)(player.position.Y / 16f) - player.fallStart;
            if ((player.gravDir == 1f) && (player.velocity.Y > 0))
            {
                //player.meleeDamage *= (int) ((player.velocity.Y*0.15) + 1);
                player.meleeDamage *= 1.5f;
            }
            if ((player.gravDir == -1f) && (player.velocity.Y < 0))
            {
                //player.meleeDamage *= (int) -(((player.velocity.Y*0.15) - 1));
                player.meleeDamage *= 1.5f;
            }
        }


        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 1; // This is to ensure the spear doesn't bug out when using autoReuse = true
        }
    }
}
