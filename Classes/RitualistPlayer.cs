using Ritualist.Content.Items.Accessories.PreHardmode.BandOfCorruption;
using Ritualist.Content.Items.Accessories.PreHardmode.RedBloodVial;
using Ritualist.System;
using Terraria;
using Terraria.ModLoader;

/// <summary>
/// Saves which accessories are equipped as bools for fast access
/// </summary>
public class RitualistPlayer : ModPlayer
{
    // Modifier
    public float blessingModifer = 1f; // 1.1 is 10% longer blessings

    // Accessory
    public bool hasRedBloodVial = false;
    public bool hasBandOfCorruption = false;
    public bool hasThornedShackle = false;
    public bool hasThornedShackleDamageIncoming = false;
    public int cooldownThornedShackleDamage = 0;
    public bool hasTornDarkSpellbookpage = false;
    public int cooldownTornDarkSpellbookpage = 0;
    public bool hasDemonicBladeNecklace = false;


    public override void ResetEffects()
    {
        hasRedBloodVial = false;
        hasBandOfCorruption = false;
        hasThornedShackle = false;
        hasTornDarkSpellbookpage = false;
        hasDemonicBladeNecklace = false;
    }


    public override void PostUpdate()
    {
        // MinorDarkSpellbookpage
        if (hasTornDarkSpellbookpage && cooldownTornDarkSpellbookpage > 0)
        {
            cooldownTornDarkSpellbookpage--;
        }

        // ThornedShackle
        if (hasThornedShackle && hasThornedShackleDamageIncoming)
        {
            cooldownThornedShackleDamage--;
            if (cooldownThornedShackleDamage <= 0)
            {
                RitualistHurtSystem.RitualistHurt(10, Player);
            }
        }
        
        base.PostUpdate();
    }
}
