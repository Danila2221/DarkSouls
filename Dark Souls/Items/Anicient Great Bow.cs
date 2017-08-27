using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Items
{
	public class AncientGreatBow : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 25;
			item.width = 16;
			item.height = 58;
			item.ranged = true;
			item.useTime = 25;
			item.shoot = 1;
			item.shootSpeed = 8f;
			item.useAnimation = 25;
			item.useStyle = 5;
			item.knockBack = 5;
			item.value = 18000;
			item.useAmmo = AmmoID.Arrow;
			item.rare = 2;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.noMelee = true;
		}

		

	}
}
