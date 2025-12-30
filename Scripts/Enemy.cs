using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast2D_TestGame.Scripts
{
    class Enemy : GameObject
    {

        float m_speed;
        GameObject m_target;

        public Enemy(Vector2 pos, Vector2 size, string path, float speed, int health, GameObject target):base(pos, size, path)
        {
            m_speed = speed;
            m_target = target;
        }

        public override void Update()
        {
            base.Update();

            //Position.X = m_target.Position.X + Size.X /2;

        }
    }
}
