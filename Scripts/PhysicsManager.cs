using OpenTK;
using OpenTK.Graphics.ES11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast2D_TestGame.Scripts
{
    public enum ColliderType
    { 
        Circle,
        Rectangle
    }

    class PhysicsManager : Object
    {
        public static PhysicsManager Instance { get; private set; }
        private List<Collider> m_Colliders;
        public PhysicsManager()
        {
            if(Instance != null)
            {
                return;
            }

            Instance = this;

            m_Colliders = new List<Collider>();
        }

        public void RegisterCollider(Collider collider)
        {
            if (m_Colliders.Contains(collider))
            {
                return;
            }

            m_Colliders.Add(collider);
        }

        public override void Update()
        {
            foreach (var c1 in m_Colliders)
            {
                foreach (var c2 in m_Colliders)
                {
                    if (c1 == c2)
                    {
                        continue;
                    }

                    c1.IsCollidingWith(c2);
                }
            }
        }
    }

    class Collider:IUpdatable
    {
        public ColliderType ColliderType;

        // Creiamo il seguente metodo.
        // Come controlliamo se due Cerchi sono in collisione?
        private float m_Radius;
        private Vector2 m_Size;
        private Vector2 m_Position;
        private GameObject m_Owner;
        

        public Collider(float rad,  GameObject owner)
        {
            //create a circle collider
            m_Radius = rad;
            m_Owner = owner;
            m_Position = m_Owner.Position;

            ColliderType = ColliderType.Circle;

        }

        public Collider(Vector2 size, GameObject owner)
        {
            //create a rectangle collider
            m_Size = size;
            m_Owner = owner;
            m_Position = m_Owner.Position;

            ColliderType = ColliderType.Rectangle;
        }

        public bool IsCollidingWith(Collider other)
        {
            if (ColliderType == ColliderType.Circle)
            {
                if (other.ColliderType == ColliderType.Circle)
                {
                    return CheckCircleCircleCollision(other);
                }
                else
                {
                    return CheckCircleRectangleCollision(other);
                }
            }
            else
            {
                if (other.ColliderType == ColliderType.Circle)
                {
                    return CheckCircleRectangleCollision(other);
                }
                else
                {
                    return CheckRectangleRectangleCollision(other);
                }
            }
         
        }

        public bool CheckCircleCircleCollision(Collider other)
        {
            float distance = Vector2.Distance(other.m_Position, m_Position);

            //Console.WriteLine(distance <= m_Radius + other.m_Radius);
           
            return distance <= m_Radius + other.m_Radius;
        }

        public bool CheckCircleRectangleCollision(Collider other)
        {
            float distance = 1;
            float distance_1 = 1;
            return distance <= distance_1;
        }

        public bool CheckRectangleRectangleCollision(Collider other)
        {
           

            if (m_Position.X + m_Size.X * 0.5f >= other.m_Position.X - other.m_Size.X * 0.5f) //sinistra a destra
               
            {
                Console.WriteLine("false");
                return false;
            }
            else
            {
                Console.WriteLine("true");
               
                return true;

                
            }
        }

        public void Update()
        {
            
            m_Position = new Vector2(m_Owner.Position.X + m_Owner.Size.X * 0.5f, m_Owner.Position.Y + m_Owner.Size.Y * 0.5f);
        }
    }
}
