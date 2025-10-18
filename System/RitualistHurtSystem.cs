using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Localization;



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
            RitualistPlayer modPlayer = player.GetModPlayer<RitualistPlayer>();

            // Adjustments through accessories
            if (modPlayer.hasRedBloodVial)
            {
                hurt -= 3;
            }

            player.Hurt(suicide, hurt, 0);
        }
    }
}
