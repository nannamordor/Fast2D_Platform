using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast2D_TestGame.Scripts
{
    class Game
    {
        public static Game Instance { get; private set; }
        public Scene CurrentScene;
        Window m_Window;
        GameObject m_Player;
        PlatformManager m_PlatformManager;
        Object m_Background;
        Platform m_StartingPlatform;

        public Game(int WinWdth, int WinHgth, string WinName)
        {
            if (Instance != null)
            {
                return;
            }

            Instance = this;

            m_Window = new Window(WinWdth, WinHgth, WinName);
            CurrentScene = new Scene("Scene1");

            PhysicsManager physicsManager = new PhysicsManager();
            

            //gameobjects
            m_Background = new Background(new Vector2(0, 0), new Vector2(800, 800), "../../Assets/bg.jpg", 100);
            CurrentScene.AddObejctToScene(m_Background);
            m_Player = new Player(new Vector2(350, 300), new Vector2(64, 64), "../../Assets/spr_link.png", 100, 500);
            m_Player.CreateCollider(ColliderType.Rectangle);
            m_StartingPlatform = new Platform(new Vector2(m_Player.Position.X, m_Player.Position.Y+m_Player.Size.Y), new Vector2(100, 18), "../../Assets/spr_platform.png", 100);
            m_StartingPlatform.CreateCollider(ColliderType.Rectangle);
            m_PlatformManager = new PlatformManager();

            //m_PlatformPool = new Platform(new Vector2(m_Player.Position.X - 800, m_Player.Position.Y + m_Player.Size.Y), new Vector2(100, 80), "../../Assets/spr_platform.png", 0f, 300f, 10);
            //m_PlatformPool.CreateCollider(ColliderType.Rectangle);

            CurrentScene.AddObejctToScene(m_Player);
            CurrentScene.AddObejctToScene(m_StartingPlatform);
            CurrentScene.AddObejctToScene(m_PlatformManager);
            CurrentScene.AddObejctToScene(physicsManager);

        }

        public void Update()
        {

            m_Window.SetClearColor(255, 0, 255);

            while (m_Window.IsOpened)
            {
                CurrentScene.Update();
                CurrentScene.Draw();
                m_Window.Update();

            }
        }
    }
}
