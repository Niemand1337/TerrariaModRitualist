using Microsoft.Xna.Framework;
using Ritualist.Buffs;
using Ritualist.System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Ritualist.Content.Items.Weapons.PreBoss.SacrificialStoneDagger
{ 
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
			Item.rare = ItemRarityID.Blue;
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
			RitualistHurtSystem.RitualistHurt(30, player);

			// Player recieves blessings
			player.AddBuff(ModContent.BuffType<MinorDarkBlessing>(), 600); // Increases lifeRegen by 5, which results in 25hp over 10 seconds
			return base.UseItem(player);
		}

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(8, 0);
        }
	}
}
