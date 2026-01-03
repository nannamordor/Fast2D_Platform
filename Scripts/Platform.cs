using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast2D_TestGame.Scripts
{
    internal class Platform : GameObject
    {


        public Platform(Vector2 pos, Vector2 size, string path, float offset) : base(pos, size, path)
        {
            //se collide è true ed è di tipo player player pos = y della piattaforma + altezza piattaforma
            //se il player preme w rimettere a false la collisione
        }

       

        
    }
}
