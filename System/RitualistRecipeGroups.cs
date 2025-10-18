using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Ritualist.System
{
    public class RitualistRecipeGroups : ModSystem
    {
        public override void AddRecipeGroups()
        {
            RecipeGroup ironGroup = new RecipeGroup(() => "Iron or Lead Bar", ItemID.IronBar, ItemID.LeadBar);
            RecipeGroup.RegisterGroup("Ritualist:IronOrLead", ironGroup);

            RecipeGroup copperGroup = new RecipeGroup(() => "Copper or Tin Bar", ItemID.CopperBar, ItemID.TinBar);
            RecipeGroup.RegisterGroup("Ritualist:CopperOrTin", copperGroup);
        }
    }
}
