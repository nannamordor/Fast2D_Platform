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
            /*//esercizio stalla 

            Stalla m_StallaCavalli;
            Stalla m_StallaMaiali;
            Stalla m_StallaElefanti;

          

            m_StallaCavalli = new Stalla("Cavalli", 12);
            m_StallaMaiali = new Stalla("Maiali", 14);
            m_StallaElefanti = new Stalla("Elefanti", 3);

            m_StallaCavalli.GetDescription();
            m_StallaMaiali.GetDescription();
            m_StallaElefanti.GetDescription();

            Console.ReadLine();*/

            //game

            Game game = new Game(800, 800, "MyGame");
            game.Update();


        }
    }

}
