using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Legacy
{
    class WIndow : IWindow
    {
        public void CloseWindow()
        {
            Console.WriteLine("Window closes");
        }

        public void OpenWindow()
        {
            Console.WriteLine("Window opens");
        }
    }
}
