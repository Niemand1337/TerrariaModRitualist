using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Ritualist.Content.Items.Accessories.PreHardmode.ThornedShackle
{
    /// <summary>
    /// Accessory
    /// Prolongs sacrifical buffs another time and triggers on-sacrifice effects
    /// 3 Seconds after sacrificing life sacrifice an additional 10 life.
    /// Decreases armor by 2.
    /// Decreases Jumpheigt by 7%
    /// Implementation in RitualistPlayer PostUpdate and RitualistHurtSystem (Recursion prevented)
    /// </summary>
    public class ThornedShackle : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            Item.rare = ItemRarityID.Green;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Stinger, 7);
            recipe.AddIngredient(ItemID.Shackle, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<RitualistPlayer>().hasThornedShackle = true;
            player.statDefense -= 2;
            player.jumpSpeedBoost -= 0.07f;
        }
    }
}

