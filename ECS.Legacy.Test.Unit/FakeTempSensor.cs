using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Legacy
{
    class FakeTempSensor : ITempSensor
    {
        int curTemp = 0;
        public int GetTemp()
        {
            return curTemp;
        }

        public void SetTemp(int val)
        {
            curTemp = val;
        }
    }
}
