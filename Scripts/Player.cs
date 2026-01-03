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
        Queue<Bullet> m_PlayerBullets;
        float m_BulletCooldown;
        float m_BulletTimer = 0;
        public bool m_IsColliding = false;

        //costruttore, ctor
        public Player(Vector2 pos, Vector2 size, string path, int health, float speed, float bulletCooldown, int bulletPoolSize) : base(pos, size, path)
        {
            m_Health = health;
            m_Speed = speed;
            m_BulletCooldown = bulletCooldown;

            m_PlayerBullets = new Queue<Bullet>();

            for (int i = 0; i < bulletPoolSize; i++)
            {
                
                Bullet playerBullet = new Bullet(new Vector2(Position.X + Size.X / 2, Position.Y), new Vector2(20, 20), "../../Assets/spr_link.png", 500);
                playerBullet.IsActive = false;
                m_PlayerBullets.Enqueue(playerBullet);
                Game.Instance.CurrentScene.AddObejctToScene(playerBullet);
            }
        }

        public override void Update()
        {

            base.Update();


            float frameSpeed = m_Speed * Window.Current.DeltaTime;

            //move up
            if (Window.Current.GetKey(KeyCode.W) || Window.Current.GetKey(KeyCode.Up))
            {
                Position.Y -= frameSpeed;

                
            }

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

           m_BulletTimer -= Window.Current.DeltaTime;

            //spara un proiettile ogni timer frame
            if (m_BulletTimer <= 0)
            { 
                //shoot
                if (Window.Current.GetKey(KeyCode.Space))
                {
                    Bullet dequeuedBullet = m_PlayerBullets.Dequeue();
                    dequeuedBullet.Position = Position;
                    dequeuedBullet.IsActive = true;
                    m_PlayerBullets.Enqueue(dequeuedBullet);

                    m_BulletTimer = m_BulletCooldown;
                }
            }

            if (m_IsColliding == true)
                {
                //se collide è true ed è di tipo player player pos = y della piattaforma + altezza piattaforma
                //se il player preme w rimettere a false la collisione
            }
        }      
    }
}
