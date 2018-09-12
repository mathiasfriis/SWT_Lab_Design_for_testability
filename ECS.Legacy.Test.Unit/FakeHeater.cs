using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Legacy
{
    class FakeHeater : IHeater
    {
        public int timesTurnedOn { get; set; }
        public int timesTurnedOff { get; set; }

        public FakeHeater()
        {
            timesTurnedOn = 0;
            timesTurnedOff = 0;
        }

    public void TurnOff()
        {
            timesTurnedOff++;
        }

        public void TurnOn()
        {
            timesTurnedOn++;
        }
    }
}
