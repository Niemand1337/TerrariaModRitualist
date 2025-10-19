using Ritualist.Content.Items.Accessories.PreHardmode.BandOfCorruption;
using Ritualist.Content.Items.Accessories.PreHardmode.RedBloodVial;
using Terraria;
using Terraria.ModLoader;

/// <summary>
/// Saves which accessories are equipped as bools for fast access
/// </summary>
public class RitualistPlayer : ModPlayer
{
    public bool hasRedBloodVial = false;
    public bool hasBandOfCorruption = false;

    public override void ResetEffects()
    {
        hasRedBloodVial = false;
        hasBandOfCorruption = false;
    }

    public override void UpdateEquips()
    {
        ResetEffects();
        for (int i = 3; i < 8 + Player.extraAccessorySlots; i++) // First 3 are armor, 5 accessory slots per default
        {
            Item accessory = Player.armor[i];
            if (accessory == null || accessory.IsAir) // Skip empty slots
            {
                continue;
            }

            if (accessory.type == ModContent.ItemType<RedBloodVial>())
            {
                hasRedBloodVial = true;
                continue;
            }
            if (accessory.type == ModContent.ItemType<BandOfCorruption>())
            {
                hasBandOfCorruption = true;
                continue;
            }
        }
    }
}
