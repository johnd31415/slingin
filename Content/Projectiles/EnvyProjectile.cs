using System; //what sources the code uses, these sources allow for calling of terraria functions, existing system functions and microsoft vector functions (probably more)
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace slingin.Content.Projectiles 
{
    public class EnvyProjectile : ModProjectile //the class of the projectile
    {
        public override void SetDefaults()
        {
            Projectile.penetrate = 2;
            Projectile.width = 2; //sprite is 2 pixels wide
            Projectile.height = 20; //sprite is 20 pixels tall
            Projectile.aiStyle = 0; //projectile moves in a straight line
            Projectile.friendly = true; //player projectile
            Projectile.DamageType = DamageClass.Ranged; // Is the projectile shoot by a ranged weapon?
            Projectile.timeLeft = 60; //Terraria runs at 60FPS, so it lasts 2 seconds.
            AIType = ProjectileID.Bullet; //This clones the exact AI of the vanilla projectile Bullet.
        }
        public override void Kill(int timeLeft)
        {

            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }
    }
}