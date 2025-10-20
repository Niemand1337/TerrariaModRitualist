using Microsoft.Xna.Framework;
using Ritualist.Buffs.MinorDarkBlessing;
using Ritualist.System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Ritualist.Content.Items.Weapons.PreHardmode.SacrificialStoneDagger
{ 
	/// <summary>
    /// Utility item, PreBoss
    /// Sacrifical dagger that the hurts user to recieve MinorDarkBlessing
    /// </summary>
	public class SacrificialStoneDagger : ModItem
	{
		public override void SetDefaults()
		{
			Item.noMelee = true;

			Item.useTime = 20;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Thrust;
			Item.autoReuse = false;
			Item.reuseDelay = 14;
			
			Item.value = Item.buyPrice(copper: 5);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item1;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 1);
			recipe.AddIngredient(ItemID.StoneBlock, 3);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}

		public override bool? UseItem(Player player)
		{
			// Player sacrifice
			RitualistHurtSystem.RitualistHurt(33, player);

			// Player recieves blessings
			float blessingModifer= player.GetModPlayer<RitualistPlayer>().blessingModifer;
            player.AddBuff(ModContent.BuffType<MinorDarkBlessing>(), (int)(600 * blessingModifer));
			return base.UseItem(player);
		}

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(8, 0);
        }
	}
}
