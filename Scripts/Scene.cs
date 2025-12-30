using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast2D_TestGame.Scripts
{
    class Scene
    {
        List<Object> m_GameObjects;

        public Scene(string Name)
        {
            m_GameObjects = new List<Object>();
        }
        public void Open()
        {
            // empty at the moment
          
        }
        public void AddObejctToScene(Object gmo)
        {
            // Add and object to the scene
            m_GameObjects.Add(gmo);
        }

        public void RemoveObjectFromScene()
        {
            // Removes an object from the scene
        }

        public void Update()
        {
            // Calls update on each gameobject inside the scene
            foreach (Object gmo in m_GameObjects)
            {
                gmo.Update();
            }

            //for each gameobject update
        }

        public void Draw()
        {
            // Calls update on each gameobject inside the scene
            foreach (Object gmo in m_GameObjects)
            {
                gmo.Draw();
            }
        }

        public void Close()
        {
            // empty atm
        }
    }
}
