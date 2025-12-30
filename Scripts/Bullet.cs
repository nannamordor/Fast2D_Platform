using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast2D_TestGame.Scripts
{
    class Bullet:GameObject
    {
        float m_Speed = 0;

        public Bullet(Vector2 pos, Vector2 size, string path, float speed) : base(pos, size, path)
        {
            m_Speed = speed;
            Order = 5;
        }

        public override void Update()
        {
            base.Update();

            float frameSpeed = m_Speed * Window.Current.DeltaTime;

            //go up
            Position.Y -= frameSpeed;
            if (Position.X <= Size.X || Position.X >= 800 + Size.X || Position.Y <= Size.Y || Position.Y >= 800 + Size.Y)
            {
                IsActive = false;
            }
        }

    }
}
