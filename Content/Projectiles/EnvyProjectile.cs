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
            Projectile.velocity.X *= velXMult;
            float velYDec = 0.15f;
            //Main.NewText("" + Projectile.timeLeft, 63, 255, 63);
            if (Math.Abs(Projectile.velocity.X) < 3)
            {
                Projectile.velocity.Y += velYDec;
            }
            else if (Projectile.timeLeft < 585)
            {
                Projectile.velocity.Y = 0;
            }

            Projectile.rotation = 0;//Keep the disc flat. TODO, tilt down as it drops?
        }
    }
}