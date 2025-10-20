using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Ritualist.Buffs.MinorDark
{
    /// <summary>
    /// Buff
    /// Basic blessing that is part of the Dark Blessing group.
    /// Enables most weapons of the mod to work.
    /// Provides low life regeneration boost.
    /// </summary>
    public class MinorDarkBlessing : ModBuff
    {

        public static readonly int FrameCount = 4; // Amount of frames we have on our animation spritesheet.
		public static readonly int AnimationSpeed = 30;
        public static readonly string AnimationSheetPath = "Ritualist/Buffs/MinorDark/MinorDarkBlessing";
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
            player.lifeRegen += 5; // 2.5 life per second
            base.Update(player, ref buffIndex);
        }
    }
}