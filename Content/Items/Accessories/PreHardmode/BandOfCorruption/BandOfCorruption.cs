using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Ritualist.Content.Items.Accessories.PreHardmode.BandOfCorruption {

    /// <summary>
    /// Accessory
    /// Decrease lifeRegen by 0.5 health per second.
    /// Recieve MinorCorruptionBlessing for 5s on sacrifices.
    /// </summary>
    public class BandOfCorruption : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 20;
            Item.accessory = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(gold: 2);
            Item.defense = 0;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lifeRegen -= 1; // -0.5h/s
        }
    }
}
