using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRobot
{
    public interface IPointFactory
    {
        AbstractPoint Create(int x, int y);
    }
}
