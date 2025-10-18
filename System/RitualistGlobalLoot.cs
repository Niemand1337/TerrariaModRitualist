using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Ritualist.Content.Items.Accessories.PreBoss.RedBloodVial;

namespace Ritualist.Content.Systems
{
    /// <summary>
    /// Loot changes from mod are configured here
    /// </summary>
    public class RitualistGlobalNPC : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.BloodZombie)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RedBloodVial>(), 10));
            }
        }
    }
}
