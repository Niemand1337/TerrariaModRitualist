using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Ritualist.Content.Items.Accessories.PreBoss.RedBloodVial {
    /// <summary>
    /// Accessory
    /// Increases lifeRegen by 0.5 health per second and lowers sacrificialHurt by 3 flat
    /// Can be dropped by BloodZombies with 10% chance
    /// </summary>
    public class RedBloodVial : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.accessory = true;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.buyPrice(gold: 2);
            Item.defense = 0;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lifeRegen += 1; // 0.5 health per second
        }
    }
}
