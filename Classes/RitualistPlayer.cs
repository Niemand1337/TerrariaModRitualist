using Ritualist.Content.Items.Accessories.RedBloodVial;
using Terraria;
using Terraria.ModLoader;

/// <summary>
/// Saves which accessories are equipped as bools for fast access
/// </summary>
public class RitualistPlayer : ModPlayer
{
    public bool hasRedBloodVial = false;

    public override void ResetEffects()
    {
        hasRedBloodVial = false;
    }

    public override void UpdateEquips()
    {
        ResetEffects();
        if (Player.HasItem(ModContent.ItemType<RedBloodVial>()))
        {
            hasRedBloodVial = true;
        }
    }
}
