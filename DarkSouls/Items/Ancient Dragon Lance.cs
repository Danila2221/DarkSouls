using DarkSouls.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Items
{
	public class AncientDragonLance : ModItem
	{
		public override void SetStaticDefaults()
		{
			
		}

		public override void SetDefaults()
		{
            item.maxStack = 1;
            item.damage = 12;
			item.useStyle = 5;
			item.useAnimation = 30;
			item.useTime = 3;
			item.shootSpeed = 5f;
			item.knockBack = 4f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType<AncientDragonLanceP>();
			item.value = 27000;
			item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			item.melee = true;
			item.autoReuse = true; // Most spears don't autoReuse, but it's possible
		}

		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[item.shoot] < 1; // This is to ensure the spear doesn't bug out when using autoReuse = true
		}
	}
}
