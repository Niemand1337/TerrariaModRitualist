using Ritualist.Content.Items.Weapons.PreHardmode.MinorDarkSpellbook;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Ritualist.Content.Items.Accessories.PreHardmode.TornDarkSpellbookpage {
    /// <summary>
    /// Accessory
    /// On sacrifice shoots two the Minor Dark Spellbook in a 45 degree angle to the left and right top of the player
    /// Has a 7 second cooldown
    /// </summary>
    public class TornDarkSpellbookpage : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.accessory = true;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.buyPrice(gold: 3);
            Item.defense = 0;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<MinorDarkSpellbook>(), 1);
            recipe.Register();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<RitualistPlayer>().hasTornDarkSpellbookpage = true;
        }
    }
}
