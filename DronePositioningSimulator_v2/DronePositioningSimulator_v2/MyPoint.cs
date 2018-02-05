using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DronePositioningSimulator_v2
{
    public class MyPoint
    {
        public float X { set; get; }
        public float Y { set; get; }

        public MyPoint()
        {

        }

        public MyPoint(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
