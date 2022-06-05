using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace slingin.Content.Projectiles 
{
    public class EnvyProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.penetrate = 1;
            Projectile.width = 2;
            Projectile.height = 20;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 600;
            Projectile.direction = 0;
            //AIType = ProjectileID.WoodenArrowFriendly;
        }
        public override void Kill(int timeLeft)
        {

            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }
        public override void AI()
        {
            //Projectile.Distance();
            float velXMult = 0.95f;
            Projectile.velocity.X *= velXMult;
            float velYDec = 0.15f;
            //Main.NewText("X:" + Projectile.velocity.X + " Y:" + Projectile.velocity.Y, 63, 255, 63);
            if (Math.Abs(Projectile.velocity.X) < 5f)
            {
                Projectile.velocity.Y += velYDec;
            }

            //float velRotation = Projectile.velocity.ToRotation();
            Projectile.rotation = 0;//velRotation + MathHelper.ToRadians(90f);
        }
    }
}