using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using DarkSouls.Projectiles;
namespace DarkSouls.Items
{
    public class Bolt : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {

            item.consumable = true;
            item.ammo = AmmoID.Arrow;
            item.damage = 5;
            item.height = 28;
            item.knockBack = 3;
            item.maxStack = 2000;
            item.ranged = true;
            item.scale = 1;
            item.shootSpeed = 3.5f;
            item.value = 500000;
            item.width = 10;
            item.rare = 3;
            item.shoot = mod.ProjectileType<BoltP>();
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 1);
            recipe.AddIngredient(null, "DarkSoul", 2);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
        }


    }
}
