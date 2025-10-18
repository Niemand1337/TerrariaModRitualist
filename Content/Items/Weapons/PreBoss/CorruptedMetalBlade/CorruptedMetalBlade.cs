using Microsoft.Xna.Framework;
using Ritualist.Buffs;
using Ritualist.Content.Projectiles.MetalboundCatalystProjectile;
using Ritualist.System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Ritualist.Content.Items.Weapons.PreBoss.CorruptedMetalBlade
{
    /// <summary>
    /// Weapon, PreBoss
    /// Broadsword that also shoots projectiles like the Ice Blade
    /// Without Dark Blessing player takes 10 sacrificialHurt
    /// With Dark Blessing player shots MetalboundCatalystProjectile every third swing
    /// </summary>
    public class CorruptedMetalBlade : ModItem
    {
        public int swingCount = 0;
        public override void SetDefaults()
        {
            Item.damage = 18;
            Item.crit = 2;
            Item.DamageType = ModContent.GetInstance<RitualistClass>();
            Item.knockBack = 4.57f;
            Item.noMelee = false;

            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.Blue;

            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.autoReuse = true;

            Item.useStyle = ItemUseStyleID.Swing;
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
            recipe.AddRecipeGroup("Ritualist:Gold-OrPlatinumBroadsword", 1);
            recipe.AddRecipeGroup("Ritualist:Copper-OrTinBar", 3);
            recipe.AddIngredient(ItemID.LifeCrystal, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.HasBuff(ModContent.BuffType<MinorDarkBlessing>())) // Used with buff MinorDarkBlessing
            {
                swingCount++;
                if (swingCount > 2) // Shoot every 3 swing
                {
                    swingCount = 0;
                    Projectile.NewProjectile(source, player.Center, velocity, type, damage, knockback, player.whoAmI);
                }
            }
            else // Used without buff MinorDarkBlessing
            {
                swingCount = 0;
                RitualistHurtSystem.RitualistHurt(hurt: 10, player: player);
            }
            return false;
        }
    }
}