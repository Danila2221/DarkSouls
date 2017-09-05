using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DarkSouls.Items
{
    public class CoralSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Edged to slay those of the sea. Deals 4x damage.");
        }
        public override void SetDefaults()
        {
            item.stack = 1;
            item.rare = 1;
            item.damage = 32;
            item.height = 36;
            item.knockBack = 5;
            item.maxStack = 1;
            item.melee = true;
            item.scale = .9f;
            item.useAnimation = 23;
            item.UseSound = SoundID.Item1;
            item.useStyle = 1;
            item.useTime = 21;
            item.value = 110000;
            item.width = 36;
        }
        public override void ModifyHitNPC(Player player, NPC npc, ref int damage, ref float knockBack, ref bool crit)
        {
            if (npc.type == NPCID.Shark) damage *= 400;
            else if (npc.FullName == "Goldfish") damage *= 4;
            else if (npc.FullName == "Corrupt Goldfish") damage *= 4;
            else if (npc.FullName == "Jelly Fish") damage *= 4;
            else if (npc.FullName == "Piranha") damage *= 4;
            else if (npc.FullName == "Angler Fish") damage *= 4;
            else if (npc.FullName == "Shark") damage *= 4;
            else if (npc.FullName == "Sahagin Chief") damage *= 4;
            else if (npc.FullName == "Sahagin Prince") damage *= 4;
            else if (npc.FullName == "Quara Constrictor") damage *= 4;
            else if (npc.FullName == "Quara Hydromancer") damage *= 4;
            else if (npc.FullName == "Quara Mantassin") damage *= 4;
            else if (npc.FullName == "Quara Pincher") damage *= 4;
            else if (npc.FullName == "Quara Predator") damage *= 4;
        }
    }
}
