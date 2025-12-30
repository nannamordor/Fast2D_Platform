using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast2D_TestGame.Scripts
{
    class GameObject : Object
    {

        Sprite m_Sprite;
        Texture m_Texture;
        protected Collider m_Collider;


        //dimensions
        Vector2 m_Size;
        public Vector2 Size { get { return m_Size; }
        private set
            {
                m_Size = value;
                m_Sprite = new Sprite(m_Size.X, m_Size.Y);
            }
        }
        

       
        //position
        public Vector2 Position;

        //texture
        string m_TexturePath;
        //property che gestisce m_texturePath
        public string TexturePath { get { return m_TexturePath; }
            private set 
            {
                m_TexturePath = value;

                try
                {
                    m_Texture = new Texture(m_TexturePath);
                }
                catch (Exception ex)
                {
                    // L'utente potrebbe passare stringhe vuote o path non corretti quindi usiamo try catch per gestire eventuali crush <3 uwu
                    Console.WriteLine(ex.Message);
                    m_TexturePath = "../../Assets/no_texture.png";
                    m_Texture = new Texture(m_TexturePath);

                }
            }
        }

        //costruttore, ctor
        public GameObject(Vector2 pos, Vector2 size, string path)
        {
            Position = pos;
            Size = size;
            TexturePath = path;

            m_Sprite = new Sprite(m_Size.X, m_Size.Y);
        }

        //metodi
        
        //aggiorno il path della texture
        public void SetSprite(string texPath)
        {
            TexturePath = texPath;
        }

        //metodo che puo' essere overradato da una classe figla usa virtual
        public override void Update()
        {
            if (!IsActive)
            {
                return;
            }

            if (m_Collider != null)
            {
                m_Collider.Update();
            }

        }

        public override void Draw()
        {
            if (!IsActive)
            {
                return;
            }

            m_Sprite.position = Position;
            m_Sprite.DrawTexture(m_Texture);
           
        }

        public virtual void CreateCollider(ColliderType col)
        {
            if (col == ColliderType.Circle)
            {
                m_Collider = new Collider(m_Size.X * 0.5f, this);
                PhysicsManager.Instance.RegisterCollider(m_Collider);
            }

            if (col == ColliderType.Rectangle)
            {
                m_Collider = new Collider(m_Size, this);
                PhysicsManager.Instance.RegisterCollider(m_Collider);
            }
           
        }
    }
}
