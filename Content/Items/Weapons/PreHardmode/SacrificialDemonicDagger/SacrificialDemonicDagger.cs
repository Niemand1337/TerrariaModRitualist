using Microsoft.Xna.Framework;
using Ritualist.Buffs.EyeOnYouBlessing;
using Ritualist.Buffs.MinorDarkBlessing;
using Ritualist.System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Ritualist.Content.Items.Weapons.PreHardmode.SacrificialDemonicDagger
{ 
    /// <summary>
    /// Utility item, Post Eye of Cthulhu
    /// Sacrifical dagger that hurts the user to recieve MinorDarkBlessing and EyeOnYouBlessing
    /// </summary>
	public class SacrificialDemonicDagger : ModItem
	{
		public override void SetDefaults()
		{
			Item.noMelee = true;

			Item.useTime = 20;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Thrust;
			Item.autoReuse = false;
			Item.reuseDelay = 14;
			
			Item.value = Item.buyPrice(gold: 5);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item1;
		}

		public override bool? UseItem(Player player)
		{
            // Player sacrifice
            RitualistHurtSystem.RitualistHurt(42, player);

            // Player recieves blessings
            player.AddBuff(ModContent.BuffType<EyeOnYouBlessing>(), 660);
			player.AddBuff(ModContent.BuffType<MinorDarkBlessing>(), 900); // Increases lifeRegen by 5, which results in 37.5 life over 15 seconds
			return base.UseItem(player);
		}

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(8, 0);
        }
	}
}
