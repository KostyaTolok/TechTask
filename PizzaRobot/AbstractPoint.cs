using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRobot
{
    abstract public class AbstractPoint
    {
        abstract public int X { get; protected set; }

        abstract public int Y { get; protected set; }

        protected AbstractPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

    }
}
