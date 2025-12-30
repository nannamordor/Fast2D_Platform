//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Fast2D_TestGame.Scripts
//{
//    class Manager<T> : IUpdatable where T : new()
//    {
//        //singleton, puo' essercene solo uno per volta e i suoi membri di classe non si possono modificare singolarmente, si modificano per tutti quelli che usano quel singleton es albero ha sempre rami, tronco, foglie
//        public static T Instance {get; private set;}

//        public Manager()
//        {
//            //inizializzazione di un singleton
//            if (Instance != null)
//            {
//                return;
//            }

//            Instance = new T();
//        }

//        public void Update()
//        {
//            throw new NotImplementedException();
//        }

//    }
//}
