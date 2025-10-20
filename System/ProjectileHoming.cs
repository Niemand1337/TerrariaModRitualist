using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Ritualist.System
{
    public class ProjectileHoming : ModSystem
    {
        public NPC ClosestTarget(Projectile projectile, float homingRange)
        {
            NPC target = null;
            float closestDistance = homingRange;

            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.CanBeChasedBy(this))

                {
                    float distance = Vector2.Distance(projectile.Center, npc.Center);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        target = npc;
                    }
                }
            }
            return target;
        }


        public Vector2 LinearHoming(Projectile projectile, float homingRange, float homingStrength)
        {
            float nonHomingStrength = 1 - homingStrength; // Reverse percentage

            NPC target = ClosestTarget(projectile, homingRange);

            if (target != null) // Target found
            {
                Vector2 targetDirection = projectile.DirectionTo(target.Center);
                Vector2 currentDirection = projectile.velocity;
                Vector2 newDirection = new Vector2(
                    targetDirection.X * homingStrength + currentDirection.X * nonHomingStrength,
                    targetDirection.Y * homingStrength + currentDirection.Y * nonHomingStrength
                    ).SafeNormalize(projectile.velocity);
                if (newDirection != projectile.velocity) // Prevent exponential growth of velocity in case of SafeNormalize failed and default value
                {
                    return newDirection * projectile.velocity.Length();
                }
            }
            return projectile.velocity;
        }

        public Vector2 LinearAim(Projectile projectile, float homingRange)
        {
            NPC target = ClosestTarget(projectile, homingRange);
            if (target == null)
            {
                return Vector2.Zero;
            }
            return projectile.DirectionTo(target.Center).SafeNormalize(Vector2.Zero);
        }

    }
}
