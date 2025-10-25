using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Localization;
using Ritualist.Buffs.EyeOnYou;
using Ritualist.Buffs.MinorCorruption;
using Ritualist.Content.Projectiles.PurpleSphere;
using Microsoft.Xna.Framework;
using Ritualist.Content.Items.Accessories.PreHardmode.TornDarkSpellbookpage;



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
            if (ritualist.hasBandOfCorruption) // Get 5 seconds MinorCorruptionBlessing
            {
                player.AddBuff(ModContent.BuffType<MinorCorruptionBlessing>(), (int)(300 * ritualist.blessingModifer));
            }
            if (ritualist.hasDemonicBladeNecklace) // 
            {
                player.AddBuff(ModContent.BuffType<EyeOnYouBlessing>(), (int)(300 * ritualist.blessingModifer));
            }

            if (ritualist.hasThornedShackle)
            {
                ThornedShackleHurt(ritualist); // Spawns projectiles - has 7 seconds cooldown
            }
            if (ritualist.hasTornDarkSpellbookpage && ritualist.cooldownTornDarkSpellbookpage == 0)
            {
                MinorDarkSpellbookpage(player);
                ritualist.cooldownTornDarkSpellbookpage = 7 * 60;
            }

            if (ritualist.hasRedBloodVial) // Take 3 less sacrificial damage
            {
                hurt -= 3;
            }

            // Adjustments through buffs
            if (player.HasBuff(ModContent.BuffType<EyeOnYouBlessing>())) // Take 2 less sacrificial damage
            {
                hurt -= 2;
            }

            // Take hurt as damage
            if (hurt < 3) // Can't heal on sacrifice - Smallest Sacrifice is 3
            {
                hurt = 3;
            }
            player.Hurt(suicide, hurt, 0, pvp: false, quiet: false, cooldownCounter: -1, dodgeable: false, armorPenetration: 9999f, scalingArmorPenetration: 9999f, knockback: 0f);
        }

        /// <summary>
        /// Manages the ThornedShackle damage for the ritualist player
        /// Refreshes cooldown if taken damage again and prevents recursion
        /// Damage ist called and cooldown counted down in RitualistPlayer in PostUpdate
        /// </summary>
        /// <param name="ritualist"></param>
        public static void ThornedShackleHurt(RitualistPlayer ritualist)
        {
            if (ritualist.hasThornedShackleDamageIncoming && ritualist.cooldownThornedShackleDamage == 0) // This RitualistHurt was called from ThornedShackleHurt
            {
                ritualist.hasThornedShackleDamageIncoming = false;
                return;
            }
            // Start or reset cooldown because of not ThornedShackle sacrifice
            ritualist.hasThornedShackleDamageIncoming = true;
            ritualist.cooldownThornedShackleDamage = 180; // 3 seconds
        }

        /// <summary>
        /// Spawns 2 PurpleSphereProjectile from the player in 45 and 135 degree based on (1, 0)
        /// </summary>
        /// <param name="player"></param>
        public static void MinorDarkSpellbookpage(Player player)
        {
            foreach (Item item in player.armor)
            {
                if (item.type == ModContent.ItemType<TornDarkSpellbookpage>()) // Needs to have the object instance of the item of the player as damage source
                {
                    Projectile.NewProjectile(
                        player.GetSource_Accessory(item),
                        player.Center,
                        new Vector2(x: 1, y: -1),
                        ModContent.ProjectileType<PurpleSphereProjectile>(),
                        29,
                        0
                    );
                    Projectile.NewProjectile(
                        player.GetSource_Accessory(item),
                        player.Center,
                        new Vector2(x: -1, y: -1),
                        ModContent.ProjectileType<PurpleSphereProjectile>(),
                        29,
                        0
                    );
                    break;
                }
            }
        }
    }
}
