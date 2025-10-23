using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Ritualist.Content.Items.Craftables.PreHardmode.InkAndQuill
{
    public class InkAndQuill : ModItem
    {
        // public override void SetStaticDefaults()
        // {
        //     DisplayName.SetDefault("Ink and Quill");
        //     Tooltip.SetDefault("A delicate writing tool. Used in crafting ritual items.");
        // }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 22;
            Item.maxStack = 99;
            Item.value = Item.buyPrice(gold: 2);
            Item.rare = ItemRarityID.White;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Feather, 1);
            recipe.AddIngredient(ItemID.BlackInk, 1);
            recipe.AddIngredient(ItemID.Bottle, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}