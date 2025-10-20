using System;
using Microsoft.Xna.Framework;
using Ritualist.Buffs.EyeOnYou;
using Ritualist.Content.Projectiles.PurpleLaser;
using Ritualist.System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Ritualist.Content.Projectiles.PurpleSphere
{
    public class PurpleSphereProjectile : ModProjectile
    {
        static readonly ProjectileHoming homingSystem = ModContent.GetInstance<ProjectileHoming>();
        static readonly float homingRange = 1337.42f; // How far to search for targets

        public override void SetDefaults() {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.timeLeft = 300; // 5 Seconds
            Projectile.penetrate = -1;
            Projectile.friendly = false;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 2;
        }

        public override void AI()
        {
            // Slows sphere down
            if (Projectile.timeLeft > 90)
            {
                Projectile.velocity *= 0.97f; // Reduce speed
                return;
            }

            if (Projectile.timeLeft == 90)
            {
                Projectile.velocity = Vector2.Zero;
                return;
            }

            // Shoots laser
            if (Projectile.timeLeft == 60)
            {
                ShootLaser();
            }
        }

        public override void OnKill(int timeLeft)
        {
            // Second laser with Eye On You Blessing
            Player player = Main.player[Projectile.owner]; // Gets the player that shoot the projectile
            if (player.HasBuff(ModContent.BuffType<EyeOnYouBlessing>()))
            {
                ShootLaser();
            }


            // Dust animation, average 10 dust
            for (int i = 0; i < 50; i++)
            {
                if (Main.rand.NextBool(5))
                {
                    Dust.NewDust(
                        Projectile.position, Projectile.width,
                        Projectile.height, DustID.Corruption,
                        Projectile.velocity.X * 0.15f,
                        Projectile.velocity.Y * 0.15f,
                        Scale: 0.8f);
                }
            }
            base.OnKill(timeLeft);
        }
        
        public void ShootLaser()
        {
            Vector2 laserDirection = homingSystem.LinearAim(Projectile, homingRange);

                if (laserDirection == Vector2.Zero) // No target for laser found
                {
                    return;
                }
                Projectile.NewProjectile(
                    Projectile.GetSource_FromThis(), // This projectile is the spawn source
                    Projectile.Center + laserDirection * 38f, // Projectile spawns from the center of this projectile with an offset
                    laserDirection * 17f, // Laser velocity
                    ModContent.ProjectileType<PurpleLaserProjectile>(),
                    Projectile.damage, // Inherits damage
                    Projectile.knockBack, // Inherits knockback
                    Projectile.owner // Inherits owner
                );
        }
    }
}
