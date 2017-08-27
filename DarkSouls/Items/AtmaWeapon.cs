using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarkSouls.Items // Code modified from Zero-Exodus's code :)
{
    public class AtmaWeapon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Atma Weapon");
            Tooltip.SetDefault("A sword that draws from the power of the wielder. Scales with current HP."
                + "\nThe true form of your father's sword revealed.");
        }
        public float damageMultiplier = 1f; // Damage Multiplier of the weapon.
        public override void SetDefaults()
        {
            
            item.width = 58;
            item.height = 58;
            item.damage = 1;
            item.knockBack = 15;
            item.rare = 10;
            item.value = 49999999;

            item.UseSound = SoundID.Item1;
            item.useStyle = 1;
            item.useTime = 20;
            item.useAnimation = 20;
            item.melee = true;
            item.autoReuse = true;
        }
        public override void UpdateInventory(Player player) // Updates the Sword's damage whenever it is in the inventory and dynamically adjusts damage based on modifiers and player hp.
        {
            HoldStats(player);
        }
        public override void HoldItem(Player player) // Syncs weapon damage when held in hand to prevent abuse.
        {
            HoldStats(player);
        }
        public void HoldStats(Player player) // Function to prevent double code in top two functions.
        {
            item.damage = (int)((float)(player.statLife * damageMultiplier));
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Excalibur, 1);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddIngredient(null, "DarkSoul", 60000);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
        }
    }
}