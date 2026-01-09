using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace Fast2D_TestGame.Scripts
{
    class Player : GameObject
    {
        //properties
        int m_Health = 0;
        float m_Speed = 0;
        
        bool m_IsColliding = false;
        float m_Gravity= 0;
        
        

        //costruttore, ctor
        public Player(Vector2 pos, Vector2 size, string path, int health, float speed) : base(pos, size, path)
        {
            m_Health = health;
            m_Speed = speed;

        }

        public override void Update()
        {

            base.Update();


            float frameSpeed = m_Speed * Window.Current.DeltaTime;
            m_IsColliding = m_Collider.IsColliding;


            //move up
            /*if (Window.Current.GetKey(KeyCode.W) || Window.Current.GetKey(KeyCode.Up))
            {
                Position.Y -= frameSpeed;
            }*/

            //move down
            if (Window.Current.GetKey(KeyCode.S) || Window.Current.GetKey(KeyCode.Down))
            {
                Position.Y += frameSpeed;
            }

            //move left
            if (Window.Current.GetKey(KeyCode.A) || Window.Current.GetKey(KeyCode.Left))
            {
                Position.X -= frameSpeed;
            }

            //move right
            if (Window.Current.GetKey(KeyCode.D) || Window.Current.GetKey(KeyCode.Right))
            {
                Position.X += frameSpeed;
            }

            //jump
            if (Window.Current.GetKey(KeyCode.Space))
            {
                Position.Y -= 10;
                //Console.WriteLine("Jump");
            }


            //revert player position if outofbounds

            if (Position.Y <= 0)
            {
                Position.Y += frameSpeed;
            }

            if (Position.Y >= 800 - Size.Y)
            {
                Position.Y -= frameSpeed;
            }

            if (Position.X <= 0)
            {
                Position.X += frameSpeed;
            }

            if (Position.X >= 800 - Size.X)
            {
                Position.X -= frameSpeed;
            }




            //add Gravity when not colliding with platform

            if (m_IsColliding == true)
            {
                m_Gravity = 0f;
            }
            else
            {
                m_Gravity = 1f;
                Position.Y += m_Gravity;
            }

         
        }


        
        


    }


}

