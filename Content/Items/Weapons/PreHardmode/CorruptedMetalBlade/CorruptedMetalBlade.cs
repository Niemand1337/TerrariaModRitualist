using Microsoft.Xna.Framework;
using Ritualist.Buffs.MinorDark;
using Ritualist.Content.Projectiles.MinorDark;
using Ritualist.System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Ritualist.Content.Items.Weapons.PreHardmode.CorruptedMetalBlade
{
    /// <summary>
    /// Weapon, PreBoss
    /// Broadsword that also shoots projectiles like the Ice Blade
    /// Without Dark Blessing player takes 11 sacrificialHurt
    /// With Dark Blessing player shots MetalboundCatalystProjectile every fourth swing
    /// </summary>
    public class CorruptedMetalBlade : ModItem
    {
        public int swingCount = 0;
        public override void SetDefaults()
        {
            Item.damage = 17;
            Item.crit = 2;
            Item.DamageType = ModContent.GetInstance<RitualistClass>();
            Item.knockBack = 4.57f;
            Item.noMelee = false;

            Item.value = Item.buyPrice(gold: 3);
            Item.rare = ItemRarityID.Blue;

            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.autoReuse = true;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.UseSound = SoundID.Item20;

            Item.shoot = ModContent.ProjectileType<MinorDarkProjectile>();
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
                if (swingCount > 3) // Shoot every 4 swing
                {
                    swingCount = 0;
                    Projectile.NewProjectile(source, player.Center, velocity, type, damage, knockback, player.whoAmI);
                }
            }
            else // Used without buff MinorDarkBlessing
            {
                swingCount = 0;
                RitualistHurtSystem.RitualistHurt(hurt: 11, player: player);
            }
            return false;
        }
    }
}