using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using Fast2D_TestGame.Scripts;
using OpenTK;

namespace Fast2D_TestGame
{
    class Program
    {
        
        static void Main(string[] args)
        {

            Game game = new Game(800, 800, "MyGame");
            game.Update();


        }
    }

}
