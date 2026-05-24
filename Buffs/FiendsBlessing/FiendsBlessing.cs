using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Ritualist.Buffs.FiendsBlessing
{
    /// <summary>
    /// Buff
    /// Basic blessing that grants fire resistance
    /// Provides multiple small buffs (damage, speed, jumpHeight, defense, lifeRegen).
    /// </summary>
    public class FiendsBlessing : ModBuff
    {

        public static readonly int FrameCount = 4; // Amount of frames we have on our animation spritesheet.
		public static readonly int AnimationSpeed = 30;
        public static readonly string AnimationSheetPath = "Ritualist/Buffs/FiendsBlessing/FiendsBlessing";
        private Asset<Texture2D> animatedTexture;

        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = false;
            Main.buffNoTimeDisplay[Type] = true;

            animatedTexture = ModContent.Request<Texture2D>(AnimationSheetPath);
        }

        public override bool PreDraw(SpriteBatch spriteBatch, int buffIndex, ref BuffDrawParams drawParams)
        {
            Texture2D ourTexture = animatedTexture.Value;
            Rectangle ourSourceRectangle = ourTexture.Frame(verticalFrames: FrameCount, frameY: (int)Main.GameUpdateCount / AnimationSpeed % FrameCount);

            drawParams.Texture = ourTexture;
            drawParams.SourceRectangle = ourSourceRectangle;
            return true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            // Stat buffs
            player.GetDamage<RitualistClass>() += 0.11f;
            player.moveSpeed += 0.07f;
            player.jumpSpeedBoost += 0.05f;
            player.statDefense += 3;
            player.lifeRegen += 2;

            // Fire resistance
            player.buffImmune[BuffID.OnFire] = true;
            player.buffImmune[BuffID.Burning] = true;

            base.Update(player, ref buffIndex);
        }
    }
}