using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Ritualist.Buffs.EyeOnYouBlessing
{
    /// <summary>
    /// Buff
    /// Basic blessing that reduces sacrifice damage by two.
    /// Provides multiple small buffs (Defense, speed, jumpSpeed).
    /// </summary>
    public class EyeOnYouBlessing : ModBuff
    {

        public static readonly int FrameCount = 4; // Amount of frames we have on our animation spritesheet.
		public static readonly int AnimationSpeed = 30;
        public static readonly string AnimationSheetPath = "Ritualist/Buffs/EyeOnYouBlessing/EyeOnYouBlessing";
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
            player.statDefense += 7;
            player.moveSpeed += 0.05f;
            player.jumpSpeedBoost += 0.03f;
            base.Update(player, ref buffIndex);
        }
    }
}