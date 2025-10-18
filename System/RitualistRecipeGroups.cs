using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Ritualist.System
{
    public class RitualistRecipeGroups : ModSystem
    {
        public override void AddRecipeGroups()
        {
            RecipeGroup ironBarGroup = new RecipeGroup(() => "Iron or Lead Bar", ItemID.IronBar, ItemID.LeadBar);
            RecipeGroup.RegisterGroup("Ritualist:Iron-OrLeadBar", ironBarGroup);

            RecipeGroup copperBarGroup = new RecipeGroup(() => "Copper or Tin Bar", ItemID.CopperBar, ItemID.TinBar);
            RecipeGroup.RegisterGroup("Ritualist:Copper-OrTinBar", copperBarGroup);

            RecipeGroup metalBroadswordGroup = new RecipeGroup(() => "Gold or Platinum Broadsword", ItemID.GoldBroadsword, ItemID.PlatinumBroadsword);
            RecipeGroup.RegisterGroup("Ritualist:Gold-OrPlatinumBroadsword", metalBroadswordGroup);
        }
    }
}
