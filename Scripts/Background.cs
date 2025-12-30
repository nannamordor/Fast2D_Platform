using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast2D_TestGame.Scripts
{
    class Background: Object
    {
        int m_ScrollSpeed;
        GameObject m_BgB;
        GameObject m_BgA;
       

        public Background(Vector2 pos, Vector2 size, string path, int scrollSpd)
        {
            m_ScrollSpeed = scrollSpd;

            Vector2 bPos = new Vector2(pos.X, pos.Y - size.Y);
            m_BgA = new GameObject(pos, size, path);
            m_BgB = new GameObject(bPos, size, path);


        }

        public override void Update()
        {
            m_BgA.Position.Y += m_ScrollSpeed*Window.Current.DeltaTime;
            m_BgB.Position.Y += m_ScrollSpeed * Window.Current.DeltaTime;

            //Make them scroll
            //Control if bgA or bgB reached the end of screen height (Window.Current.Height)
            //If so, set the position of A or B in the correct place with bgA.Position or bgB.position
            if (m_BgA.Position.Y >= m_BgA.Size.Y)
            {
                m_BgA.Position.Y = m_BgB.Position.Y- m_BgA.Size.Y;
            }

            if (m_BgB.Position.Y >= m_BgB.Size.Y)
            {
                m_BgB.Position.Y = m_BgA.Position.Y-m_BgB.Size.Y;
            }
        }

        public override void Draw()
        {
            m_BgA.Draw();
            m_BgB.Draw();
        }
    }



}

