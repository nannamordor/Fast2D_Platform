using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast2D_TestGame.Scripts
{
    
    
    internal class PlatformManager : Object
    {
        float m_PlatformsCooldown = 2f;
        float m_PlatformTimer = 0f;
        int m_platformPoolSize = 0;
        Vector2 m_Pos = new Vector2(300, -2);
        
        Queue<Platform> m_Platforms;


        public PlatformManager()
        {

            m_Platforms = new Queue<Platform>();
            m_platformPoolSize = 10;
            

            for (int i = 0; i < m_platformPoolSize; i++)
            {

                Platform platform = new Platform(m_Pos, new Vector2(100, 18), "../../Assets/spr_platform.png", 100);
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
                //if (Window.Current.GetKey(KeyCode.Space))
                {
                    var m_Offset = new Random();

                    Platform dequeuedPlatform = m_Platforms.Dequeue();
                    //Prendo come x un numero casuale tra 0 e la larghezza della window
                    dequeuedPlatform.Position = new Vector2(m_Offset.Next(0, Window.Current.Width-(int)dequeuedPlatform.Size.X), m_Pos.Y);
                    dequeuedPlatform.IsActive = true;
                    m_Platforms.Enqueue(dequeuedPlatform);

                    m_PlatformTimer = m_PlatformsCooldown;
                    
                    Console.WriteLine("NewPosition");
                    
                }
            }

            

        }
    }

   





}

