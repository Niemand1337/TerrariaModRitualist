using Microsoft.Xna.Framework;
using Ritualist.Buffs.EyeOnYou;
using Ritualist.Buffs.MinorDark;
using Ritualist.System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Ritualist.Content.Items.Weapons.PreHardmode.SacrificialDemonicDagger
{ 
    /// <summary>
    /// Utility item, Post Eye of Cthulhu
    /// Sacrifical dagger that hurts the user to recieve MinorDarkBlessing and EyeOnYouBlessing
	/// Takes 42 damage on default, heals 42.5 over 17 seconds
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
			float blessingModifer= player.GetModPlayer<RitualistPlayer>().blessingModifer;
            player.AddBuff(ModContent.BuffType<EyeOnYouBlessing>(), (int)(660 * blessingModifer));
			player.AddBuff(ModContent.BuffType<MinorDarkBlessing>(), (int)(1080 * blessingModifer));
			return base.UseItem(player);
		}

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(8, 0);
        }
	}
}
