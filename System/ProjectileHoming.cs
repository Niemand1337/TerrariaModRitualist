using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Ritualist.System
{
    public class ProjectileHoming : ModSystem
    {
        public Vector2 LinearHoming(Projectile projectile, float homingRange, float homingStrength)
        {
            float nonHomingStrength = 1 - homingStrength; // Reverse percentage

            // Find the closest target
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
    }
}
