using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Ritualist.Content.Items.Accessories.PreBoss.RedBloodVial {
    public class RedBloodVial : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.accessory = true;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.buyPrice(gold: 2);
            Item.defense = 0; // Optional, falls du etwas Defense geben willst
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lifeRegen += 1; // 0.5 health per second
        }
    }
}
