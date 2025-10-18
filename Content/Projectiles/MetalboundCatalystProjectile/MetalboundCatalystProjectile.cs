using Microsoft.Xna.Framework;
using Ritualist.System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Ritualist.Content.Projectiles.MetalboundCatalystProjectile
{
    public class MetalboundCatalystProjectile : ModProjectile
    {
        static readonly ProjectileHoming homingSystem = ModContent.GetInstance<ProjectileHoming>();
        static float homingRange = 175f; // How far to search for targets
        static float homingStrength = 0.38f; // How strongly to adjust direction

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 12;
            Projectile.friendly = true;
            Projectile.DamageType = ModContent.GetInstance<RitualistClass>();
            Projectile.penetrate = 1;
            Projectile.timeLeft = 600;
            Projectile.light = 0.5f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.aiStyle = 0; // Custom movement
        }
 
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation();

            // Homing the projectile
            Projectile.velocity = homingSystem.LinearHoming(Projectile, homingRange, homingStrength);

            // Dust for animation
            if (Main.rand.NextBool(3))
            {
                int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.GemAmethyst, Projectile.velocity.X * 0.15f, Projectile.velocity.Y * 0.15f);
                Dust dust = Main.dust[dustIndex];
                dust.scale = 1.3f;
                dust.noGravity = true;
            }
        }
    }
}
