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

        //this variable is true when the disc is flying or will fly
        public bool isFlying;
        public override void AI()
        {
            float velXMult = 0.98f;
            float velYMult = 0.98f;
            float velYDec = 0.15f;
            float rotDeg = 0.5f;

            Projectile.velocity.X *= velXMult;//slowly decrease x velocity

            //So ive calculated that any initial |X velocity| < 4.1448 (esentually 3/(0.98^16)) will not "fly"
            //this keeps the disc flying how you previously had it except for the corner fling case

            //set initial flying state
            if (Projectile.timeLeft == 600)
            {
                //i have it only when thrown up to not fly, i like the downwards throw "air bounce" thing at all angles
                isFlying = (Math.Abs(Projectile.velocity.X) < 4.145 && Projectile.velocity.Y < 0) ? false : true;
            }

            //triggers when disc throw is not fit for flying or after flying is over
            if (!isFlying)
            {
                //this also creates a terminal velocity of 7.5 when falling which is approached logarithmically
                //i think unintended but i actually like the way it looks more than just straight gravity
                Projectile.velocity.Y *= velYMult; //tempers Y velocity of discs thrown straight up

                if (Projectile.velocity.X == 0 && Projectile.rotation == 0 && Projectile.velocity.Y > 4) //kinda easter egg if thrown perfectly up or down
                {
                    Projectile.velocity.Y = 4.15f;
                }
                else
                {
                    Projectile.velocity.Y += velYDec;
                }

                if (Projectile.velocity.X > 0 && Projectile.rotation < Math.PI / 2) //tilt the disc as it falls but not past vertical
                {
                    Projectile.rotation += MathHelper.ToRadians(rotDeg);
                }
                else if (Projectile.velocity.X < 0 && Projectile.rotation > -1 * (Math.PI / 2))
                {
                    Projectile.rotation -= MathHelper.ToRadians(rotDeg);
                }
            }
            //trigger when flying or soon to be flying
            else
            {
                //determine when the disc stops flying when it is flying
                if (Projectile.timeLeft < 560 || (Math.Abs(Projectile.velocity.X) < 3 && Projectile.velocity.Y == 0))
                {
                    isFlying = false;
                }
                else if (Projectile.timeLeft < 585) //make the disc fly when criteria is met
                {
                    //made it not zero so the stop is less jarring
                    Projectile.velocity.Y *= 0.75f;
                }
            }
        }
    }
}