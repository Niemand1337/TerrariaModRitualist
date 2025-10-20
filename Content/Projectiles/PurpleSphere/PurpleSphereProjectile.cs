using Microsoft.Xna.Framework;
using Ritualist.Content.Projectiles.PurpleLaser;
using Ritualist.System;
using Terraria;
using Terraria.ModLoader;

namespace Ritualist.Content.Projectiles.PurpleSphere
{
    public class PurpleSphereProjectile : ModProjectile
    {
        static readonly ProjectileHoming homingSystem = ModContent.GetInstance<ProjectileHoming>();
        static readonly float homingRange = 175f; // How far to search for targets
        static readonly float homingStrength = 0.38f; // How strongly to adjust direction

        public override void SetDefaults() {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.timeLeft = 300; // 5 Seconds
            Projectile.penetrate = -1;
            Projectile.friendly = false;
            Projectile.tileCollide = false;
        }

 
        public override void AI()
        {
            if (Projectile.timeLeft == 10) {
                if (Main.myPlayer == Projectile.owner) {
                    Vector2 laserDirection = Projectile.velocity.SafeNormalize(Vector2.UnitY);
                    Projectile.NewProjectile(
                        Projectile.GetSource_FromThis(),
                        Projectile.Center,
                        laserDirection * 20f, // Geschwindigkeit des Lasers
                        ModContent.ProjectileType<PurpleLaserProjectile>(),
                        50, // Schaden
                        2f, // Knockback
                        Projectile.owner
                    );
                }
            }
        }
    }
}
