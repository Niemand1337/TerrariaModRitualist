using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Ritualist.Content.Items.Accessories.PreHardmode.DemonicBladeNecklace {
    /// <summary>
    /// Accessory
    /// Grants Eye on you Blessing on sacrifice for 5 seconds.
    /// Increases armor by 2 and ritualist damage by 3%
    /// </summary>
    public class DemonicBladeNecklace : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.accessory = true;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.buyPrice(gold: 7);
            Item.defense = 2;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<RitualistPlayer>().hasDemonicBladeNecklace = true;
            player.GetDamage<RitualistClass>() += 0.03f;
        }
    }
}
