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
            Projectile.aiStyle = 0;//We're using our own defined below
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 600;
            Projectile.direction = 0;
        }
        public override void Kill(int timeLeft)
        {

            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }
        public override void AI()
        {
            float velXMult = 0.98f;
            float velYMult = 0.98f;
            float velYDec = 0.15f;
            float rotDeg = 0.5f;

            Projectile.velocity.X *= velXMult;//slowly decrease x velocity

            if (Math.Abs(Projectile.velocity.X) < 3)
            {
                Projectile.velocity.Y *= velYMult;//tempers Y velocity of discs thrown straight up
            }

            if (Math.Abs(Projectile.velocity.X) < 3 || Projectile.timeLeft < 560 || Projectile.velocity.Y > 0)
            {
                Projectile.velocity.Y += velYDec;
                if(Projectile.velocity.X > 0)//tilt the disc as it falls
                {
                    Projectile.rotation += MathHelper.ToRadians(rotDeg);
                }
                else
                {
                    Projectile.rotation -= MathHelper.ToRadians(rotDeg);
                }
            }
            else if (Projectile.timeLeft < 585)
            {
                Projectile.velocity.Y = 0;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            float textX = Projectile.velocity.X;
            if (true/*tile == Tiles.Basket?*/Collision.FindCollisionTile)
            {

            }
            else
            {

            }
            return true;
        }
    }
}