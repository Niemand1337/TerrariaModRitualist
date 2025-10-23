using Microsoft.Xna.Framework;
using Ritualist.Buffs.MinorDark;
<<<<<<< HEAD
=======
using Ritualist.Content.Projectiles.MinorDark;
>>>>>>> 515884c9185e2bf7e22e345e8fc66f09c7d3e9c8
using Ritualist.Content.Projectiles.PurpleSphere;
using Ritualist.System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Ritualist.Content.Items.Weapons.PreHardmode.MinorDarkSpellbook
{
    /// <summary>
    /// Weapon
    /// Magic book thats shoots projectiles PurpleSpheres which slow down till standing still after 3.5 seconds
    /// After 4 seconds it shoots an laser
    /// With Eye On You Blessing it shoots an additional laser after 5 seconds
    /// Without Dark Blessing player takes 7 sacrificialHurt
    /// </summary>
    public class MinorDarkSpellbook : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 29;
            Item.crit = 2;
            Item.ArmorPenetration = 2;
            Item.DamageType = ModContent.GetInstance<RitualistClass>();
            Item.knockBack = 0;
            Item.mana = 11;
            Item.noMelee = true;

            Item.value = Item.buyPrice(gold: 5);
            Item.rare = ItemRarityID.Blue;

            Item.width = 14;
            Item.height = 16;

            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.reuseDelay = 20;
            Item.autoReuse = true;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item20;

            Item.shoot = ModContent.ProjectileType<PurpleSphereProjectile>();
            Item.shootSpeed = 7f;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (!player.HasBuff(ModContent.BuffType<MinorDarkBlessing>()))
            {
                RitualistHurtSystem.RitualistHurt(hurt: 7, player: player);
            }
            return true;
        }
    }
}