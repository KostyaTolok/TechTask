using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRobot
{
    // Класс фабрики точек
    public class PointFactory : IPointFactory
    {
        public AbstractPoint Create(int x, int y) => new Point(x, y);
    }
}
