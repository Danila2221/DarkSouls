using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DarkSouls.Items
{
    public class CorruptedTooth : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.useStyle = 1;
            item.useAnimation = 21;
            item.autoReuse = true;
            item.useTime = 21;
            item.maxStack = 1;
            item.damage = 11;
            item.knockBack = 4;
            item.scale = 1;
            item.UseSound = SoundID.Item1;
            item.value = 21000;
            item.melee = true;
        }
        public override void OnHitNPC(Player myPlayer, NPC npc, int damage, float knockBack, bool crit)
        {
            if (Main.rand.Next(10) == 0)
            {
                myPlayer.HealEffect(damage);
                myPlayer.statLife += damage;
            }

            if (npc.type == NPCID.EaterofWorldsHead) damage *= 4;
            else if (npc.type == NPCID.EaterofWorldsBody) damage *= 4;
            else if (npc.type == NPCID.EaterofWorldsTail) damage *= 4;
            else if (npc.type == NPCID.EaterofSouls) damage *= 2;
            else if (npc.type == NPCID.BigEater) damage *= 2;
            else if (npc.type == NPCID.LittleEater) damage *= 3;
        }
    }
}
