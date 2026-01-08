using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast2D_TestGame.Scripts
{
    class Platform : GameObject
    {

        
        float m_Gravity = 0;

        public Platform(Vector2 pos, Vector2 size, string path, float speed) : base(pos, size, path)
        {
            m_Gravity = speed;
            //se collide è true ed è di tipo player player pos = y della piattaforma + altezza piattaforma
            //se il player preme w rimettere a false la collisione
        }


        public override void Update()
        {

            base.Update();

            float frameSpeed = m_Gravity * Window.Current.DeltaTime;

            Position.Y += frameSpeed;

            if (Position.Y > 800 + Size.Y)
            {
                IsActive = false;
            }


        }
    }
}