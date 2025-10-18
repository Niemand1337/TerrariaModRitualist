using Microsoft.Xna.Framework;
using Ritualist.Buffs;
using Ritualist.Content.Projectiles.MetalboundCatalystProjectile;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Ritualist.Content.Items.Weapons.PreBoss.MetalboundCatalyst
{
    /// <summary>
    /// Weapon, PreBoss
    /// Magic staff thats shoots two homing projectiles MetalboundCatalystProjectile.
    /// Can only be used with a Dark Blessing
    /// </summary>
    public class MetalboundCatalyst : ModItem
    {
        private static readonly float weaponLength = 55.56f; // Weapons visual length -> sqrt(40**2 + 40**2) ~ 56.56f

        public override void SetDefaults()
        {
            Item.damage = 23;
            Item.crit = 2;
            Item.DamageType = ModContent.GetInstance<RitualistClass>();
            Item.knockBack = 2;
            Item.mana = 11;
            Item.noMelee = true;

            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.Blue;

            Item.width = 40;
            Item.height = 40;
            Item.useTime = 15; 
            Item.reuseDelay = 30;
            Item.useAnimation = Item.useTime * 2; // useTime is half the useAnimation - This is so the projectile is cast twice
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item20;

            Item.shoot = ModContent.ProjectileType<MetalboundCatalystProjectile>();
            Item.shootSpeed = 9.5f;
        }

        public override void SetStaticDefaults()
        {
            Item.staff[Item.type] = true;
            base.SetStaticDefaults();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("Ritualist:Iron-OrLeadBar", 5);
            recipe.AddRecipeGroup("Ritualist:Copper-OrTinBar", 3);
            recipe.AddIngredient(ItemID.LifeCrystal, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.HasBuff(ModContent.BuffType<MinorDarkBlessing>()))
            {
                // Offset the projectile to make it appear from the staff
                Vector2 offset = velocity.SafeNormalize(Vector2.UnitX) * (weaponLength - 3); // Offset to the weapon tip
                Vector2 spawnPosition = player.Center + offset;

                Projectile.NewProjectile(source, spawnPosition, velocity, type, damage, knockback, player.whoAmI);
            }
            return false;
        }
    }
}