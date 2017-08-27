using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Items
{
    public class ArtemisBow : ModItem
    {
        public override void SetDefaults()
        {
            item.maxStack = 1;
            item.damage = 400;
            item.width = 24;
            item.height = 60;
            item.ranged = true;
            item.useTime = 75;
            item.shoot = 1;
            item.shootSpeed = 16f;
            item.useAnimation = 75;
            item.useStyle = 5;
            item.knockBack = 19;
            item.value = 3100000;
            item.useAmmo = AmmoID.Arrow;
            item.rare = 5;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.noMelee = true;
        }



    }
}
