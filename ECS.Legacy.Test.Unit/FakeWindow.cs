using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Legacy.Test.Unit
{
    class FakeWindow : IWindow
    {
        public int timesOpened { get; set; }
        public int timesClosed { get; set; }

        public FakeWindow()
        {
            timesOpened = 0;
            timesClosed = 0;
        }
        public void CloseWindow()
        {
            timesClosed++;
        }

        public void OpenWindow()
        {
            timesOpened++;
        }
    }
}
