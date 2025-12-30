using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast2D_TestGame.Scripts
{
    class Object : IUpdatable, IDrawable
    {
        public bool IsActive = true;
        public int Order = 0;

        public virtual void Draw()
        {
            
        }

        public virtual void Update()
        {
            
        }
    }
}
