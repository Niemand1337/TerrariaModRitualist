using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Localization;
using Ritualist.Buffs.EyeOnYou;
using Ritualist.Buffs.MinorCorruption;



namespace Ritualist.System
{
    public class RitualistHurtSystem : ModSystem
    {
        /// <summary>
        /// Applies the damage taken on sacrifice to the player.
        /// Considers accessories and other effects.
        /// </summary>
        /// <param name="hurt">Base damage of the sacrifice</param>
        /// <param name="player">Player that makes a sacrifice</param>
        public static void RitualistHurt(int hurt, Player player)
        {
            PlayerDeathReason suicide = PlayerDeathReason.ByCustomReason(NetworkText.FromLiteral(player.name + " sacrificed too much"));
            RitualistPlayer ritualist = player.GetModPlayer<RitualistPlayer>();

            // Adjustments through accessories
            if (ritualist.hasRedBloodVial)
            {
                hurt -= 3;
            }
            if (ritualist.hasBandOfCorruption)
            {
                player.AddBuff(ModContent.BuffType<MinorCorruptionBlessing>(), (int)(300 * ritualist.blessingModifer));
            }

            // Adjustments through buffs
            if (player.HasBuff(ModContent.BuffType<EyeOnYouBlessing>()))
            {
                hurt -= 2;
            }

            player.Hurt(suicide, hurt, 0, pvp: false, quiet: false, cooldownCounter: -1, dodgeable: false, armorPenetration: 9999f, scalingArmorPenetration: 9999f, knockback: 0f);
        }
    }
}
