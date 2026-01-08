using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast2D_TestGame.Scripts
{
    
    
    internal class PlatformManager : GameObject
    {
        float m_PlatformsCooldown = 10;
        float m_PlatformTimer = 10f;
        int m_platformPoolSize = 0;
        
        Queue<Platform> m_Platforms;


        public PlatformManager(Vector2 pos, Vector2 size, string path) : base(pos, size, path)
        {

            m_Platforms = new Queue<Platform>();
            m_platformPoolSize = 10;

            for (int i = 0; i < m_platformPoolSize; i++)
            {

                Platform platform = new Platform(new Vector2(this.Position.X, this.Position.Y), new Vector2(100, 18), "../../Assets/spr_platform.png", 1);
                platform.CreateCollider(ColliderType.Rectangle);
                platform.IsActive = false;
                m_Platforms.Enqueue(platform);
                Game.Instance.CurrentScene.AddObejctToScene(platform);
            }
        }

        public override void Update()
        {

            base.Update();
            //platform timer and creating platform instance
            m_PlatformTimer -= Window.Current.DeltaTime;

            if (m_PlatformTimer <= 0)
            {
                //Platform
                if (Window.Current.GetKey(KeyCode.Space))
                {
                    Platform dequeuedPlatform = m_Platforms.Dequeue();
                    dequeuedPlatform.Position = Position;
                    dequeuedPlatform.IsActive = true;
                    m_Platforms.Enqueue(dequeuedPlatform);

                    m_PlatformTimer = m_PlatformsCooldown;

                    Console.WriteLine("NewPosition");
                }
            }

            

        }
    }

   





}

