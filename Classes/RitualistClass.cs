using Terraria.ModLoader;

public class RitualistClass : DamageClass
{
    public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
        {
            // Erbt z. B. von Magic
            if (damageClass == DamageClass.Magic || damageClass == DamageClass.Generic)
                return StatInheritanceData.Full;

            return new StatInheritanceData(0f, 0f, 0f, 0f);
        }

        public override bool GetEffectInheritance(DamageClass damageClass)
        {
            return damageClass == DamageClass.Generic;
        }
}
